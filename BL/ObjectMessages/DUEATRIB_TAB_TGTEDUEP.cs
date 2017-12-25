using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class DUEATRIB_TAB_TGTEDUEP
    {
        #region XMlIgnore

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
        public string DUEATRIB { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
