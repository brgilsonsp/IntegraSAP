using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class ADDRESS_TAB_TGTEDUEK
    {

        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDTGTEDUEK")]
        public int TGTEDUEKID { get; set; }

        [XmlIgnore]
        public virtual TGTEDUEK TGTEDUEK { get; set; }
        #endregion


        [XmlAttribute]
        public string Type { get; set; }
        public string DUEID { get; set; }
        public string ADRNR { get; set; }
        public int? LINESEQ { get; set; }
        public string CONTENT { get; set; }
    }
}
