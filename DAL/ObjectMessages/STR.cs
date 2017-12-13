using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    public class STR
    {
        [XmlAttribute]
        public string Type;

        public string XMLVR;

        public string ENVRM;

        public string INTNR;
    }
}
