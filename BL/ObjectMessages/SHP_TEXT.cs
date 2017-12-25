using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class SHP_TEXT
    {

        #region XmlIgonre

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }
        #endregion


        [XmlAttribute]
        [Column("TypeSHPTEX")]
        public string Type { get; set; }

        public string TDID { get; set; }

        public string TDLINE { get; set; }
    }
}
