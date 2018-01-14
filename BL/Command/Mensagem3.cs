using BL.Business;
using BL.DAO;
using BL.Infra;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;

namespace BL.Command
{
    class Mensagem3 : ConfigStatus, IMessage, ISaveData<ResponseMessage3Exportation>
    {
        public string Message { get { return MessagesOfReturn.Message(Option.MENSAGEM3, Option.EXPORTACAO); } }

        public string SwapXmlWithGTE()
        {
            string messageReturn = "";
            //Obtem do servidor os dados para requisição
            IDictionary<string, string> objectsToRequest = new DatasToRequestExportation3().GetDatasToRequest();
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
                            SaveXMLOriginal.SaveXML(new ExportationMessageRequest(xmlRequest, "", Option.MENSAGEM3));

                            //Efetua o request ao WebService enviando o XML serializado
                            string xmlResponse = RequestWebService.doRequestWebService(xmlRequest, Message);
                            //salva o xml response
                            SaveXMLOriginal.SaveXML(new ExportationMessageResponse(xmlResponse, "", Option.MENSAGEM3));

                            //salva o response no banco de dados
                            messageReturn += SaveResponseDataBase(xmlResponse, sbeln);
                        }catch(Exception ex)
                        {
                            string messageError = MessagesOfReturn.ExceptionMessageLogSupport(Message, sbeln);
                            int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, $"{Message} - Embarque: {sbeln}");
                            messageReturn += MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, messageError);
                        }
                    }
                    else //Não localizou os registros do Detalhe do embarque específico
                        messageReturn += MessagesOfReturn.DatasToRequestEmpty(Message, sbeln);
                }
            }
            else
                messageReturn = MessagesOfReturn.NotRequest(Message);

            return messageReturn;
        }

        private string SaveResponseDataBase(string xmlResponse, string sbeln)
        {
            string messageReturn = "";
            //Desserializa o Response
            ResponseMessage3Exportation responseMsg3 = new DeserializeXml<ResponseMessage3Exportation>().deserializeXmlForDB(xmlResponse);
            if (responseMsg3 != null && responseMsg3.RESPONSE != null && responseMsg3.RESPONSE.STATUS != null)
            {
                ConfigureStatus(responseMsg3.RESPONSE.STATUS, Option.MENSAGEM3, Option.EXPORTACAO, sbeln);

                //O conteúdo enviado ao Webservice esta com erro
                if (responseMsg3.RESPONSE.STATUS.ERRORS != null && responseMsg3.RESPONSE.STATUS.ERRORS.Count > 0)
                    messageReturn = SaveResponseAlerta(responseMsg3.RESPONSE.STATUS);
                else // Webservice enviou resposta de sucesso
                    messageReturn = SaveResponseSuccess(responseMsg3);
            }
            else // Webservice enviou mensagem de erro
                messageReturn = SaveResponseError(xmlResponse, sbeln);

            AlterFlagChangeMessage(sbeln);

            return messageReturn;
        }

        public void AlterFlagChangeMessage(string sbeln)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln);
            embarque.AtualizaDetalhe = false;
            dao.Update();
        }

        public string SaveResponseAlerta(Status status)
        {
            SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, status.SBELN);
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            SaveStatusError(xmlResponse, Option.MENSAGEM3, Option.EXPORTACAO);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, embarque);
        }

        public string SaveResponseSuccess(ResponseMessage3Exportation retornoWebService)
        {
            SaveStatus(retornoWebService.RESPONSE.STATUS);

            return MessagesOfReturn.ProcessMessageSuccess(Message, retornoWebService.RESPONSE.STATUS.SBELN);
        }
    }
}