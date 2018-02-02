using BL.ObjectMessages;
using System.Xml.Serialization;
using System;
using BL.DAO;
using BL.InnerUtil;

namespace BL.Business
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseMessage4 : ISaveResponse
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseWebservice RESPONSE { get; set; }

        [XmlIgnore]
        public bool IsDatasComplete { get { return RESPONSE != null && RESPONSE.STATUS != null; } }
                
        public void AlterFlagChangeMessage(string sbeln, string kindOfMessage)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln, kindOfMessage);
            embarque.EnviaPrestConta = false;
            dao.Update();
        }

        public string SaveDataBase(string identifier, string message, string kindOfMessage)
        {
            NumberOfMessage numberOfMessage = NumberOfMessage.Four;

            ConfigStatus.ConfigureStatus(RESPONSE.STATUS, numberOfMessage, kindOfMessage, identifier);

            if (RESPONSE.STATUS.ERRORS != null && RESPONSE.STATUS.ERRORS.Count > 0)
                return SaveResponseAlerta(RESPONSE.STATUS, message, numberOfMessage);
            else
                return SaveResponseSuccess(RESPONSE.STATUS, message, identifier);
        }

        private string SaveResponseAlerta(Status status, string message, NumberOfMessage numberOfMessage)
        {
            ConfigStatus.SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceError(message, RESPONSE.STATUS.SBELN, numberOfMessage);
        }

        private string SaveResponseSuccess(Status retornoWebService, string message, string sbeln)
        {
            ConfigStatus.SaveStatus(retornoWebService);
            return MessagesOfReturn.ProcessMessageSuccess(message, sbeln);
        }
    }
}
