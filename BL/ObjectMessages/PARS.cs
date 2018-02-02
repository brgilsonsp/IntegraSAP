using BL.InnerUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class PARS
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDMain")]
        public int MainID { get; set; }

        [XmlIgnore]
        public virtual MAIN Main { get; set; }

        #endregion

        #region private

        private string _type;
        private string _parid;
        private string _name1;
        private string _name2;
        private string _street;
        private string _house_num1;
        private string _house_num2;
        private string _post_code1;
        private string _city1;
        private string _city2;
        private string _pstlz;
        private string _region;
        private string _country;
        private string _stcd1;
        private string _stcd3;
        private string _stcd4;
        private string _parvw;
        private string _vtxtk;

        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        public string PARID { get { return ConverterValue.StringNullToEmpty(this._parid); } set { this._parid = value; } }

        public string NAME1 { get { return ConverterValue.StringNullToEmpty(this._name1); } set { this._name1 = value; } }

        public string NAME2 { get { return ConverterValue.StringNullToEmpty(this._name2); } set { this._name2 = value; } }

        public string STREET { get { return ConverterValue.StringNullToEmpty(this._street); } set { this._street = value; } }

        public string HOUSE_NUM1 { get { return ConverterValue.StringNullToEmpty(this._house_num1); } set { this._house_num1 = value; } }

        public string HOUSE_NUM2 { get { return ConverterValue.StringNullToEmpty(this._house_num2); } set { this._house_num2 = value; } }

        public string POST_CODE1 { get { return ConverterValue.StringNullToEmpty(this._post_code1); } set { this._post_code1 = value; } }

        public string CITY1 { get { return ConverterValue.StringNullToEmpty(this._city1); } set { this._city1 = value; } }

        public string CITY2 { get { return ConverterValue.StringNullToEmpty(this._city2); } set { this._city2 = value; } }

        public string PSTLZ { get { return ConverterValue.StringNullToEmpty(this._pstlz); } set { this._pstlz = value; } }

        public string REGION { get { return ConverterValue.StringNullToEmpty(this._region); } set { this._region = value; } }

        public string COUNTRY { get { return ConverterValue.StringNullToEmpty(this._country); } set { this._country = value; } }

        public string STCD1 { get { return ConverterValue.StringNullToEmpty(this._stcd1); } set { this._stcd1 = value; } }

        public string STCD3 { get { return ConverterValue.StringNullToEmpty(this._stcd3); } set { this._stcd3 = value; } }

        public string STCD4 { get { return ConverterValue.StringNullToEmpty(this._stcd4); } set { this._stcd4 = value; } }

        public string PARVW { get { return ConverterValue.StringNullToEmpty(this._parvw); } set { this._parvw = value; } }

        public string VTXTK { get { return ConverterValue.StringNullToEmpty(this._vtxtk); } set { this._vtxtk = value; } }
        
    }
}
