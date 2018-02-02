using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class XPNS
    {
        #region only DB
        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDDI")]
        public int DIID { get; set; }

        [XmlIgnore]
        public virtual DI DI { get; set; }

        #endregion

        #region private

        private string _type;
        private string _kschl;
        private string _netwr;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string KSCHL { get { return ConverterValue.StringNullToEmpty(this._kschl); } set { this._kschl = value; } }

        public string NETWR { get { return ConverterValue.StringNullToEmpty(this._netwr); } set { this._netwr = value; } }
        
    }
}
