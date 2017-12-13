using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class ConsultaGTE
    {
        [XmlAttribute]
        public string EDX;

        public RequestConsultaGTE REQUEST;

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
    }
}
