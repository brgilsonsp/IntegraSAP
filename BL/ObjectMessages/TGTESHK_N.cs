using System;
using System.Xml.Serialization;
using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    
    public class TGTESHK_N
    {

        public TGTESHK_N() {   }

        public TGTESHK_N(TGTESHK_N obj)
        {
            this.Type = obj.Type;
        }

        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        [XmlIgnore]
        private DateTime? _sEDAT_DateTime;
        [XmlIgnore]
        private DateTime? _eTADT_DateTime;
        [XmlIgnore]
        private DateTime? _eNVDT_DateTime;
        [XmlIgnore]
        private DateTime? _pREVDT_DateTime;
        [XmlIgnore]
        private DateTime? _eTDDT_DateTime;
        [XmlIgnore]
        private DateTime? _bLDTA_DateTime;
        [XmlIgnore]
        private DateTime? _dT_INVNR_DateTime;
        [XmlIgnore]
        private DateTime? _dTCLTC_DateTime;
        [XmlIgnore]
        private DateTime? _dTEARM_DateTime;
        [XmlIgnore]
        private DateTime? dTENTC_DateTime;
        [XmlIgnore]
        private DateTime? _dTCOLETA_DateTime;
        [XmlIgnore]
        private DateTime? _dTCHGARM_DateTime;
        [XmlIgnore]
        private DateTime? _dTPRESC_DateTime;
        [XmlIgnore]
        private DateTime? _dTAVERB_DateTime;
        [XmlIgnore]
        private DateTime? _dTENTREGA_DateTime;
        [XmlIgnore]
        private DateTime? _dTBOOK_DateTime;
        [XmlIgnore]
        private DateTime? _dTSHIP_DateTime;
        [XmlIgnore]
        private DateTime? _dTCE_DateTime;


        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string SEDAT
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("SEDAT")]
        public DateTime? SEDAT_DateTime
        {
            get
            {
                if (_sEDAT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.SEDAT);
                else return _sEDAT_DateTime;
            }
            set
            {
                _sEDAT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ETAD
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("ETADT")]
        public DateTime? ETADT_DateTime
        {
            get
            {
                if (_eTADT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.ETADT);
                else return _eTADT_DateTime;
            }
            set
            {
                _eTADT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ENVDT
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("ENVDT")]
        public DateTime? ENVDT_DateTime
        {
            get
            {
                if (_eNVDT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.ENVDT);
                else return _eNVDT_DateTime;
            }
            set
            {
                _eNVDT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string PREVDT
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("PREVDT")]
        public DateTime? PREVDT_DateTime
        {
            get
            {
                if (_pREVDT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.PREVDT);
                else return _pREVDT_DateTime;
            }
            set
            {
                _pREVDT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ETDDT
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("ETDDT")]
        public DateTime? ETDDT_DateTime
        {
            get
            {
                if (_eTDDT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.ETDDT);
                else return _eTDDT_DateTime;
            }
            set
            {
                _eTDDT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string BLDTA
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("BLDTA")]
        public DateTime? BLDTA_DateTime
        {
            get
            {
                if (_bLDTA_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.BLDTA);
                else return _bLDTA_DateTime;
            }
            set
            {
                _bLDTA_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DT_INVNR
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DT_INVNR")]
        public DateTime? DT_INVNR_DateTime
        {
            get
            {
                if (_dT_INVNR_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DT_INVNR);
                else return _dT_INVNR_DateTime;
            }
            set
            {
                _dT_INVNR_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCLTC
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTCLTC")]
        public DateTime? DTCLTC_DateTime
        {
            get
            {
                if (_dTCLTC_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTCLTC);
                else return _dTCLTC_DateTime;
            }
            set
            {
                _dTCLTC_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTEARM
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTEARM")]
        public DateTime? DTEARM_DateTime
        {
            get
            {
                if (_dTEARM_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTEARM);
                else return _dTEARM_DateTime;
            }
            set
            {
                _dTEARM_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTENTC
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTENTC")]
        public DateTime? DTENTC_DateTime
        {
            get
            {
                if (dTENTC_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTENTC);
                else return dTENTC_DateTime;
            }
            set
            {
                dTENTC_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCOLETA
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTCOLETA")]
        public DateTime? DTCOLETA_DateTime
        {
            get
            {
                if (_dTCOLETA_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTCOLETA);
                else return _dTCOLETA_DateTime;
            }
            set
            {
                _dTCOLETA_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCHGARM
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTCHGARM")]
        public DateTime? DTCHGARM_DateTime
        {
            get
            {
                if (_dTCHGARM_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTCHGARM);
                else return _dTCHGARM_DateTime;
            }
            set
            {
                _dTCHGARM_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTPRESC
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTPRESC")]
        public DateTime? DTPRESC_DateTime
        {
            get
            {
                if (_dTPRESC_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTPRESC);
                else return _dTPRESC_DateTime;
            }
            set
            {
                _dTPRESC_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTAVERB
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTAVERB")]
        public DateTime? DTAVERB_DateTime
        {
            get
            {
                if (_dTAVERB_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTAVERB);
                else return _dTAVERB_DateTime;
            }
            set
            {
                _dTAVERB_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTENTREGA
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTENTREGA")]
        public DateTime? DTENTREGA_DateTime
        {
            get
            {
                if (_dTENTREGA_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTENTREGA);
                else return _dTENTREGA_DateTime;
            }
            set
            {
                _dTENTREGA_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTBOOK
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTBOOK")]
        public DateTime? DTBOOK_DateTime
        {
            get
            {
                if (_dTBOOK_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTBOOK);
                else return _dTBOOK_DateTime;
            }
            set
            {
                _dTBOOK_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTSHIP
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTSHIP")]
        public DateTime? DTSHIP_DateTime
        {
            get
            {
                if (_dTSHIP_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTSHIP);
                else return _dTSHIP_DateTime;
            }
            set
            {
                _dTSHIP_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCE
        /// </summary>
        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("DTCE")]
        public DateTime? DTCE_DateTime
        {
            get
            {
                if (_dTCE_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DTCE);
                else return _dTCE_DateTime;
            }
            set
            {
                _dTCE_DateTime = value;
            }
        }

        #endregion

        [XmlAttribute]
        [Column("TypeTGTESHKN")]
        public string Type { get; set; }

        [NotMapped]
        public string SBELN { get; set; }

        public string LOCSE { get; set; }

        public string TIPSE { get; set; }

        public string TSETMP { get; set; }

        [NotMapped]
        public string SEDAT { get; set; }

        [NotMapped]
        public string ETADT { get; set; }

        [NotMapped]
        public string ENVDT { get; set; }

        [NotMapped]
        public string PREVDT { get; set; }

        public string TRANS { get; set; }

        public string ZOLLAO { get; set; }

        public string ZLANDO { get; set; }

        public string ZOLLAD { get; set; }

        public string ZLANDD { get; set; }

        public decimal NETWR { get; set; }

        public string WAERSRF { get; set; }

        public string INCO1 { get; set; }

        public string ZTERM { get; set; }

        public string SESTAT { get; set; }

        public string WAERS { get; set; }

        public string BFMAR { get; set; }

        public string SHPTRIP { get; set; }

        [NotMapped]
        public string ETDDT { get; set; }

        public string BLNMB { get; set; }

        [NotMapped]
        public string BLDTA { get; set; }

        public string HSAWB { get; set; }

        public string SHPNAM { get; set; }

        public string INVNR { get; set; }

        [NotMapped]
        public string DT_INVNR { get; set; }

        public decimal VOLUM { get; set; }

        public decimal NTGEW { get; set; }

        public decimal BRGEW { get; set; }

        public decimal VLFRETE { get; set; }

        public string MOEDAFRT { get; set; }

        public decimal VLSEGURO { get; set; }

        public string MOEDASGR { get; set; }

        public decimal VLCOAGT { get; set; }

        public string MOEDACOAGT { get; set; }

        public decimal PCCOAGT { get; set; }

        public string TPCOAGT { get; set; }

        [NotMapped]
        public string DTCLTC { get; set; }

        [NotMapped]
        public string DTEARM { get; set; }

        [NotMapped]
        public string DTENTC { get; set; }

        public string URFDESP { get; set; }

        public string URFEMBA { get; set; }

        public string MODPAG { get; set; }

        public string BASCOM { get; set; }

        public string PRECLCT { get; set; }

        [NotMapped]
        public string DTCOLETA { get; set; }

        [NotMapped]
        public string DTCHGARM { get; set; }

        [NotMapped]
        public string DTPRESC { get; set; }

        [NotMapped]
        public string DTAVERB { get; set; }

        [NotMapped]
        public string DTENTREGA { get; set; }

        public string BROKNM { get; set; }

        public string NMBOOK { get; set; }

        [NotMapped]
        public string DTBOOK { get; set; }

        public string TPVEIC { get; set; }

        public string TPCARG { get; set; }

        public string UFEMBARQ { get; set; }

        public string INSTNEG { get; set; }

        public string TPPRP { get; set; }

        [NotMapped]
        public string DTSHIP { get; set; }

        public string NROCE { get; set; }

        [NotMapped]
        public string DTCE { get; set; }

    }
}
