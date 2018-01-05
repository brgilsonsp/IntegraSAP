using System;
using System.Xml.Serialization;
using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    public class TGTERES
    {

        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        [XmlIgnore]
        private DateTime? _dDEADT_DateTime;
        [XmlIgnore]
        private DateTime? _dDEDT_DateTime;
        [XmlIgnore]
        private DateTime? _aVBDT_DateTime;
        [XmlIgnore]
        private DateTime? _rEDAT_DateTime;
        [XmlIgnore]
        private DateTime? _aNDAT_DateTime;

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DDEADT. Se o valor da propriedade DDEADT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlIgnore]
        [Column("DDEADT")]
        public DateTime? DDEADT_DateTime
        {
            get
            {
                if (_dDEADT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DDEADT);
                else return _dDEADT_DateTime;
            }
            set
            {
                _dDEADT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string DDEDT. Se o valor da propriedade DDEDT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlIgnore]
        [Column("DDEDT")]
        public DateTime? DDEDT_DateTime
        {
            get
            {
                if (_dDEDT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.DDEDT);
                else return _dDEDT_DateTime;
            }
            set
            {
                _dDEDT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string AVBDT. Se o valor da propriedade AVBDT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlIgnore]
        [Column("AVBDT")]
        public DateTime? AVBDT_DateTime
        {
            get
            {
                if (_aVBDT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.AVBDT);
                else return _aVBDT_DateTime;
            }
            set
            {
                _aVBDT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string REDAT. Se o valor da propriedade REDAT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlIgnore]
        [Column("REDAT")]
        public DateTime? REDAT_DateTime
        {
            get
            {
                if (_rEDAT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.REDAT);
                else return _rEDAT_DateTime;
            }
            set
            {
                _rEDAT_DateTime = value;
            }
        }

        /// <summary>
        /// get. Retorna um objeto DateTime com o valor da data informada
        /// na propriedade string ANDAT. Se o valor da propriedade ANDAT
        /// for vazio ou nulo, retorna null
        /// </summary>
        [XmlIgnore]
        [Column("ANDAT")]
        public DateTime? ANDAT_DateTime
        {
            get
            {
                if (_aNDAT_DateTime == null) return ConfigureDate.convertDateStringForDateTime(this.ANDAT);
                else return _aNDAT_DateTime;
            }
            set
            {
                _aNDAT_DateTime = value;
            }
        }

        #endregion


        [XmlAttribute]
        [Column("TypeTGTERES")]
        public string Type { get; set; }

        [NotMapped]
        public string SBELN { get; set; }

        public string DSENUM { get; set; }

        public string RENUM { get; set; }

        [NotMapped]
        public string ANDAT { get; set; }

        [NotMapped]
        public string REDAT { get; set; }

        [NotMapped]
        public string AVBDT { get; set; }

        public string CANAL { get; set; }

        public string DDENUM { get; set; }

        [NotMapped]
        public string DDEDT { get; set; }

        public string DDESQ { get; set; }

        public string REANX { get; set; }

        public int DSESQ { get; set; }

        public string DOCFAT { get; set; }

        public string XBLNR { get; set; }

        public string INCO1 { get; set; }

        public string WAERS { get; set; }

        [NotMapped]
        public string DDEADT { get; set; }
    }
}
