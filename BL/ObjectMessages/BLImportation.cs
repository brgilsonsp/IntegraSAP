using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class BLImportation
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
        private string _blnum;
        private string _loadtp;
        private string _shpnam;
        private string _lndvls;
        private string _mantyp;
        private string _mannum;
        private string _hsnum;
        private string _hsdat;
        private string _cargut;
        private string _zlando;
        private string _lndaqui;
        private string _cargag;
        private string _fcllcl;
        private string _vslown;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string BLNUM { get { return ConverterValue.StringNullToEmpty(this._blnum); } set { this._blnum = value; } }

        public string LOADTP { get { return ConverterValue.StringNullToEmpty(this._loadtp); } set { this._loadtp = value; } }

        public string SHPNAM { get { return ConverterValue.StringNullToEmpty(this._shpnam); } set { this._shpnam = value; } }

        public string LNDVLS { get { return ConverterValue.StringNullToEmpty(this._lndvls); } set { this._lndvls = value; } }

        public string MANTYP { get { return ConverterValue.StringNullToEmpty(this._mantyp); } set { this._mantyp = value; } }

        public string MANNUM { get { return ConverterValue.StringNullToEmpty(this._mannum); } set { this._mannum = value; } }

        public string HSNUM { get { return ConverterValue.StringNullToEmpty(this._hsnum); } set { this._hsnum = value; } }

        public string HSDAT { get { return ConverterValue.StringNullToEmpty(this._hsdat); } set { this._hsdat = value; } }

        public string CARGUT { get { return ConverterValue.StringNullToEmpty(this._cargut); } set { this._cargut = value; } }

        public string ZLANDO { get { return ConverterValue.StringNullToEmpty(this._zlando); } set { this._zlando = value; } }

        public string LNDAQUI { get { return ConverterValue.StringNullToEmpty(this._lndaqui); } set { this._lndaqui = value; } }

        public string CARGAG { get { return ConverterValue.StringNullToEmpty(this._cargag); } set { this._cargag = value; } }

        public string FCLLCL { get { return ConverterValue.StringNullToEmpty(this._fcllcl); } set { this._fcllcl = value; } }

        public string VSLOWN { get { return ConverterValue.StringNullToEmpty(this._vslown); } set { this._vslown = value; } }
        
    }
}
