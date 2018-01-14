using BL.Business;
using BL.DAO;
using BL.Infra;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;

namespace BL.Command
{
    class Mensagem4 : ConfigStatus, IMessage, ISaveData<Status>
    {
        public string Message { get { return MessagesOfReturn.Message(Option.MENSAGEM4, Option.EXPORTACAO); } }

        public string SwapXmlWithGTE()
        {
            string messageReturn = "";
            //Obtem do servidor os dados para requisição
            IDictionary<string, string> objectsToRequest = new DatasToRequestExportation4().GetDatasToRequest();
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
                            SaveXMLOriginal.SaveXML(new ExportationMessageRequest(xmlRequest, "", Option.MENSAGEM4));

                            //Efetua o request ao WebService enviando o XML serializado
                            string xmlResponse = RequestWebService.doRequestWebService(xmlRequest, Message);
                            //salva o xml response
                            SaveXMLOriginal.SaveXML(new ExportationMessageResponse(xmlResponse, "", Option.MENSAGEM4));

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
            string msgReturn = "";
            //Desserializa o Xml Response
            ResponseMessage4Exportation responseMsg4 = new DeserializeXml<ResponseMessage4Exportation>().deserializeXmlForDB(xmlResponse);

            if (responseMsg4 != null &&  responseMsg4.RESPONSE != null && responseMsg4.RESPONSE.STATUS != null)
            { // Se o retorno do GTE for sucesso
                ConfigureStatus(responseMsg4.RESPONSE.STATUS, Option.MENSAGEM4, Option.EXPORTACAO, sbeln);

                if (responseMsg4.RESPONSE.STATUS.ERRORS != null && responseMsg4.RESPONSE.STATUS.ERRORS.Count > 0)
                    msgReturn = SaveResponseAlerta(responseMsg4.RESPONSE.STATUS);
                else
                    msgReturn = SaveResponseSuccess(responseMsg4.RESPONSE.STATUS);
            }
            else
                msgReturn = SaveResponseError(xmlResponse, sbeln);

            AlterFlagChangeMessage(sbeln);

            return msgReturn;
        }

        public string SaveResponseAlerta(Status status)
        {
            SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, status.SBELN);
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            SaveStatusError(xmlResponse, Option.MENSAGEM4, Option.EXPORTACAO);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, embarque);
        }

        public string SaveResponseSuccess(Status retornoWebService)
        {
            SaveStatus(retornoWebService);
            return MessagesOfReturn.ProcessMessageSuccess(Message, retornoWebService.SBELN);
        }

        public void AlterFlagChangeMessage(string sbeln)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln);
            embarque.EnviaPrestConta = false;
            dao.Update();
        }
    }
}
