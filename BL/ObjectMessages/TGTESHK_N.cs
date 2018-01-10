using System;
using System.Xml.Serialization;
using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    /// <summary>
    /// Essa classe possui propriedades redundantes. 
    /// Quando a propriedade possui a anotação NotMapped, ela será utilizada apenas para o XML, sendo assim ela mantem
    /// o nome que foi definida na documentação (fornecida pela E-IT), porém quando a propriedade
    /// utiliza as anotações XmlIgnore e Column("NomeColuna") ela é utilizada apenas pelo banco de dados e foi inserido
    /// um sufixo DB. Foi criado também uma variável privada afim de tratar o retorno para o XML,
    /// pois a E-IT necessita de todos campos no arquivo XML, mesmo null, sendo assim, se o valor no banco de dados for null
    /// ele retornará uma string vazia, afim de gerar a tag no XML
    /// </summary>
    public class TGTESHK_N
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
        [Column("NETWR")]
        public decimal? NETWRDB { get { return this._netwr; } set { this._netwr = value; } }

        [XmlIgnore]
        [Column("VOLUM")]
        public decimal? VOLUMDB { get { return this._volum; } set { this._volum = value; } }

        [XmlIgnore]
        [Column("NTGEW")]
        public decimal? NTGEWDB { get { return this._ntgew; } set { this._ntgew = value; } }

        [XmlIgnore]
        [Column("BRGEW")]
        public decimal? BRGEWDB { get { return this._brgew; } set { this._brgew = value; } }

        [XmlIgnore]
        [Column("VLFRETE")]
        public decimal? VLFRETEDB { get { return this._vlfrete; } set { this._vlfrete = value; } }

        [XmlIgnore]
        [Column("VLSEGURO")]
        public decimal? VLSEGURODB { get { return this._vlseguro; } set { this._vlseguro = value; } }

        [XmlIgnore]
        [Column("VLCOAGT")]
        public decimal? VLCOAGTDB { get { return this._vlcoagt; } set { this._vlcoagt = value; } }

        [XmlIgnore]
        [Column("PCCOAGT")]
        public decimal? PCCOAGTDB { get { return this._pccoagt; } set { this._pccoagt = value; } }
        
        [XmlIgnore]
        [Column("SEDAT")]
        public DateTime? SEDATDB { get { return this._sedat; } set { this._sedat = value; } }

        [XmlIgnore]
        [Column("ETADT")]
        public DateTime? ETADTDB { get { return this._etadt; } set { this._etadt = value; } }

        [XmlIgnore]
        [Column("ENVDT")]
        public DateTime? ENVDTDB { get { return this._envdt; } set { this._envdt = value; } }

        [XmlIgnore]
        [Column("PREVDT")]
        public DateTime? PREVDTDB { get { return this._prevdt; } set { this._prevdt = value; } }

        [XmlIgnore]
        [Column("ETDDT")]
        public DateTime? ETDDTDB { get { return this._etddt; } set { this._etddt = value; } }

        [XmlIgnore]
        [Column("BLDTA")]
        public DateTime? BLDTADB { get { return this._bldta; } set { this._bldta = value; } }

        [XmlIgnore]
        [Column("DT_INVNR")]
        public DateTime? DT_INVNRDB { get { return this._dt_invnr; } set { this._dt_invnr = value; } }

        [XmlIgnore]
        [Column("DTCLTC")]
        public DateTime? DTCLTCDB { get { return this._dtcltc; } set { this._dtcltc = value; } }

        [XmlIgnore]
        [Column("DTEARM")]
        public DateTime? DTEARMDB { get { return this._dtearm; } set { this._dtearm = value; } }

        [XmlIgnore]
        [Column("DTENTC")]
        public DateTime? DTENTCDB { get { return this._dtentc; } set { this._dtentc = value; } }

        [XmlIgnore]
        [Column("DTCOLETA")]
        public DateTime? DTCOLETADB { get { return this._dtcoleta; } set { this._dtcoleta = value; } }

        [XmlIgnore]
        [Column("DTCHGARM")]
        public DateTime? DTCHGARMDB { get { return this._dtchgarm; } set { this._dtchgarm = value; } }

        [XmlIgnore]
        [Column("DTPRESC")]
        public DateTime? DTPRESCDB { get { return this._dtpresc; } set { this._dtpresc = value; } }

        [XmlIgnore]
        [Column("DTAVERB")]
        public DateTime? DTAVERBDB { get { return this._dtaverb; } set { this._dtaverb = value; } }

        [XmlIgnore]
        [Column("DTENTREGA")]
        public DateTime? DTENTREGADB { get { return this._dtentrega; } set { this._dtentrega = value; } }

        [XmlIgnore]
        [Column("DTBOOK")]
        public DateTime? DTBOOKDB { get { return this._dtbook; } set { this._dtbook = value; } }

        [XmlIgnore]
        [Column("DTSHIP")]
        public DateTime? DTSHIPDB { get { return this._dtship; } set { this._dtship = value; } }

        [XmlIgnore]
        [Column("DTCE")]
        public DateTime? DTCEDB { get { return this._dtce; } set { this._dtce = value; } }

        #endregion
        

        #region private

        private decimal? _netwr;
        private decimal? _volum;
        private decimal? _ntgew;
        private decimal? _brgew;
        private decimal? _vlfrete;
        private decimal? _vlseguro;
        private decimal? _vlcoagt;
        private decimal? _pccoagt;
        private DateTime? _sedat;
        private DateTime? _etadt;
        private DateTime? _envdt;
        private DateTime? _prevdt;
        private DateTime? _etddt;
        private DateTime? _bldta;
        private DateTime? _dt_invnr;
        private DateTime? _dtcltc;
        private DateTime? _dtearm;
        private DateTime? _dtentc;
        private DateTime? _dtcoleta;
        private DateTime? _dtchgarm;
        private DateTime? _dtpresc;
        private DateTime? _dtaverb;
        private DateTime? _dtentrega;
        private DateTime? _dtbook;
        private DateTime? _dtship;
        private DateTime? _dtce;
        private string _locse;
        private string _tipse;
        private string _tsetmp;
        private string _trans;        
        private string _zollao;
        private string _zlando;
        private string _zollad;
        private string _zlandd;
        private string _waersrf;
        private string _inco1;
        private string _zterm;
        private string _sestat;
        private string _waers;
        private string _bfmar;
        private string _shptrip;
        private string _blnmb;
        private string _hsawb;
        private string _shpnam;
        private string _invnr;
        private string _moedafrt;
        private string _moedasgr;
        private string _moedacoagt;
        private string _tpcoagt;
        private string _urfdesp;
        private string _urfemba;
        private string _modpag;
        private string _bascom;
        private string _preclct;
        private string _broknm;
        private string _nmbook;
        private string _tpveic;
        private string _tpcarg;
        private string _ufembarq;
        private string _instneg;
        private string _tpprp;
        private string _nroce;

        #endregion


        [XmlAttribute]
        [Column("TypeTGTESHKN")]
        public string Type { get; set; }

        [NotMapped]
        public string SBELN { get; set; }
        
        public string LOCSE { get { return ConverterValue.StringNullToEmpty(this._locse); } set { this._locse = value; } }
        
        public string TIPSE { get { return ConverterValue.StringNullToEmpty(this._tipse); } set { this._tipse = value; } }

        public string TSETMP { get { return ConverterValue.StringNullToEmpty(this._tsetmp); } set { this._tsetmp = value; } }

        [NotMapped]
        public string SEDAT { get { return ConverterValue.DateTimeNullableForString(this._sedat); } set { this._sedat = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string ETADT { get { return ConverterValue.DateTimeNullableForString(this._etadt); } set { this._etadt = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string ENVDT { get { return ConverterValue.DateTimeNullableForString(this._envdt); } set { this._envdt = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string PREVDT { get { return ConverterValue.DateTimeNullableForString(this._prevdt); } set { this._prevdt = ConverterValue.StringForDateTimeNullable(value); } }
        
        public string TRANS { get { return ConverterValue.StringNullToEmpty(this._trans); } set { this._trans = value; } }

        public string ZOLLAO { get { return ConverterValue.StringNullToEmpty(this._zollao); } set { this._zollao = value; } }

        public string ZLANDO { get { return ConverterValue.StringNullToEmpty(this._zlando); } set { this._zlando = value; } }

        public string ZOLLAD { get { return ConverterValue.StringNullToEmpty(this._zollad); } set { this._zollad = value; } }

        public string ZLANDD { get { return ConverterValue.StringNullToEmpty(this._zlandd); } set { this._zlandd = value; } }

        [NotMapped]
        public string NETWR { get { return ConverterValue.DecimalNullableToString(this._netwr); } set { this._netwr = ConverterValue.StringToDecimalNullable(value); } }

        public string WAERSRF { get { return ConverterValue.StringNullToEmpty(this._waersrf); } set { this._waersrf = value; } }

        public string INCO1 { get { return ConverterValue.StringNullToEmpty(this._inco1); } set { this._inco1 = value; } }

        public string ZTERM { get { return ConverterValue.StringNullToEmpty(this._zterm); } set { this._zterm = value; } }

        public string SESTAT { get { return ConverterValue.StringNullToEmpty(this._sestat); } set { this._sestat = value; } }

        public string WAERS { get { return ConverterValue.StringNullToEmpty(this._waers); } set { this._waers = value; } }

        public string BFMAR { get { return ConverterValue.StringNullToEmpty(this._bfmar); } set { this._bfmar = value; } }

        public string SHPTRIP { get { return ConverterValue.StringNullToEmpty(this._shptrip); } set { this._shptrip = value; } }

        [NotMapped]
        public string ETDDT { get { return ConverterValue.DateTimeNullableForString(this._etddt); } set { this._etddt = ConverterValue.StringForDateTimeNullable(value); } }

        public string BLNMB { get { return ConverterValue.StringNullToEmpty(this._blnmb); } set { this._blnmb = value; } }

        [NotMapped]
        public string BLDTA { get { return ConverterValue.DateTimeNullableForString(this._bldta); } set { this._bldta = ConverterValue.StringForDateTimeNullable(value); } }

        public string HSAWB { get { return ConverterValue.StringNullToEmpty(this._hsawb); } set { this._hsawb = value; } }

        public string SHPNAM { get { return ConverterValue.StringNullToEmpty(this._shpnam); } set { this._shpnam = value; } }

        public string INVNR { get { return ConverterValue.StringNullToEmpty(this._invnr); } set { this._invnr = value; } }
        
        [NotMapped]
        public string DT_INVNR { get { return ConverterValue.DateTimeNullableForString(this._dt_invnr); } set { this._dt_invnr = ConverterValue.StringForDateTimeNullable(value); } }
        
        [NotMapped]
        public string VOLUM { get { return ConverterValue.DecimalNullableToString(this._volum); } set { this._volum = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string NTGEW { get { return ConverterValue.DecimalNullableToString(this._ntgew); } set { this._ntgew = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string BRGEW { get { return ConverterValue.DecimalNullableToString(this._brgew); } set { this._brgew = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string VLFRETE { get { return ConverterValue.DecimalNullableToString(this._vlfrete); } set { this._vlfrete = ConverterValue.StringToDecimalNullable(value); } }

        public string MOEDAFRT { get { return ConverterValue.StringNullToEmpty(this._moedafrt); } set { this._moedafrt = value; } }

        [NotMapped]
        public string VLSEGURO { get { return ConverterValue.DecimalNullableToString(this._vlseguro); } set { this._vlseguro = ConverterValue.StringToDecimalNullable(value); } }

        public string MOEDASGR { get { return ConverterValue.StringNullToEmpty(this._moedasgr); } set { this._moedasgr = value; } }

        [NotMapped]
        public string VLCOAGT { get { return ConverterValue.DecimalNullableToString(this._vlcoagt); } set { this._vlcoagt = ConverterValue.StringToDecimalNullable(value); } }

        public string MOEDACOAGT { get { return ConverterValue.StringNullToEmpty(this._moedacoagt); } set { this._moedacoagt = value; } }

        [NotMapped]
        public string PCCOAGT { get { return ConverterValue.DecimalNullableToString(this._pccoagt); } set { this._pccoagt = ConverterValue.StringToDecimalNullable(value); } }

        public string TPCOAGT { get { return ConverterValue.StringNullToEmpty(this._tpcoagt); } set { this._tpcoagt = value; } }

        [NotMapped]
        public string DTCLTC { get { return ConverterValue.DateTimeNullableForString(this._dtcltc); } set { this._dtcltc = ConverterValue.StringForDateTimeNullable(value); } }
        
        [NotMapped]
        public string DTEARM { get { return ConverterValue.DateTimeNullableForString(this._dtearm); } set { this._dtearm = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string DTENTC { get { return ConverterValue.DateTimeNullableForString(this._dtentc); } set { this._dtentc = ConverterValue.StringForDateTimeNullable(value); } }
        
        public string URFDESP { get { return ConverterValue.StringNullToEmpty(this._urfdesp); } set { this._urfdesp = value; } }

        public string URFEMBA { get { return ConverterValue.StringNullToEmpty(this._urfemba); } set { this._urfemba = value; } }

        public string MODPAG { get { return ConverterValue.StringNullToEmpty(this._modpag); } set { this._modpag = value; } }

        public string BASCOM { get { return ConverterValue.StringNullToEmpty(this._bascom); } set { this._bascom = value; } }

        public string PRECLCT { get { return ConverterValue.StringNullToEmpty(this._preclct); } set { this._preclct = value; } }

        [NotMapped]
        public string DTCOLETA { get { return ConverterValue.DateTimeNullableForString(this._dtcoleta); } set { this._dtcoleta = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string DTCHGARM { get { return ConverterValue.DateTimeNullableForString(this._dtchgarm); } set { this._dtchgarm = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string DTPRESC { get { return ConverterValue.DateTimeNullableForString(this._dtpresc); } set { this._dtpresc = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string DTAVERB { get { return ConverterValue.DateTimeNullableForString(this._dtaverb); } set { this._dtaverb = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string DTENTREGA { get { return ConverterValue.DateTimeNullableForString(this._dtentrega); } set { this._dtentrega = ConverterValue.StringForDateTimeNullable(value); } }

        public string BROKNM { get { return ConverterValue.StringNullToEmpty(this._broknm); } set { this._broknm = value; } }

        public string NMBOOK { get { return ConverterValue.StringNullToEmpty(this._nmbook); } set { this._nmbook = value; } }

        [NotMapped]
        public string DTBOOK { get { return ConverterValue.DateTimeNullableForString(this._dtbook); } set { this._dtbook = ConverterValue.StringForDateTimeNullable(value); } }

        public string TPVEIC { get { return ConverterValue.StringNullToEmpty(this._tpveic); } set { this._tpveic = value; } }

        public string TPCARG { get { return ConverterValue.StringNullToEmpty(this._tpcarg); } set { this._tpcarg = value; } }

        public string UFEMBARQ { get { return ConverterValue.StringNullToEmpty(this._ufembarq); } set { this._ufembarq = value; } }

        public string INSTNEG { get { return ConverterValue.StringNullToEmpty(this._instneg); } set { this._instneg = value; } }

        public string TPPRP { get { return ConverterValue.StringNullToEmpty(this._tpprp); } set { this._tpprp = value; } }
        
        [NotMapped]
        public string DTSHIP { get { return ConverterValue.DateTimeNullableForString(this._dtship); } set { this._dtship = ConverterValue.StringForDateTimeNullable(value); } }

        public string NROCE { get { return ConverterValue.StringNullToEmpty(this._nroce); } set { this._nroce = value; } }

        [NotMapped]
        public string DTCE { get { return ConverterValue.DateTimeNullableForString(this._dtce); } set { this._dtce = ConverterValue.StringForDateTimeNullable(value); } }

    }
}
