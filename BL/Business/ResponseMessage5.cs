using BL.ObjectMessages;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System;
using BL.DAO;
using BL.InnerUtil;

namespace BL.Business
{
    [XmlRoot("EDX")]
    public class ResponseMessage5 : ISaveResponse
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseMsg5 RESPONSE;

        [XmlIgnore]
        public bool IsDatasComplete { get { return RESPONSE != null && RESPONSE.STATUS != null; } }
                

        public string SaveDataBase(string identifier, string message, string kindOfMessage)
        {
            NumberOfMessage numberOfMessage = NumberOfMessage.Five;

            ConfigStatus.ConfigureStatus(RESPONSE.STATUS, numberOfMessage, kindOfMessage, identifier);

            if (RESPONSE.PCK != null && RESPONSE.PCK.Count > 0)
                return SaveResponseSuccess(message, kindOfMessage);
            else
                return SaveResponseAlerta(message, numberOfMessage);
        }

        public void AlterFlagChangeMessage(string sbeln, string kindOfMessage)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln, kindOfMessage);
            embarque.ConsultaPrestConta = false;
            dao.Update();
        }

        private string SaveResponseAlerta(string message, NumberOfMessage numberOfMessage)
        {
            ConfigStatus.SaveStatus(RESPONSE.STATUS);
            return MessagesOfReturn.AlertResponseWebServiceError(message, RESPONSE.STATUS.SBELN, numberOfMessage);
        }

        private string SaveResponseSuccess(string message, string kindOfMessage)
        {
            string sbeln = RESPONSE.PCK.FirstOrDefault(e => !string.IsNullOrEmpty(e.SBELN)).SBELN;
            TPCKDao tpckDao = new TPCKDao();

            Embarque embarque = new EmbarqueDao().FindBySbeln(sbeln, kindOfMessage);
            RemoveRecorded(embarque.ID, tpckDao);

            RESPONSE.PCK.ForEach(t => t.Embarque = embarque);
            tpckDao.SaveAll(RESPONSE.PCK);

            if (RESPONSE.STATUS != null)
                ConfigStatus.SaveStatus(RESPONSE.STATUS, embarque);

            return MessagesOfReturn.ProcessMessageSuccess(message, embarque.SBELN);
        }

        private void RemoveRecorded(int idEmbarque, TPCKDao tpckDao)
        {
            IList<TPCK> toRemove = tpckDao.FindByIdEmbarqueLazy(idEmbarque);
            if(toRemove != null && toRemove.Count > 0)
                tpckDao.DeleteAll(toRemove);
        }
    }

    public class ResponseMsg5
    {
        [XmlAttribute]
        public string Type { get; set; }

        public Status STATUS;

        [XmlElement(ElementName = "TPCK")]
        public List<TPCK> PCK;
    }
}
