using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class INVP
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
        private string _netfre;
        private string _netins;
        private string _netoth;
        private string _netdis;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string NETFRE { get { return ConverterValue.StringNullToEmpty(this._netfre); } set { this._netfre = value; } }

        public string NETINS { get { return ConverterValue.StringNullToEmpty(this._netins); } set { this._netins = value; } }

        public string NETOTH { get { return ConverterValue.StringNullToEmpty(this._netoth); } set { this._netoth = value; } }

        public string NETDIS { get { return ConverterValue.StringNullToEmpty(this._netdis); } set { this._netdis = value; } }
        
    }
}
