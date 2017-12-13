using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    public class TGTEPRD
    {
        [XmlAttribute]
        public string Type;
        
        public string PARVW;

        public string PARID;

        public string NAME1;

        public string NAME2;

        public string STREET;

        public string HOUSE_NUM1;

        public string HOUSE_NUM2;

        public string POSTE_CODE1;

        public string CITY1;

        public string CITY2;

        public string PSTLZ;

        public string REGION;

        public string COUNTRY;

        public string STCD1;

        public string STCD3;

        public string STCD4;
    }
}
