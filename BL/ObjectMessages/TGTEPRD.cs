using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    /// <summary>
    /// Essa classe possui propriedades redundantes. 
    /// Quando a propriedade possui a anotação NotMapped, ela será utilizada apenas para o XML, sendo assim ela mantem
    /// o nome que foi definida na documentação (fornecida pela E-IT), porém quando a propriedade
    /// utiliza as anotações XmlIgnore e Column("NomeColuna") ela é utilizada apenas pelo banco de dados e foi inserido
    /// um sufixo DB. Foi criado também uma variável privada afim de tratar o retorno para o XML,
    /// pois a E-IT necessita de todos campos no arquivo XML, mesmo null, sendo assim, se o valor no banco de dados for null
    /// ele retornará uma string vazia, afim de gerar a tag no XML
    /// </summary>
    public class TGTEPRD
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        [XmlIgnore]
        [Column("IDTGTESHKN")]
        public int TGTESHK_NID { get; set; }

        [XmlIgnore]
        public virtual TGTESHK_N TGTESHK_N { get; set; }

        #endregion


        #region private

        private string _parvw;
        private string _parid;
        private string _name1;
        private string _name2;
        private string _street;
        private string _house_num1;
        private string _house_num2;
        private string _poste_code1;
        private string _city1;
        private string _city2;
        private string _pstlz;
        private string _region;
        private string _country;
        private string _stcd1;
        private string _stcd3;
        private string _stcd4;


        #endregion

        [XmlAttribute]
        [Column("TypeTGTEPRD")]
        public string Type { get; set; }

        public string PARVW { get { return ConverterValue.StringNullToEmpty(this._parvw); } set { this._parvw = value; } }

        public string PARID { get { return ConverterValue.StringNullToEmpty(this._parid); } set { this._parid = value; } }

        public string NAME1 { get { return ConverterValue.StringNullToEmpty(this._name1); } set { this._name1 = value; } }

        public string NAME2 { get { return ConverterValue.StringNullToEmpty(this._name2); } set { this._name2 = value; } }

        public string STREET { get { return ConverterValue.StringNullToEmpty(this._street); } set { this._street = value; } }
        
        public string HOUSE_NUM1 { get { return ConverterValue.StringNullToEmpty(this._house_num1); } set { this._house_num1 = value; } }

        public string HOUSE_NUM2 { get { return ConverterValue.StringNullToEmpty(this._house_num2); } set { this._house_num2 = value; } }

        [Column("POST_CODE1")]
        public string POSTE_CODE1 { get { return ConverterValue.StringNullToEmpty(this._poste_code1); } set { this._poste_code1 = value; } }

        public string CITY1 { get { return ConverterValue.StringNullToEmpty(this._city1); } set { this._city1 = value; } }

        public string CITY2 { get { return ConverterValue.StringNullToEmpty(this._city2); } set { this._city2 = value; } }

        public string PSTLZ { get { return ConverterValue.StringNullToEmpty(this._pstlz); } set { this._pstlz = value; } }

        public string REGION { get { return ConverterValue.StringNullToEmpty(this._region); } set { this._region = value; } }

        public string COUNTRY { get { return ConverterValue.StringNullToEmpty(this._country); } set { this._country = value; } }

        public string STCD1 { get { return ConverterValue.StringNullToEmpty(this._stcd1); } set { this._stcd1 = value; } }

        public string STCD3 { get { return ConverterValue.StringNullToEmpty(this._stcd3); } set { this._stcd3 = value; } }

        public string STCD4 { get { return ConverterValue.StringNullToEmpty(this._stcd4); } set { this._stcd4 = value; } }

    }
}
