using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class NFSK
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
        private string _fobbrl_vl;
        private string _netfre_vl;
        private string _netins_vl;
        private string _netoth_ii_vl;
        private string _netoth_icms_vl;
        private string _netoth_vl;
        private string _cif_vl;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string FOBBRL_VL { get { return ConverterValue.StringNullToEmpty(this._fobbrl_vl); } set { this._fobbrl_vl = value; } }

        public string NETFRE_VL { get { return ConverterValue.StringNullToEmpty(this._netfre_vl); } set { this._netfre_vl = value; } }

        public string NETINS_VL { get { return ConverterValue.StringNullToEmpty(this._netins_vl); } set { this._netins_vl = value; } }

        public string NETOTH_II_VL { get { return ConverterValue.StringNullToEmpty(this._netoth_ii_vl); } set { this._netoth_ii_vl = value; } }

        public string NETOTH_ICMS_VL { get { return ConverterValue.StringNullToEmpty(this._netoth_icms_vl); } set { this._netoth_icms_vl = value; } }

        public string NETOTH_VL { get { return ConverterValue.StringNullToEmpty(this._netoth_vl); } set { this._netoth_vl = value; } }

        public string CIF_VL { get { return ConverterValue.StringNullToEmpty(this._cif_vl); } set { this._cif_vl = value; } }
        
    }
}
