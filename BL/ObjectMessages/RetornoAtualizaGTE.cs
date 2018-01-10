using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RetornoAtualizaGTE
    {
        [XmlAttribute]
        public string EDX;

        public ResponseAtualizaGTE RESPONSE;
    }

    public class ResponseAtualizaGTE
    {
        [XmlAttribute]
        public string Type;

        public Status STATUS;
    }
}
