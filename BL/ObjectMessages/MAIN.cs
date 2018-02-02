using BL.InnerUtil;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class MAIN
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        [XmlIgnore]
        public List<BUK> BUK { get; set; }

        [XmlIgnore]
        public List<PAR> PAR { get; set; }

        [XmlIgnore]
        public List<PARS> PARS { get; set; }

        [XmlIgnore]
        public List<DAT> DAT { get; set; }

        [XmlIgnore]
        public List<DI> DI { get; set; }

        [XmlIgnore]
        public List<BLImportation> BL { get; set; }

        [XmlIgnore]
        public List<SHP> SHP { get; set; }

        [XmlIgnore]
        public List<SHP_TEXT_Main> SHP_TEXT_Main { get; set; }

        #endregion

        #region private

        private string _type;
        private string _shipt;
        private string _credat;
        private string _crenam;
        private string _zterm;
        private string _inco1;
        private string _zollao;
        private string _zlando;
        private string _zollad;
        private string _zlandd;
        private string _kursp;
        private string _statu;
        private string _dityp;
        private string _bfmar;
        private string _broknm;
        private string _projn;
        private string _retda;
        private string _limdate;
        private string _shpclass;
        private string _cnpjadq;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        [NotMapped]
        public string SBELN { get; set; }

        public string SHIPT { get { return ConverterValue.StringNullToEmpty(this._shipt); } set { this._shipt = value; } }

        public string CREDAT { get { return ConverterValue.StringNullToEmpty(this._credat); } set { this._credat = value; } }

        public string CRENAM { get { return ConverterValue.StringNullToEmpty(this._crenam); } set { this._crenam = value; } }

        public string ZTERM { get { return ConverterValue.StringNullToEmpty(this._zterm); } set { this._zterm = value; } }

        public string INCO1 { get { return ConverterValue.StringNullToEmpty(this._inco1); } set { this._inco1 = value; } }

        public string ZOLLAO { get { return ConverterValue.StringNullToEmpty(this._zollao); } set { this._zollao = value; } }

        public string ZLANDO { get { return ConverterValue.StringNullToEmpty(this._zlando); } set { this._zlando = value; } }

        public string ZOLLAD { get { return ConverterValue.StringNullToEmpty(this._zollad); } set { this._zollad = value; } }

        public string ZLANDD { get { return ConverterValue.StringNullToEmpty(this._zlandd); } set { this._zlandd = value; } }

        public string KURSP { get { return ConverterValue.StringNullToEmpty(this._kursp); } set { this._kursp = value; } }

        public string STATU { get { return ConverterValue.StringNullToEmpty(this._statu); } set { this._statu = value; } }

        public string DITYP { get { return ConverterValue.StringNullToEmpty(this._dityp); } set { this._dityp = value; } }

        public string BFMAR { get { return ConverterValue.StringNullToEmpty(this._bfmar); } set { this._bfmar = value; } }

        public string BROKNM { get { return ConverterValue.StringNullToEmpty(this._broknm); } set { this._broknm = value; } }

        public string PROJN { get { return ConverterValue.StringNullToEmpty(this._projn); } set { this._projn = value; } }

        public string RETDA { get { return ConverterValue.StringNullToEmpty(this._retda); } set { this._retda = value; } }

        public string LIMDATE { get { return ConverterValue.StringNullToEmpty(this._limdate); } set { this._limdate = value; } }

        public string SHPCLASS { get { return ConverterValue.StringNullToEmpty(this._shpclass); } set { this._shpclass = value; } }

        public string CNPJADQ { get { return ConverterValue.StringNullToEmpty(this._cnpjadq); } set { this._cnpjadq = value; } }
        
    }
}
