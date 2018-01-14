using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseMessage4Exportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseWebservice RESPONSE { get; set; }
    }
}
