using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage4
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestMsg4 REQUEST { get; set; }
    }

    public class RequestMsg4
    {
        [XmlAttribute]
        public string Type { get; set; }

        public string ACAO { get; set; }

        public string IDBR { get; set; }

        public string IDCL { get; set; }

        public string SHKEY { get; set; }

        public STR STR { get; set; }

        [XmlElement("PCK")]
        public TPCK PCK { get; set; }
    }
}
