using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class SERNR
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDCHARGS")]
        public int CHARGSID { get; set; }

        [XmlIgnore]
        public virtual CHARGS CHARGS { get; set; }
        #endregion

        #region private

        private string _type;
        private string _sernri;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        [Column("SERNR")]
        [XmlElement(ElementName = "SERNR")]
        public string SERNRI { get { return ConverterValue.StringNullToEmpty(this._sernri); } set { this._sernri = value; } }

    }
}
