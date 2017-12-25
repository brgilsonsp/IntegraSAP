using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class MAKTX_TEXT
    {
        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IdTGTESHPN")]
        public int TGTESHPNID { get; set; }

        [XmlIgnore]
        public virtual TGTESHP_N TGTESHPN { get; set; }

        #endregion


        [XmlAttribute]
        [Column("TypeMaktx")]
        public string Type { get; set; }

        public string TEXT { get; set; }
    }
}
