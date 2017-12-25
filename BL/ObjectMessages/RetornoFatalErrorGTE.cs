using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RetornoFatalErrorGTE
    {
        [XmlAttribute]
        public string versao;

        public ResponseError RESPONSE;
    }

    public class ResponseError
    {
        public Status STATUS;

    }

}
