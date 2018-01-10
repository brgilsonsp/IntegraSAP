using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class ADDRESS_TAB_TGTEDUEK
    {

        #region only db

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDTGTEDUEK")]
        public int TGTEDUEKID { get; set; }

        [XmlIgnore]
        public virtual TGTEDUEK TGTEDUEK { get; set; }

        [XmlIgnore]
        [Column("LINESEQ")]
        public int? LINESEQDB { get { return this._lineseq; } set { this._lineseq = value; } }

        #endregion

        #region private

        private string _dueid;
        private string _adrnr;
        private int? _lineseq;
        private string _content;

        #endregion
        
        [XmlAttribute]
        public string Type { get; set; }

        public string DUEID { get { return ConverterValue.StringNullToEmpty(this._dueid); } set { this._dueid = value; } }

        public string ADRNR { get { return ConverterValue.StringNullToEmpty(this._adrnr); } set { this._adrnr = value; } }

        [NotMapped]
        public string LINESEQ { get { return ConverterValue.IntNullableToString(this._lineseq); } set { this._lineseq = ConverterValue.StringToIntNullable(value); } }

        public string CONTENT { get { return ConverterValue.StringNullToEmpty(this._content); } set { this._content = value; } }
    }
}
