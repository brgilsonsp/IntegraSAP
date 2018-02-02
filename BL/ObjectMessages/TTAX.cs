using BL.InnerUtil;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class TTAX
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDSHP")]
        public int SHPID { get; set; }

        [XmlIgnore]
        public virtual SHP SHP { get; set; }

        #endregion

        #region private

        private string _type;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        [XmlElement("II")]
        public List<II> II { get; set; }

        [XmlElement("IP")]
        public List<IP> IP { get; set; }

        [XmlElement("PS")]
        public List<PS> PS { get; set; }

        [XmlElement("CF")]
        public List<CF> CF { get; set; }

        [XmlElement("IC")]
        public List<IC> IC { get; set; }

        [XmlElement("ST")]
        public List<ST> ST { get; set; }

    }
}
