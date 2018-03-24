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
        private IDictionary<string, List<string>> _objectsToRequestMessage4;
        private bool _processMessage4;
        private ContentText _contentFile;

        /// <summary>
        /// Esse objeto deverá ser criado para todas as mensagens, EXCETO a Mensagem 4. Para a Mensagem 4 utilizar o contrutor
        /// que recebe um IDictionary com a chave uma string e o valor uma lista de string.
        /// </summary>
        /// <param name="objectsToRequestMessage4">Um dictionary, sendo a chave o SBELN e o valor uma lista de requisições</param>
        /// <param name="contentFile">Um ContentText que contém as infomrções para gerar os arquivos de log</param>
        public ProcessMessage(IDictionary<string, string> objectsToRequest, ContentText contentFile)
        {
            _objectsToRequest = objectsToRequest;
            _contentFile = contentFile;
            _processMessage4 = false;
        }

        /// <summary>
        /// Esse objeto deverá ser criado apenas para a Mensagem 4, pois poderá conter mais de um request
        /// para um único Embarque.
        /// </summary>
        /// <param name="objectsToRequestMessage4">Um dictionary, sendo a chave o SBELN e o valor uma lista de requisições</param>
        /// <param name="contentFile">Um ContentText que contém as infomrções para gerar os arquivos de log</param>
        public ProcessMessage(IDictionary<string, List<string>> objectsToRequestMessage4, ContentText contentFile)
        {
            _objectsToRequestMessage4 = objectsToRequestMessage4;
            _contentFile = contentFile;
            _processMessage4 = true;
        }

        /// <summary>
        /// Executa o processo de Obter os dados do banco de dados para efetuar a requisição no Webservice e 
        /// gravar o retorno do Webservice no banco dados e nos arquivos de log (arquivos de log apenas se o usuário solicitou nas configurações)
        /// </summary>
        /// <returns></returns>
        public string Process()
        {
            if (_processMessage4)
                return ProcessOnlyMessage4();
            else
                return ProcessMessageExcept4();
        }

        private string ProcessMessageExcept4()
        {
            string messageReturn = "";

            if (_objectsToRequest.Count > 0)
            {
                foreach (string key in _objectsToRequest.Keys)
                {
                    messageReturn = ExecuteProcessMessage(key, _objectsToRequest[key]);
                }
            }
            else
                messageReturn += MessagesOfReturn.NotRequest(_contentFile.Message);

            return messageReturn;
        }

        private string ProcessOnlyMessage4()
        {
            string messageReturn = "";

            if (_objectsToRequestMessage4.Count > 0)
            {
                foreach (string key in _objectsToRequestMessage4.Keys)
                    foreach(string value in _objectsToRequestMessage4[key])
                        messageReturn = ExecuteProcessMessage(key, value);
            }
            else
                messageReturn += MessagesOfReturn.NotRequest(_contentFile.Message);

            return messageReturn;
        }

        private string ExecuteProcessMessage(string key, string value)
        {
            string messageReturn = "";

            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    string xmlRequest = value;
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
                detailProcess = MessagesOfReturn.DetailProcessWithIdBroker(_contentFile.Message, identifier);
            else
                detailProcess = MessagesOfReturn.DetailProcessWithSblen(_contentFile.Message, identifier);

            int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, detailProcess);

            return MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, messageError);
        }
    }
}

