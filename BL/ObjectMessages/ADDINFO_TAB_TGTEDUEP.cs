using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class ADDINFO_TAB_TGTEDUEP
    {
        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDTGTEDUEP")]
        public int TGTEDUEPID { get; set; }

        [XmlIgnore]
        public virtual TGTEDUEP TGTEDUEP { get; set; }

        #endregion

        [XmlElement]
        public string Type { get; set; }
        public string DUEID { get; set; }
        public int? DUEPOSNR { get; set; }
        public string STMTPCODE { get; set; }
        public int? STMCODE { get; set; }
        public int? LMTDTTIME { get; set; }
        public int? DTTMSTR { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
