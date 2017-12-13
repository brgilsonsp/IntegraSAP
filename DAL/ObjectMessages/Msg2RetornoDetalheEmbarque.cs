using System.Collections.Generic;
using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class Msg2RetornoDetalheEmbarque
    {
        [XmlAttribute]
        public string EDX;

        public ResponseMsg2 RESPONSE;
    }

    public class ResponseMsg2
    {
        [XmlAttribute]
        public string Type;

        public Status STATUS;

        public TGTESHKN TGTESHK_N;

        [XmlElement("TGTESHP_N")]
        public List<TGTESHPN> TGTESHP_N;

        [XmlElement("TGTERES")]
        public List<TGTERES> TGTERES;

        [XmlElement("TGTEPRD")]
        public List<TGTEPRD> TGTEPRD;

        [XmlElement("SHP_TEXT")]
        public List<SHPTEXT> SHP_TEXT;
    }
}
