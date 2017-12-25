using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    public class TPCK
    {
        #region XmlIgnore

        private DateTime? _aBLFD_Date;
        private DateTime? _bLDAT_Date;
        private DateTime? _zFBDT_Date;

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column(" ABLFD")]
        public DateTime? ABLFD_Date
        {
            get
            {
                if (_aBLFD_Date == null) return ConfigureDate.convertDateStringForDateTime(ABLFD);
                else return _aBLFD_Date;
            }
            set
            {
                _aBLFD_Date = value;
            }
        }

        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("BLDAT")]
        public DateTime? BLDAT_Date
        {
            get
            {
                if (_bLDAT_Date == null) return ConfigureDate.convertDateStringForDateTime(BLDAT);
                else return _bLDAT_Date;
            }
            set
            {
                _bLDAT_Date = value;
            }
        }

        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        [Column("ZFBDT")]
        public DateTime? ZFBDT_Date
        {
            get
            {
                if (_zFBDT_Date == null) return ConfigureDate.convertDateStringForDateTime(ZFBDT);
                else return _zFBDT_Date;
            }
            set
            {
                _zFBDT_Date = value;
            }

        }

        #endregion


        [XmlAttribute][Column("TypePCK")]
        public string Type;

        [XmlElement(Order = 1)]
        [NotMapped]
        public string SBELN { get; set; }

        [XmlElement(Order = 2)]
        public string DOCNR { get; set; }

        [XmlElement(Order = 3)]
        public string PCTYP { get; set; }

        [XmlElement(Order = 4)]
        public string PARID { get; set; }

        [XmlElement(Order = 5)]
        [NotMapped]
        public string BLDAT { get; set; }

        [XmlElement(Order = 6)]
        public string XBLNR { get; set; }

        [XmlElement(Order = 7)]
        public string ZUONR { get; set; }

        [XmlElement(Order = 8)]
        public string BKTXT { get; set; }

        [XmlElement(Order = 9)]
        public string SGTXT { get; set; }

        [XmlElement(Order = 10)]
        [NotMapped]
        public string ZFBDT { get; set; }

        [XmlElement(Order = 11)]
        [NotMapped]
        public string ABLFD { get; set; }

        [XmlElement(Order = 12)]
        public string STATU { get; set; }

        [XmlElement("TXPNS", Order = 13)]
        [NotMapped]
        public List<TXPNS> TXPNS;

    }
}
