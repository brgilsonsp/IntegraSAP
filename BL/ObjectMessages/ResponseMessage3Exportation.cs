using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseMessage3Exportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseWebservice RESPONSE { get; set; }
    }
}
