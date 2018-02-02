using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class BUK
    {

        #region only DB
        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDMain")]
        public int MainID { get; set; }

        [XmlIgnore]
        public virtual MAIN Main { get; set; }

        #endregion

        #region private

        private string _type;
        private string _bukrs;
        private string _ekorg;
        private string _branch;
        private string _partyp;
        private string _csgne;

        #endregion


        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string BUKRS { get { return ConverterValue.StringNullToEmpty(this._bukrs); } set { this._bukrs = value; } }

        public string EKORG { get { return ConverterValue.StringNullToEmpty(this._ekorg); } set { this._ekorg = value; } }

        public string BRANCH { get { return ConverterValue.StringNullToEmpty(this._branch); } set { this._branch = value; } }

        public string PARTYP { get { return ConverterValue.StringNullToEmpty(this._partyp); } set { this._partyp = value; } }

        public string CSGNE { get { return ConverterValue.StringNullToEmpty(this._csgne); } set { this._csgne = value; } }
    }
}
