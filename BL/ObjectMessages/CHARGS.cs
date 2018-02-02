using BL.InnerUtil;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class CHARGS
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
        private string _charg;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string CHARG { get { return ConverterValue.StringNullToEmpty(this._charg); } set { this._charg = value; } }

        [XmlElement("SERNR")]
        public List<SERNR> SERNR { get; set; }
    }
}
