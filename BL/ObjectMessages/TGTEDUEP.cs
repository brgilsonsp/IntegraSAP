using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class TGTEDUEP
    {
        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        #endregion


        [XmlAttribute]
        public string Type { get; set; }
        public string DUEID { get; set; }
        public int? DUEPOSNR { get; set; }
        public string DUENUM { get; set; }
        public int? DUEITM { get; set; }
        public string RUCNUM { get; set; }
        public decimal? PRCFOB { get; set; }
        public string CDLANDD { get; set; }
        public decimal? MENGE { get; set; }
        public decimal? NETWR { get; set; }
        public decimal? MENGE_TRIB { get; set; }
        public decimal? NTGEW { get; set; }
        public string ENQDM { get; set; }
        public string PRVDOCID { get; set; }
        public int? PRVTPCODE { get; set; }
        public decimal? PCTCOM { get; set; }
        public string CHAVENFE { get; set; }
        public int? TPCDREM { get; set; }
        public int? CNPJCPF { get; set; }
        public string CHAVENF_FORM { get; set; }
        public string CDNFR { get; set; }
        public int? CPNJCPFEXP { get; set; }

        [XmlElement("ADDINFO_TAB")]
        public virtual List<ADDINFO_TAB_TGTEDUEP> ADDINFO_TAB { get; set; }

        [XmlElement("NFEREF_TAB")]
        public virtual List<NFEREF_TAB_TGTEDUEP> NFEREF_TAB { get; set; }

        [XmlElement("ATOCON_TAB")]
        public virtual List<ATOCON_TAB_TGTEDUEP> ATOCON_TAB { get; set; }

        [XmlElement("DUEATRIB_TAB")]
        public virtual List<DUEATRIB_TAB_TGTEDUEP> DUEATRIB_TAB { get; set; }
    }
    
}
