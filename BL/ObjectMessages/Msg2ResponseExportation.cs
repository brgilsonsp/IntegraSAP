using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class Msg2ResponseExportation
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
