using BL.ObjectMessages;
using System.Xml.Serialization;
using System;
using BL.DAO;
using BL.InnerUtil;

namespace BL.Business
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseMessage3 : ISaveResponse
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
            embarque.AtualizaDetalhe = false;
            dao.Update();
        }

        public string SaveDataBase(string identifier, string message, string kindOfMessage)
        {
            NumberOfMessage numberOfMessage = NumberOfMessage.Three;
            ConfigStatus. ConfigureStatus(RESPONSE.STATUS, numberOfMessage, kindOfMessage, identifier);
            
            if (RESPONSE.STATUS.ERRORS != null && RESPONSE.STATUS.ERRORS.Count > 0)
                return SaveResponseAlerta(identifier, message, numberOfMessage);
            else
                return SaveResponseSuccess(identifier, message);
        }

        private string SaveResponseAlerta(string identifier, string message, NumberOfMessage numberOfMessage)
        {
            ConfigStatus.SaveStatus(RESPONSE.STATUS);
            return MessagesOfReturn.AlertResponseWebServiceError(message, identifier, numberOfMessage);
        }

        private string SaveResponseSuccess(string identifier, string message)
        {
            ConfigStatus.SaveStatus(RESPONSE.STATUS);

            return MessagesOfReturn.ProcessMessageSuccess(message, identifier);
        }
    }
}
