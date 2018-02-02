using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class RequestWebservice
    {
        #region only DB

        [XmlIgnore]
        public int IDDadosBroker { get; set; }
        
        #endregion

        [XmlAttribute]
        public string Type { get; set; }

        public string ACAO { get; set; }

        public string IDBR { get; set; }

        public string IDCL { get; set; }

        public string SHKEY { get; set; }

        public STR STR { get; set; }

        public string SBELN { get; set; }


        public RequestWebservice() { }

        public RequestWebservice(DataHeaderRequest dadosMessage1)
        {
            Type = dadosMessage1.Cabecalho.RequestType;
            ACAO = dadosMessage1.Cabecalho.ACAO;
            IDBR = dadosMessage1.DadosBroker.IDBR;
            IDCL = dadosMessage1.DadosBroker.IDCL;
            SHKEY = dadosMessage1.DadosBroker.SHKEY;
            STR = new STR(dadosMessage1.DadosBroker);
        }

        public RequestWebservice(DataHeaderRequest dadosMessage1, Embarque embarque)
            : this(dadosMessage1)
        {
            SBELN = embarque.SBELN;
        }
    }
}
