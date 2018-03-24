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
            IDictionary<string, TPCK> dictionaryTcpkByXblnr = tpckDao.DictionaryByXblnr(embarque.ID);
            IList<Status> listStatus = new List<Status>();
            foreach (var itemTpck in RESPONSE.PCK)
            {
                string newDesc = "";
                if (dictionaryTcpkByXblnr.ContainsKey(itemTpck.XBLNR))
                {
                    dictionaryTcpkByXblnr[itemTpck.XBLNR].STATU = itemTpck.STATU;
                    newDesc = MessagesOfReturn.DescriptionUpdateXblnrSuccess(itemTpck.XBLNR, RESPONSE.STATUS.DESC);
                }else
                    newDesc = MessagesOfReturn.DescriptionUpdateXblnrNotFound(itemTpck.XBLNR, RESPONSE.STATUS.DESC);

                listStatus.Add(RESPONSE.STATUS.BuildsStatusWithNewDesc(newDesc));
            }

            tpckDao.Update();

            foreach (var itemStatus in listStatus)
                ConfigStatus.SaveStatus(itemStatus, embarque);

            return MessagesOfReturn.ProcessMessageSuccess(message, embarque.SBELN);
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
