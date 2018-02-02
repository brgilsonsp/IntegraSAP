using BL.Infra;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;

namespace BL.Business
{
    public class ProcessMessage<T> where T : ISaveResponse
    {
        private IDictionary<string, string> _objectsToRequest;
        private ContentText _contentFile;

        public ProcessMessage(IDictionary<string, string> objectsToRequest, ContentText contentFile)
        {
            _objectsToRequest = objectsToRequest;
            _contentFile = contentFile;
        }
        
        public string Process()
        {            
            string messageReturn = "";
            
            if (_objectsToRequest.Count > 0)
            {
                foreach (string key in _objectsToRequest.Keys)
                {
                    if (!string.IsNullOrEmpty(_objectsToRequest[key]))
                    {
                        try
                        {
                            string xmlRequest = _objectsToRequest[key];
                            string fileName = GetFileName(key);

                            SaveXMLOriginal.SaveXML(_contentFile.ProvideContent(xmlRequest, fileName, TypeContentText.REQUEST));
                            
                            string xmlResponse = RequestWebService.doRequestWebService(xmlRequest, _contentFile.Message);
                            SaveXMLOriginal.SaveXML(_contentFile.ProvideContent(xmlResponse, fileName, TypeContentText.RESPONSE));
                            
                            messageReturn += SaveResponseDataBase(xmlResponse, key);
                        }
                        catch (Exception ex)
                        {
                            BuildLogException(key, ex);
                        }
                    }
                    else
                        messageReturn += MessagesOfReturn.DatasToRequestEmpty(_contentFile.Message);
                }
            }
            else
                messageReturn += MessagesOfReturn.NotRequest(_contentFile.Message);

            return messageReturn;
        }

        private string GetFileName(string key)
        {
            if (_contentFile.NumberOfMessage == NumberOfMessage.One)
                return "Lista";
            else
                return key;
        }

        private string SaveResponseDataBase(string xmlResponse, string identifier)
        {
            T response = new DeserializeXml<T>().deserializeXmlForDB(xmlResponse);
            string msgReturn = "";
            if (response != null && response.IsDatasComplete)
                msgReturn = response.SaveDataBase(identifier, _contentFile.Message, _contentFile.KindOfMessage);
            else
                msgReturn = SaveResponseError(xmlResponse, identifier);

            if (_contentFile.NumberOfMessage != NumberOfMessage.One)
                response.AlterFlagChangeMessage(identifier, _contentFile.KindOfMessage);

            return msgReturn;
        }

        private string SaveResponseError(string xmlResponse, string identifier)
        {
            ResponseFatalError returnError = new DeserializeXml<ResponseFatalError>().deserializeXmlForDB(xmlResponse);
            Status status = new Status(returnError.RESPONSE);
            ConfigStatus.ConfigureStatus(status, _contentFile.NumberOfMessage, _contentFile.KindOfMessage, identifier);
            ConfigStatus.SaveStatus(status);
            
            return MessagesOfReturn.AlertResponseWebServiceError(_contentFile.Message, identifier, _contentFile.NumberOfMessage);
        }

        private string BuildLogException(string identifier, Exception ex)
        {
            string messageError = MessagesOfReturn.ExceptionMessageLogSupport(_contentFile.Message, identifier, _contentFile.NumberOfMessage);
            string detailProcess = "";

            if (_contentFile.NumberOfMessage == NumberOfMessage.One)
                detailProcess = $"{_contentFile.Message} - ID Broker {identifier}";
            else
                detailProcess = $"{_contentFile.Message} - Embarque: {identifier}";

            int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, detailProcess);

            return MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, messageError);
        }
    }
}

