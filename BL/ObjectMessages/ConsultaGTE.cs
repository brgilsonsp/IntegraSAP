using BL.ObjectMessages;
using System.Xml.Serialization;
using System.Linq;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class ConsultaGTE
    {
        [XmlAttribute]
        public string EDX;

        public RequestConsultaGTE REQUEST;

        public ConsultaGTE() {  }

        public ConsultaGTE(DataHeaderRequest dadosMessage1)
        {
            this.EDX = dadosMessage1.Cabecalho.MensagemEDX;
            REQUEST = new RequestConsultaGTE(dadosMessage1);
        }

        //public ConsultaGTE(DataHeaderRequest dadosMessage1, EmbarqueEntity embarque)
        public ConsultaGTE(DataHeaderRequest dadosMessage1, Embarque embarque)
        {
            this.EDX = dadosMessage1.Cabecalho.MensagemEDX;
            REQUEST = new RequestConsultaGTE(dadosMessage1, embarque);
        }
    }

    public class RequestConsultaGTE
    {
        [XmlAttribute]
        public string Type;

        public string ACAO;

        public string IDBR;

        public string IDCL;

        public string SHKEY;

        public STR STR;

        public string SBELN;
        
        [XmlIgnore]
        public int IDDadosBroker;

        public RequestConsultaGTE() {   }

        public RequestConsultaGTE(DataHeaderRequest dadosMessage1)
        {
            Type = dadosMessage1.Cabecalho.RequestType;
            ACAO = dadosMessage1.Cabecalho.ACAO;
            IDBR = dadosMessage1.DadosBroker.IDBR;
            IDCL = dadosMessage1.DadosBroker.IDCL;
            SHKEY = dadosMessage1.DadosBroker.SHKEY;
            STR = new STR(dadosMessage1.DadosBroker);
        }

        //public RequestConsultaGTE(DataHeaderRequest dadosMessage1, EmbarqueEntity embarque)
        public RequestConsultaGTE(DataHeaderRequest dadosMessage1, Embarque embarque)
            : this(dadosMessage1)
        {
            this.SBELN = embarque.SBELN;
        }
    }
}
