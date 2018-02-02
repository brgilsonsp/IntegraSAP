using BL.InnerUtil;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class DI
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
        private string _dinum;
        private string _imptyp;
        private string _moddesp;
        private string _urfdesp;
        private string _urfentr;
        private string _recalf;
        private string _insur;
        private string _inswr;
        private string _prepd;
        private string _collec;
        private string _prepwr;
        private string _lfreig;
        private string _lfrewr;
        private string _kurdi;
        private string _frert;
        private string _insrt;
        private string _canal;
        private string _refadm;
        private string _ufdesemb;
        private string _tpintermd;
        private string _perm_days;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }
        
        public string DINUM { get { return ConverterValue.StringNullToEmpty(this._dinum); } set { this._dinum = value; } }

        public string IMPTYP { get { return ConverterValue.StringNullToEmpty(this._imptyp); } set { this._imptyp = value; } }

        public string MODDESP { get { return ConverterValue.StringNullToEmpty(this._moddesp); } set { this._moddesp = value; } }

        public string URFDESP { get { return ConverterValue.StringNullToEmpty(this._urfdesp); } set { this._urfdesp = value; } }

        public string URFENTR { get { return ConverterValue.StringNullToEmpty(this._urfentr); } set { this._urfentr = value; } }

        public string RECALF { get { return ConverterValue.StringNullToEmpty(this._recalf); } set { this._recalf = value; } }

        public string INSUR { get { return ConverterValue.StringNullToEmpty(this._insur); } set { this._insur = value; } }

        public string INSWR { get { return ConverterValue.StringNullToEmpty(this._inswr); } set { this._inswr = value; } }

        public string PREPD { get { return ConverterValue.StringNullToEmpty(this._prepd); } set { this._prepd = value; } }

        public string COLLEC { get { return ConverterValue.StringNullToEmpty(this._collec); } set { this._collec = value; } }

        public string PREPWR { get { return ConverterValue.StringNullToEmpty(this._prepwr); } set { this._prepwr = value; } }

        public string LFREIG { get { return ConverterValue.StringNullToEmpty(this._lfreig); } set { this._lfreig = value; } }

        public string LFREWR { get { return ConverterValue.StringNullToEmpty(this._lfrewr); } set { this._lfrewr = value; } }

        public string KURDI { get { return ConverterValue.StringNullToEmpty(this._kurdi); } set { this._kurdi = value; } }

        public string FRERT { get { return ConverterValue.StringNullToEmpty(this._frert); } set { this._frert = value; } }

        public string INSRT { get { return ConverterValue.StringNullToEmpty(this._insrt); } set { this._insrt = value; } }

        public string CANAL { get { return ConverterValue.StringNullToEmpty(this._canal); } set { this._canal = value; } }

        public string REFADM { get { return ConverterValue.StringNullToEmpty(this._refadm); } set { this._refadm = value; } }

        public string UFDESEMB { get { return ConverterValue.StringNullToEmpty(this._ufdesemb); } set { this._ufdesemb = value; } }

        public string TPINTERMD { get { return ConverterValue.StringNullToEmpty(this._tpintermd); } set { this._tpintermd = value; } }

        public string PERM_DAYS { get { return ConverterValue.StringNullToEmpty(this._perm_days); } set { this._perm_days = value; } }

        [XmlElement("XPNS")]
        public List<XPNS> XPNS { get; set; }

        [XmlElement("KURDIS")]
        public List<KURDIS> KURDIS { get; set; }

    }
}
