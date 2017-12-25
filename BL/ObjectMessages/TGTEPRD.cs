using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class TGTEPRD
    {
        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        #endregion

        [XmlAttribute]
        [Column("TypeTGTEPRD")]
        public string Type { get; set; }

        public string PARVW { get; set; }

        public string PARID { get; set; }

        public string NAME1 { get; set; }

        public string NAME2 { get; set; }

        public string STREET { get; set; }

        public string HOUSE_NUM1 { get; set; }

        public string HOUSE_NUM2 { get; set; }

        [Column("POST_CODE1")]
        public string POSTE_CODE1 { get; set; }

        public string CITY1 { get; set; }

        public string CITY2 { get; set; }

        public string PSTLZ { get; set; }

        public string REGION { get; set; }

        public string COUNTRY { get; set; }

        public string STCD1 { get; set; }

        public string STCD3 { get; set; }

        public string STCD4 { get; set; }
        
    }
}
