using BL.Business;
using BL.DAO;
using BL.Infra;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Command
{
    class Mensagem5 : ConfigStatus, IMessage, ISaveData<ResponseMessage5Exportation>
    {
        public string Message { get { return MessagesOfReturn.Message(Option.MENSAGEM5, Option.EXPORTACAO); } }

        public string SwapXmlWithGTE()
        {
            string messageReturn = "";
            //Obtem do servidor os dados para requisição
            IDictionary<string, string> objectsToRequest = new DatasToRequestExportation5().GetDatasToRequest();
            if (objectsToRequest.Count > 0)
            {
                foreach (string sbeln in objectsToRequest.Keys)
                {
                    if (!string.IsNullOrEmpty(objectsToRequest[sbeln]))
                    {
                        try
                        {
                            string xmlRequest = objectsToRequest[sbeln];

                            ////salva o xml da request
                            SaveXMLOriginal.SaveXML(new ExportationMessageRequest(xmlRequest, "", Option.MENSAGEM5));

                            //Efetua o request ao WebService enviando o XML serializado
                            string xmlResponse = RequestWebService.doRequestWebService(xmlRequest, Message);

                            //salva o xml response
                            SaveXMLOriginal.SaveXML(new ExportationMessageResponse(xmlResponse, "", Option.MENSAGEM5));

                            //salva o response no banco de dados
                            messageReturn += SaveResponseDataBase(xmlResponse, sbeln);
                        }
                        catch (Exception ex)
                        {
                            string messageError = MessagesOfReturn.ExceptionMessageLogSupport(Message, sbeln);
                            int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, $"{Message} - Embarque: {sbeln}");
                            messageReturn += MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, messageError);
                        }
                    }
                    else
                        messageReturn = MessagesOfReturn.DatasToRequestEmpty(Message, sbeln);
                }
            }
            else
                messageReturn = MessagesOfReturn.NotRequest(Message);

            return messageReturn;
        }

        private string SaveResponseDataBase(string xmlResponse, string sbeln)
        {
            string msgReturn = "";
            ResponseMessage5Exportation responseMsg5 = new DeserializeXml<ResponseMessage5Exportation>().deserializeXmlForDB(xmlResponse);

            if (responseMsg5 != null && responseMsg5.RESPONSE != null && responseMsg5.RESPONSE.STATUS != null)
            {
                ConfigureStatus(responseMsg5.RESPONSE.STATUS, Option.MENSAGEM5, Option.EXPORTACAO, sbeln);

                if (responseMsg5.RESPONSE.PCK != null && responseMsg5.RESPONSE.PCK.Count > 0 && responseMsg5.RESPONSE.PCK.Count > 0)
                    msgReturn = SaveResponseSuccess(responseMsg5);
                else
                    msgReturn = SaveResponseAlerta(responseMsg5.RESPONSE.STATUS);       
            }
            else// Objeto retornoConsultaGTE não obteve nenhum dado do GTE
                msgReturn = SaveResponseError(xmlResponse, sbeln);

            AlterFlagChangeMessage(sbeln);

            return msgReturn;
        }

        public void AlterFlagChangeMessage(string sbeln)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln);
            embarque.ConsultaPrestConta = false;
            dao.Update();
        }

        public string SaveResponseAlerta(Status status)
        {
            SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, status.SBELN);
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            SaveStatusError(xmlResponse, Option.MENSAGEM5, Option.EXPORTACAO);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, embarque);
        }

        public string SaveResponseSuccess(ResponseMessage5Exportation retornoWebService)
        {
            string sbeln = retornoWebService.RESPONSE.PCK.FirstOrDefault(e => !string.IsNullOrEmpty(e.SBELN)).SBELN;
            TPCKDao tpckDao = new TPCKDao();
            Embarque embarque = new EmbarqueDao().FindBySbeln(sbeln);
            RemoveRecorded(embarque.ID, tpckDao);

            retornoWebService.RESPONSE.PCK.ForEach(t => t.Embarque = embarque);
            tpckDao.SaveAll(retornoWebService.RESPONSE.PCK);

            if (retornoWebService.RESPONSE.STATUS != null)
                SaveStatus(retornoWebService.RESPONSE.STATUS, embarque);

            return MessagesOfReturn.ProcessMessageSuccess(Message, retornoWebService.RESPONSE.PCK.FirstOrDefault(t => !string.IsNullOrEmpty(t.SBELN)).SBELN);
        }

        private void RemoveRecorded(int idEmbarque, TPCKDao tpckDao)
        {
            List<TPCK> toRemove = tpckDao.FindByIdEmbarque(idEmbarque);
            tpckDao.RemoveAll(toRemove);
        }   
    }
}
