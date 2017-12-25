using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class TXPNS
    {

        #region XmlIgnore
        [XmlIgnore]
        public int ID { get; set; }

        [Column("IDTPCK")][XmlIgnore]
        public int TPCKID { get; set; }

        [XmlIgnore]
        public virtual TPCK TPCK { get; set; }

        #endregion

        [XmlAttribute][Column("TypeTXPNS")]
        public string Type;

        public string KSCHL { get; set; }

        public decimal? NETWR { get; set; }

        
    }
}
