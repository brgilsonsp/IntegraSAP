using System;
using System.Xml.Serialization;
using BL.InnerUtil;

namespace BL.ObjectMessages
{
    public class TGTESHKN
    {
        [XmlAttribute]
        public string Type;
        
        public string SBELN;

        public string LOCSE;

        public string TIPSE;

        public string TSETMP;

        public string SEDAT;

        public string ETADT;

        public string ENVDT;

        public string PREVDT;

        public string TRANS;

        public string ZOLLAO;

        public string ZLANDO;

        public string ZOLLAD;

        public string ZLANDD;

        public decimal NETWR;

        public string WAERSRF;

        public string INCO1;

        public string ZTERM;

        public string SESTAT;

        public string WAERS;

        public string BFMAR;

        public string SHPTRIP;

        public string ETDDT;

        public string BLNMB;

        public string BLDTA;

        public string HSAWB;

        public string SHPNAM;

        public string INVNR;

        public string DT_INVNR;

        public decimal VOLUM;

        public decimal NTGEW;

        public decimal BRGEW;

        public decimal VLFRETE;

        public string MOEDAFRT;

        public decimal VLSEGURO;

        public string MOEDASGR;

        public decimal VLCOAGT;

        public string MOEDACOAGT;

        public decimal PCCOAGT;

        public string TPCOAGT;

        public string DTCLTC;

        public string DTEARM;

        public string DTENTC;

        public string URFDESP;

        public string URFEMBA;

        public string MODPAG;

        public string BASCOM;

        public string PRECLCT;

        public string DTCOLETA;

        public string DTCHGARM;

        public string DTPRESC;

        public string DTAVERB;

        public string DTENTREGA;

        public string BROKNM;

        public string NMBOOK;

        public string DTBOOK;

        public string TPVEIC;

        public string TPCARG;

        public string UFEMBARQ;

        public string INSTNEG;

        public string TPPRP;

        public string DTSHIP;

        public string NROCE;

        public string DTCE;

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string SEDAT
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? SEDAT_DateTime
        {
            get
            {
                if ("".Equals(this.SEDAT))
                {
                    return null;
                } else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.SEDAT);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ETAD
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? ETADT_DateTime {
            get {
                if ("".Equals(this.ETADT))
                {
                    return null;
                } else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.ETADT);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ENVDT
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? ENVDT_DateTime
        {
            get
            {
                if ("".Equals(this.ENVDT))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.ENVDT);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string PREVDT
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? PREVDT_DateTime
        {
            get
            {
                if ("".Equals(this.PREVDT))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.PREVDT);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ETDDT
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? ETDDT_DateTime
        {
            get
            {
                if ("".Equals(this.ETDDT))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.ETDDT);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string BLDTA
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? BLDTA_DateTime
        {
            get
            {
                if ("".Equals(this.BLDTA))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.BLDTA);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DT_INVNR
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DT_INVNR_DateTime
        {
            get
            {
                if ("".Equals(this.DT_INVNR))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DT_INVNR);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCLTC
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTCLTC_DateTime
        {
            get
            {
                if ("".Equals(this.DTCLTC))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTCLTC);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTEARM
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTEARM_DateTime
        {
            get
            {
                if ("".Equals(this.DTEARM))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTEARM);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTENTC
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTENTC_DateTime
        {
            get
            {
                if ("".Equals(this.DTENTC))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTENTC);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCOLETA
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTCOLETA_DateTime
        {
            get
            {
                if ("".Equals(this.DTCOLETA))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTCOLETA);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCHGARM
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTCHGARM_DateTime
        {
            get
            {
                if ("".Equals(this.DTCHGARM))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTCHGARM);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTPRESC
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTPRESC_DateTime
        {
            get
            {
                if ("".Equals(this.DTPRESC))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTPRESC);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTAVERB
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTAVERB_DateTime
        {
            get
            {
                if ("".Equals(this.DTAVERB))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTAVERB);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTENTREGA
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTENTREGA_DateTime
        {
            get
            {
                if ("".Equals(this.DTENTREGA))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTENTREGA);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTBOOK
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTBOOK_DateTime
        {
            get
            {
                if ("".Equals(this.DTBOOK))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTBOOK);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTSHIP
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTSHIP_DateTime
        {
            get
            {
                if ("".Equals(this.DTSHIP))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTSHIP);
                }
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DTCE
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DateTime? DTCE_DateTime
        {
            get
            {
                if ("".Equals(this.DTCE))
                {
                    return null;
                }
                else
                {
                    return ConfigureDate.convertDateStringForDateTime(this.DTCE);
                }
            }
        }
    }
}
