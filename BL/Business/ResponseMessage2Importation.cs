using BL.ObjectMessages;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using BL.DAO;
using BL.InnerUtil;

namespace BL.Business
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseMessage2Importation : ISaveResponse
    {
        [XmlAttribute]
        public string EDX;

        public ResponseMsg2Importation RESPONSE;

        [XmlIgnore]
        public bool IsDatasComplete { get { return RESPONSE != null && RESPONSE.STATUS != null; } }

        public void AlterFlagChangeMessage(string sbeln, string kindOfMessage)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln, kindOfMessage);
            embarque.ConsultaDetalhe = false;
            dao.Update();
        }

        public string SaveDataBase(string identifier, string message, string kindOfMessage)
        {
            string msgReturn = "";
            NumberOfMessage numberOfMessage = NumberOfMessage.Two;

            ConfigStatus.ConfigureStatus(RESPONSE.STATUS, numberOfMessage, kindOfMessage, identifier);

            if (RESPONSE.MAIN != null && !string.IsNullOrEmpty(RESPONSE.MAIN.SBELN))
                msgReturn = SaveResponseSuccess(message, kindOfMessage);
            else
                msgReturn = SaveResponseAlerta(RESPONSE.STATUS, message, numberOfMessage);

            return msgReturn;
        }

        private string SaveResponseAlerta(Status status, string message, NumberOfMessage numberOfMessage)
        {
            ConfigStatus.SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceError(message, status.SBELN, numberOfMessage);
        }

        private string SaveResponseSuccess(string message, string kindOfMessage)
        {
            Embarque embarque = new EmbarqueDao().FindBySbeln(RESPONSE.MAIN.SBELN, kindOfMessage);
            MainDAO dao = new MainDAO();

            IList<MAIN> mainsSaved = dao.FindByIdEmbarqueLazy(embarque.ID);
            if (mainsSaved.Count > 0)
                dao.DeleteAll(mainsSaved);

            ConfigStatus.SaveStatus(RESPONSE.STATUS, embarque);
            RESPONSE.MAIN.Embarque = embarque;
            RESPONSE.MAIN.BUK = RESPONSE.BUK;
            RESPONSE.MAIN.PAR = RESPONSE.PAR;
            RESPONSE.MAIN.PARS = RESPONSE.PARS;
            RESPONSE.MAIN.DAT = RESPONSE.DAT;
            RESPONSE.MAIN.DI = RESPONSE.DI;
            RESPONSE.MAIN.BL = RESPONSE.BL;
            RESPONSE.MAIN.SHP = RESPONSE.SHP;
            RESPONSE.MAIN.SHP_TEXT_Main = RESPONSE.SHP_TEXT_Main;

            dao.Save(RESPONSE.MAIN);
            
            return MessagesOfReturn.ProcessMessageSuccess(message, embarque.SBELN);
        }
    }

    public class ResponseMsg2Importation
    {
        [XmlAttribute]
        public string Type { get; set; }

        public Status STATUS { get; set; }

        [XmlElement("MAIN")]
        public MAIN MAIN { get; set; }

        [XmlElement("BUK")]
        public List<BUK> BUK { get; set; }

        [XmlElement("PAR")]
        public List<PAR> PAR { get; set; }

        [XmlElement("PARS")]
        public List<PARS> PARS { get; set; }

        [XmlElement("DAT")]
        public List<DAT> DAT { get; set; }

        [XmlElement("DI")]
        public List<DI> DI { get; set; }

        [XmlElement("BL")]
        public List<BLImportation> BL { get; set; }

        [XmlElement("SHP")]
        public List<SHP> SHP { get; set; }

        [XmlElement("SHP_TEXT")]
        public List<SHP_TEXT_Main> SHP_TEXT_Main { get; set; }
    }
}
