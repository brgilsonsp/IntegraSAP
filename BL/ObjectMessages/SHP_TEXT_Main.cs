using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class SHP_TEXT_Main
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDMain")]
        public int MAINID { get; set; }

        [XmlIgnore]
        public virtual MAIN Main { get; set; }

        #endregion

        #region private

        private string _type;
        private string _tdid;
        private string _tdline;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string TDID { get { return ConverterValue.StringNullToEmpty(this._tdid); } set { this._tdid = value; } }

        public string TDLINE { get { return ConverterValue.StringNullToEmpty(this._tdline); } set { this._tdline = value; } }
        
    }
}
