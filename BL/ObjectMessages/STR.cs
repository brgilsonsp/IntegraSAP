using BL.ObjectMessages;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class STR
    {
        [XmlAttribute]
        public string Type;

        public string XMLVR;

        public string ENVRM;

        public string INTNR;

        public STR() {   }

        public STR(DadosBroker dadosBroker)
        {
            Type = dadosBroker.STRType;
            XMLVR = dadosBroker.XMLVR;
            ENVRM = dadosBroker.ENVRM;
            INTNR = dadosBroker.INTNR;
        }
    }
}
