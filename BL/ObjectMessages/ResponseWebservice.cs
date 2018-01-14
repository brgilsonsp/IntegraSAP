using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class ResponseWebservice
    {
        [XmlAttribute]
        public string Type;

        public Status STATUS;
    }
}
