using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot("EDX")]
    public class ResponseMessage5Exportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseMsg5 RESPONSE;

    }

    public class ResponseMsg5
    {
        [XmlAttribute]
        public string Type { get; set; }

        public Status STATUS;

        [XmlElement(ElementName = "TPCK")]
        public List<TPCK> PCK;
    }
}
