using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class ResponseFatalError
    {
        [XmlAttribute]
        public string versao;

        public ResponseError RESPONSE;
    }

    public class ResponseError
    {
        public string CODE { get; set; }
        
        public string DESC { get; set; }

    }

}
