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
    /// <summary>
    /// Essa classe possui propriedades redundantes. 
    /// Quando a propriedade possui a anotação NotMapped, ela será utilizada apenas para o XML, sendo assim ela mantem
    /// o nome que foi definida na documentação (fornecida pela E-IT), porém quando a propriedade
    /// utiliza as anotações XmlIgnore e Column("NomeColuna") ela é utilizada apenas pelo banco de dados e foi inserido
    /// um sufixo DB. Foi criado também uma variável privada afim de tratar o retorno para o XML,
    /// pois a E-IT necessita de todos campos no arquivo XML, mesmo null, sendo assim, se o valor no banco de dados for null
    /// ele retornará uma string vazia, afim de gerar a tag no XML
    /// </summary>
    public class TGTEDUEK
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

        [XmlIgnore]
        [Column("CDRAD")]
        public int? CDRADDB { get { return this._cdrad; } set { this._cdrad = value; } }

        [XmlIgnore]
        [Column("EMRAD")]
        public int? EMRADDB { get { return this._emrad; } set { this._emrad = value; } }

        [XmlIgnore]
        [Column("LATITUDE")]
        public decimal? LATITUDEDB { get { return this._latitude; } set { this._latitude = value; } }
                
        [XmlIgnore]
        [Column("LONGITUDE")]
        public decimal? LONGITUDEDB { get { return this._longitude; } set { this._longitude = value; } }

        [XmlIgnore]
        [Column("CDRAE")]
        public int? CDRAEDB { get { return this._cdrae; } set { this._cdrae = value; } }

        [XmlIgnore]
        [Column("EMRAE")]
        public int? EMRAEDB { get { return this._emrae; } set { this._emrae = value; } }

        [XmlIgnore]
        [Column("CNPJ_DESP")]
        public int? CNPJ_DESPDB { get { return this._cnpj_desp; } set { this._cnpj_desp = value; } }
        #endregion

        #region private

        private string _dueid;
        private string _xlocembarq;
        private string _xlocdespacho;
        private int? _cdrad;
        private int? _emrad;
        private decimal? _latitude;
        private decimal? _longitude;
        private int? _cdrae;
        private int? _emrae;
        private int? _cnpj_desp;
        private string _waers;
        private string _inco1;

        #endregion

        
        [XmlAttribute]
        public string Type { get; set; }

        public string DUEID { get { return ConverterValue.StringNullToEmpty(this._dueid); } set { this._dueid = value; } }

        public string XLOCEMBARQ { get { return ConverterValue.StringNullToEmpty(this._xlocembarq); } set { this._xlocembarq = value; } }

        public string XLOCDESPACHO { get { return ConverterValue.StringNullToEmpty(this._xlocdespacho); } set { this._xlocdespacho = value; } }

        [NotMapped]
        public string CDRAD { get { return ConverterValue.IntNullableToString(this._cdrad); } set { this._cdrad = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string EMRAD { get { return ConverterValue.IntNullableToString(this._emrad); } set { this._emrad = ConverterValue.StringToIntNullable(value); } }
        
        [NotMapped]
        public string LATITUDE { get { return ConverterValue.DecimalNullableToString(this._latitude); } set { this._latitude = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string LONGITUDE { get { return ConverterValue.DecimalNullableToString(this._longitude); } set { this._longitude = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string CDRAE { get { return ConverterValue.IntNullableToString(this._cdrae); } set { this._cdrae = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string EMRAE { get { return ConverterValue.IntNullableToString(this._emrae); } set { this._emrae = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string CNPJ_DESP { get { return ConverterValue.IntNullableToString(this._cnpj_desp); } set { this._cnpj_desp = ConverterValue.StringToIntNullable(value); } }

        public string WAERS { get { return ConverterValue.StringNullToEmpty(this._waers); } set { this._waers = value; } }

        public string INCO1 { get { return ConverterValue.StringNullToEmpty(this._inco1); } set { this._inco1 = value; } }

        [XmlElement("ADDRESS_TAB")]
        public List<ADDRESS_TAB_TGTEDUEK> ADDRESS_TAB { get; set; }

        [XmlElement("ADDINFO_TAB")]
        public List<ADDINFO_TAB_TGTEDUEK> ADDINFO_TAB { get; set; }
    }   
}
