using BL.ObjectMessages;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using BL.InnerUtil;
using BL.DAO;
using System.Linq;

namespace BL.Business
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseMessage1 : ISaveResponse
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseMsg1 RESPONSE { get; set; }

        [XmlIgnore]
        public bool IsDatasComplete { get { return RESPONSE != null && RESPONSE.ListaEmbarque != null && RESPONSE.STATUS != null; } }

        public string SaveDataBase(string idBroker, string message, string kindOfMessage)
        {
            NumberOfMessage numberOfMessage = NumberOfMessage.One;
            ConfigStatus.ConfigureStatus(RESPONSE.STATUS, numberOfMessage, kindOfMessage);
            AlimentaIdDadosBroker(int.Parse(idBroker));

            if (RESPONSE.ListaEmbarque != null && RESPONSE.ListaEmbarque.Embarques.Count > 0)
                return SaveResponseSuccess(message, kindOfMessage);
            else if (RESPONSE.STATUS != null)
                return SaveResponseAlerta(message, numberOfMessage);
            else // Se não recebeu nenhum Embarque do WebService
                return MessagesOfReturn.AlertResponseWebServiceError(message, idBroker, numberOfMessage);
        }

        private string SaveResponseSuccess(string message, string kindOfMessage)
        {
            EmbarqueDao dao = new EmbarqueDao();
            List<String> listSbeln = dao.GetListSbeln(kindOfMessage);
            string retorno = "";

            foreach (Embarque embarque in RESPONSE.ListaEmbarque.Embarques)
                if (!listSbeln.Contains(embarque.SBELN))
                {
                    embarque.Tipo = kindOfMessage;
                    dao.Save(embarque);
                }

            retorno += MessagesOfReturn.ProcessMessageOneSuccess(message, RESPONSE.ListaEmbarque.Embarques.FirstOrDefault().DadosBrokerID);

            return retorno;
        }

        private string SaveResponseAlerta(string message, NumberOfMessage numberOfMessage)
        {
            ConfigStatus.SaveStatus(RESPONSE.STATUS);
            return MessagesOfReturn.AlertResponseWebServiceError(message, RESPONSE.STATUS.idBroker.ToString(), numberOfMessage);
        }

        private void AlimentaIdDadosBroker(int idBroker)
        {
            if (RESPONSE != null && RESPONSE.ListaEmbarque != null)
                foreach (Embarque cadaEmbarque in RESPONSE.ListaEmbarque.Embarques)
                    cadaEmbarque.DadosBrokerID = idBroker;

            if (RESPONSE.STATUS != null)
                RESPONSE.STATUS.idBroker = idBroker;
        }

        public void AlterFlagChangeMessage(string sbeln, string kindOfMessage)
        {
            throw new NotImplementedException();
        }
    }

    public class ResponseMsg1
    {
        [XmlAttribute]
        public string Type { get; set; }

        public Status STATUS { get; set; }

        [XmlElement("TSHKS")]
        public ListaEmbarque ListaEmbarque { get; set; }
    }

    public class ListaEmbarque
    {
        [XmlAttribute]
        public string Type { get; set; }

        [XmlElement("TSHK")]
        public List<Embarque> Embarques { get; set; }
    }
}