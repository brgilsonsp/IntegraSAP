using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage3Exportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequesExportationtMsg3 REQUEST { get; set; }
    }

    public class RequesExportationtMsg3
    {
        [XmlAttribute]
        public string Type { get; set; }

        public string ACAO { get; set; }

        public string IDBR { get; set; }

        public string IDCL { get; set; }

        public string SHKEY { get; set; }

        public STR STR { get; set; }

        [XmlElement("TGTESHK_N ")]
        public TGTESHK_N TGTESHK_N { get; set; }

        [XmlElement("TGTESHP_N")]
        public List<TGTESHP_N> TGTESHP_N { get; set; }

        [XmlElement("TGTERES")]
        public List<TGTERES> TGTERES { get; set; }

        [XmlElement("TGTEPRD")]
        public List<TGTEPRD> TGTEPRD { get; set; }

        [XmlElement("SHP_TEXT")]
        public List<SHP_TEXT> SHP_TEXT { get; set; }

        [XmlElement("TGTEDUEK")]
        public List<TGTEDUEK> TGTEDUEK { get; set; }

        [XmlElement("TGTEDUEP")]
        public List<TGTEDUEP> TGTEDUEP { get; set; }
    }
}
