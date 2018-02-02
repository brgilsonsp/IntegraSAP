using BL.ObjectMessages;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using BL.InnerUtil;
using BL.DAO;

namespace BL.Business
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseMessage2Exportation : ISaveResponse
    {
        [XmlAttribute]
        public string EDX;

        public ResponseMsg2Exportation RESPONSE;

        [XmlIgnore]
        public bool IsDatasComplete { get { return RESPONSE != null && RESPONSE.STATUS != null; } }

        public string SaveDataBase(string identifier, string message, string kindOfMessage)
        {
            string msgReturn = "";
            NumberOfMessage numberOfMessage = NumberOfMessage.Two;

            ConfigStatus.ConfigureStatus(RESPONSE.STATUS, numberOfMessage, kindOfMessage, identifier);

            if (RESPONSE.TGTESHK_N != null && !string.IsNullOrEmpty(RESPONSE.TGTESHK_N.SBELN))
                msgReturn = SaveResponseSuccess(message, kindOfMessage);
            else
                msgReturn = SaveResponseAlerta(RESPONSE.STATUS, message, numberOfMessage);

            return msgReturn;
        }

        public void AlterFlagChangeMessage(string sbeln, string kindOfMessage)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln, kindOfMessage);
            embarque.ConsultaDetalhe = false;
            dao.Update();
        }

        private string SaveResponseAlerta(Status status, string message, NumberOfMessage numberOfMessage)
        {
            ConfigStatus.SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceError(message, status.SBELN, numberOfMessage);
        }

        private string SaveResponseSuccess(string message, string kindOfMessage)
        {
            Embarque embarque = new EmbarqueDao().FindBySbeln(RESPONSE.TGTESHK_N.SBELN, kindOfMessage);

            ConfigStatus.SaveStatus(RESPONSE.STATUS, embarque);

            TGTESHK_NDao dao = new TGTESHK_NDao();

            IList<TGTESHK_N> list = dao.FindByIdEmbarqueLazy(embarque.ID);
            if (list.Count > 0)
                dao.DeleteAll(list);
            
            RESPONSE.TGTESHK_N.TGTESHP_N = RESPONSE.TGTESHP_N;
            RESPONSE.TGTESHK_N.TGTERES = RESPONSE.TGTERES;
            RESPONSE.TGTESHK_N.TGTEPRD = RESPONSE.TGTEPRD;
            RESPONSE.TGTESHK_N.SHP_TEXT = RESPONSE.SHP_TEXT;
            RESPONSE.TGTESHK_N.TGTEDUEK = RESPONSE.TGTEDUEK;
            RESPONSE.TGTESHK_N.TGTEDUEP = RESPONSE.TGTEDUEP;

            RESPONSE.TGTESHK_N.Embarque = embarque;
            RESPONSE.TGTESHK_N.TGTESHP_N.ForEach(t => t.Embarque = embarque);
            RESPONSE.TGTESHK_N.TGTERES.ForEach(t => t.Embarque = embarque);
            RESPONSE.TGTESHK_N.TGTEPRD.ForEach(t => t.Embarque = embarque);
            RESPONSE.TGTESHK_N.SHP_TEXT.ForEach(t => t.Embarque = embarque);
            RESPONSE.TGTESHK_N.TGTEDUEK.ForEach(t => t.Embarque = embarque);
            RESPONSE.TGTESHK_N.TGTEDUEP.ForEach(t => t.Embarque = embarque);

            dao.Save(RESPONSE.TGTESHK_N);
            
            return MessagesOfReturn.ProcessMessageSuccess(message, embarque.SBELN);
        }
    }

    public class ResponseMsg2Exportation
    {
        [XmlAttribute]
        public string Type;

        public Status STATUS;

        public TGTESHK_N TGTESHK_N;

        [XmlElement("TGTESHP_N")]
        public List<TGTESHP_N> TGTESHP_N;

        [XmlElement("TGTERES")]
        public List<TGTERES> TGTERES;

        [XmlElement("TGTEPRD")]
        public List<TGTEPRD> TGTEPRD;

        [XmlElement("SHP_TEXT")]
        public List<SHP_TEXT> SHP_TEXT;

        [XmlElement("TGTEDUEK")]
        public List<TGTEDUEK> TGTEDUEK;

        [XmlElement("TGTEDUEP")]
        public List<TGTEDUEP> TGTEDUEP;
    }
}
