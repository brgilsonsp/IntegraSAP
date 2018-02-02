using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class II
    {
        #region only DB
        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDTTAX")]
        public int TTAXID { get; set; }

        [XmlIgnore]
        public virtual TTAX TTAX { get; set; }

        #endregion

        #region private

        private string _type;
        private string _base;
        private string _taxval;
        private string _taxpay;
        private string _rate;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string BASE { get { return ConverterValue.StringNullToEmpty(this._base); } set { this._base = value; } }

        public string TAXVAL { get { return ConverterValue.StringNullToEmpty(this._taxval); } set { this._taxval = value; } }

        public string TAXPAY { get { return ConverterValue.StringNullToEmpty(this._taxpay); } set { this._taxpay = value; } }

        public string RATE { get { return ConverterValue.StringNullToEmpty(this._rate); } set { this._rate = value; } }
        
    }
}
