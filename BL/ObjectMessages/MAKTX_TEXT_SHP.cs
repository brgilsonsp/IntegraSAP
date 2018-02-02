using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class MAKTX_TEXT_SHP
    {

        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDSHP")]
        public int SHPID { get; set; }

        [XmlIgnore]
        public virtual SHP SHP { get; set; }

        #endregion

        #region private

        private string _type;
        private string _text;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string TEXT { get { return ConverterValue.StringNullToEmpty(this._text); } set { this._text = value; } }
        
    }
}
