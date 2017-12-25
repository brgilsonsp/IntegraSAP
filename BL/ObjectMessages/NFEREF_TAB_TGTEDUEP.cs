using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class NFEREF_TAB_TGTEDUEP
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
        public int? DOCNUM { get; set; }
        public int? ITMNUM { get; set; }
        public string NFENUM { get; set; }
        public string SERIES { get; set; }
        public string PARID { get; set; }
        public decimal? MENGE { get; set; }

    }
}
