using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class DAT
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
        private string _dirdat;
        private string _etadat;
        private string _etpdat;
        private string _etddat;
        private string _atrdat;
        private string _fumdat;
        private string _remdat;
        private string _loadat;
        private string _nfgdat;
        private string _nfcdat;
        private string _plndat;
        private string _eindt;
        private string _deldat;
        private string _clrdat;
        private string _ovrddt;
        private string _ovradt;
        private string _recdocorg;
        private string _ecertorg;
        private string _prescargadat;
        private string _insdat;
        private string _recdat;
        private string _bldat;
        private string _etdpdt;
        private string _alcdat;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string DIRDAT { get { return ConverterValue.StringNullToEmpty(this._dirdat); } set { this._dirdat = value; } }

        public string ETADAT { get { return ConverterValue.StringNullToEmpty(this._etadat); } set { this._etadat = value; } }

        public string ETPDAT { get { return ConverterValue.StringNullToEmpty(this._etpdat); } set { this._etpdat = value; } }

        public string ETDDAT { get { return ConverterValue.StringNullToEmpty(this._etddat); } set { this._etddat = value; } }

        public string ATRDAT { get { return ConverterValue.StringNullToEmpty(this._atrdat); } set { this._atrdat = value; } }

        public string FUMDAT { get { return ConverterValue.StringNullToEmpty(this._fumdat); } set { this._fumdat = value; } }

        public string REMDAT { get { return ConverterValue.StringNullToEmpty(this._remdat); } set { this._remdat = value; } }

        public string LOADAT { get { return ConverterValue.StringNullToEmpty(this._loadat); } set { this._loadat = value; } }

        public string NFGDAT { get { return ConverterValue.StringNullToEmpty(this._nfgdat); } set { this._nfgdat = value; } }

        public string NFCDAT { get { return ConverterValue.StringNullToEmpty(this._nfcdat); } set { this._nfcdat = value; } }

        public string PLNDAT { get { return ConverterValue.StringNullToEmpty(this._plndat); } set { this._plndat = value; } }

        public string EINDT { get { return ConverterValue.StringNullToEmpty(this._eindt); } set { this._eindt = value; } }

        public string DELDAT { get { return ConverterValue.StringNullToEmpty(this._deldat); } set { this._deldat = value; } }

        public string CLRDAT { get { return ConverterValue.StringNullToEmpty(this._clrdat); } set { this._clrdat = value; } }

        public string OVRDDT { get { return ConverterValue.StringNullToEmpty(this._ovrddt); } set { this._ovrddt = value; } }

        public string OVRADT { get { return ConverterValue.StringNullToEmpty(this._ovradt); } set { this._ovradt = value; } }

        public string RECDOCORG { get { return ConverterValue.StringNullToEmpty(this._recdocorg); } set { this._recdocorg = value; } }

        public string ECERTORG { get { return ConverterValue.StringNullToEmpty(this._ecertorg); } set { this._ecertorg = value; } }

        public string PRESCARGADAT { get { return ConverterValue.StringNullToEmpty(this._prescargadat); } set { this._prescargadat = value; } }

        public string INSDAT { get { return ConverterValue.StringNullToEmpty(this._insdat); } set { this._insdat = value; } }

        public string RECDAT { get { return ConverterValue.StringNullToEmpty(this._recdat); } set { this._recdat = value; } }

        public string BLDAT { get { return ConverterValue.StringNullToEmpty(this._bldat); } set { this._bldat = value; } }

        public string ETDPDT { get { return ConverterValue.StringNullToEmpty(this._etdpdt); } set { this._etdpdt = value; } }

        public string ALCDAT { get { return ConverterValue.StringNullToEmpty(this._alcdat); } set { this._alcdat = value; } }
    }
}
