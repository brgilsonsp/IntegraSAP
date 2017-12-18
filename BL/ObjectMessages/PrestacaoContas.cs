using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BL.InnerUtil;

namespace BL.ObjectMessages
{
    public class PrestacaoContas
    {
        [XmlAttribute]
        public string Type;

        [XmlElement(Order = 1)]
        public string SBELN { get; set; }

        [XmlElement(Order = 2)]
        public string DOCNR { get; set; }

        [XmlElement(Order = 3)]
        public string PCTYP { get; set; }

        [XmlElement(Order = 4)]
        public string PARID { get; set; }

        [XmlElement(Order = 5)]
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
        public string ZFBDT { get; set; }

        [XmlElement(Order = 11)]
        public string ABLFD { get; set; }

        [XmlElement(Order = 12)]
        public string STATU { get; set; }

        [XmlElement("TXPNS", Order = 13)]
        public List<InfoDespesas> TXPNS;

        [XmlElement(IsNullable = false)]
        public DateTime? ABLFD_Date
        {
            get
            {
                return ConfigureDate.convertDateStringForDateTime(ABLFD);
            }
        }

        [XmlElement(IsNullable = false)]
        public DateTime? BLDAT_Date
        {
            get
            {
                return ConfigureDate.convertDateStringForDateTime(BLDAT);
            }
        }

        [XmlElement(IsNullable = false)]
        public DateTime? ZFBDT_Date
        {
            get
            {
                return ConfigureDate.convertDateStringForDateTime(ZFBDT);
            }

        }

        
    }

    public class InfoDespesas
    {
        [XmlAttribute]
        public string Type;

        public string KSCHL { get; set; }

        public decimal? NETWR { get; set; }


    }
}
