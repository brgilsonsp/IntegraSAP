using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    public class SHPTEXT
    {
        [XmlAttribute]
        public string Type;
        
        public string TDID;

        public string TDLINE;
    }
}
