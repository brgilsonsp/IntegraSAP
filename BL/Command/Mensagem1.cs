using BL.ObjectMessages;
using BL.Business;
using BL.InnerUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using BL.DAO;
using BL.Infra;

namespace BL.Command
{
    class Mensagem1 : ConfigStatus, IMessage, ISaveData<ResponseMessage1Exportation>
    {
        public string Message { get { return MessagesOfReturn.Message(Option.MENSAGEM1, Option.EXPORTACAO); } }

        public string SwapXmlWithGTE()
        {
            string messageReturn = "";
            //Obtem do servidor os dados para requisição
            IDictionary<string, string> objectsToRequest = new DatasToRequestExportation1().GetDatasToRequest();
            if (objectsToRequest.Count > 0)
            {
                foreach (string id in objectsToRequest.Keys)
                {
                    if (!string.IsNullOrEmpty(objectsToRequest[id]))
                    {
                        try
                        {
                            string xmlRequest = objectsToRequest[id];
                            ////salva o xml da request
                            SaveXMLOriginal.SaveXML(new ExportationMessageRequest(xmlRequest, "ListaEmbarque", Option.MENSAGEM1));

                            //Efetua o request ao WebService enviando o XML serializado
                            string xmlResponse = RequestWebService.doRequestWebService(xmlRequest, Message);
                            //salva o xml response
                            SaveXMLOriginal.SaveXML(new ExportationMessageResponse(xmlResponse, "ListaEmbarque", Option.MENSAGEM1));

                            //salva o response no banco de dados
                            messageReturn += SaveResponseDataBase(xmlResponse, id);
                        }
                        catch (Exception ex)
                        {
                            string messageError = MessagesOfReturn.ExceptionMessageLogSupport(Message);
                            int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, $"{Message} - ID Broker {id}");
                            messageReturn += MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, messageError);
                        }
                    }
                    else
                        messageReturn += MessagesOfReturn.DatasToRequestEmpty(Message);
                }
            }
            else
                messageReturn += MessagesOfReturn.NotRequest(Message);

            return messageReturn;
        }

        private string SaveResponseDataBase(string xmlResponse, string idBroker)
        {
            ResponseMessage1Exportation responseMsg1 = new DeserializeXml<ResponseMessage1Exportation>().deserializeXmlForDB(xmlResponse);
            if (responseMsg1 != null && responseMsg1.RESPONSE != null && responseMsg1.RESPONSE.ListaEmbarque == null && responseMsg1.RESPONSE.STATUS == null)
                return SaveResponseError(xmlResponse, idBroker.ToString());

            ConfigureStatus(responseMsg1.RESPONSE.STATUS, Option.MENSAGEM1, Option.EXPORTACAO);
            AlimentaIdDadosBroker(responseMsg1, int.Parse(idBroker));

            if (responseMsg1.RESPONSE.ListaEmbarque != null && responseMsg1.RESPONSE.ListaEmbarque.Embarques.Count > 0)
                return SaveResponseSuccess(responseMsg1);
            else if (responseMsg1.RESPONSE.STATUS != null)
                return SaveResponseAlerta(responseMsg1.RESPONSE.STATUS);
            else // Se não recebeu nenhum Embarque do GTE
                return MessagesOfReturn.AlertResponseWebServiceErrorWithIdBroker(Message, idBroker);
        }

        public string SaveResponseSuccess(ResponseMessage1Exportation retornoWebService)
        {
            EmbarqueDao dao = new EmbarqueDao();
            List<String> listSbeln = dao.GetListSbeln();

            foreach (Embarque embarque in retornoWebService.RESPONSE.ListaEmbarque.Embarques)
                if(!listSbeln.Contains(embarque.SBELN))
                    dao.Save(embarque);

            return MessagesOfReturn.ProcessMessageOneSuccess(Message, retornoWebService.RESPONSE.ListaEmbarque.Embarques.FirstOrDefault().DadosBrokerID);
        }

        public string SaveResponseError(string xmlResponse, string idBroker)
        {
            SaveStatusError(xmlResponse, Option.MENSAGEM1, Option.EXPORTACAO);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithIdBroker(Message, idBroker);
        }

        public string SaveResponseAlerta(Status status)
        {
            SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithIdBroker(Message, status.idBroker.ToString());
        }

        /// <summary>
        /// Alimentado o ID do CNPJ ao Embarque
        /// </summary>
        /// <param name="msg1">BL.ObjectMessages.Msg1RetornoListaEmbarque</param>
        /// <param name="idCabecalho">int</param>
        private void AlimentaIdDadosBroker(ResponseMessage1Exportation msg1, int idBroker)
        {
            if(msg1 != null && msg1.RESPONSE != null && msg1.RESPONSE.ListaEmbarque != null)
                foreach(Embarque cadaEmbarque in msg1.RESPONSE.ListaEmbarque.Embarques)
                    cadaEmbarque.DadosBrokerID = idBroker;

            if (msg1.RESPONSE.STATUS != null)
                msg1.RESPONSE.STATUS.idBroker = idBroker;

        }


        public void AlterFlagChangeMessage(string sbeln)
        {
            throw new NotImplementedException();
        }
    }
}