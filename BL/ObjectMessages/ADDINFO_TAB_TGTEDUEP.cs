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
    public class ADDINFO_TAB_TGTEDUEP
    {
        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDTGTEDUEP")]
        public int TGTEDUEPID { get; set; }

        [XmlIgnore]
        public virtual TGTEDUEP TGTEDUEP { get; set; }

        [XmlIgnore]
        [Column("DUEPOSNR")]
        public int? DUEPOSNRDB { get { return this._dueposnr; } set { this._dueposnr = value; } }

        [XmlIgnore]
        [Column("STMCODE")]
        public int? STMCODEDB { get { return this._stmcode; } set { this._stmcode = value; } }

        [XmlIgnore]
        [Column("LMTDTTIME")]
        public int? LMTDTTIMEDB { get { return this._lmtdttime; } set { this._lmtdttime = value; } }

        [XmlIgnore]
        [Column("DTTMSTR")]
        public int? DTTMSTRDB { get { return this._dttmstr; } set { this._dttmstr = value; } }

        #endregion

        #region private

        private string _dueid;
        private int? _dueposnr;
        private string _stmtpcode;
        private int? _stmcode;
        private int? _lmtdttime;
        private int? _dttmstr;
        private string _description;

        #endregion
        

        [XmlElement]
        public string Type { get; set; }

        public string DUEID { get { return ConverterValue.StringNullToEmpty(this._dueid); } set { this._dueid = value; } }

        [NotMapped]
        public string DUEPOSNR { get { return ConverterValue.IntNullableToString(this._dueposnr); } set { this._dueposnr = ConverterValue.StringToIntNullable(value); } }

        public string STMTPCODE { get { return ConverterValue.StringNullToEmpty(this._stmtpcode); } set { this._stmtpcode = value; } }

        [NotMapped]
        public string STMCODE { get { return ConverterValue.IntNullableToString(this._stmcode); } set { this._stmcode = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string LMTDTTIME { get { return ConverterValue.IntNullableToString(this._lmtdttime); } set { this._lmtdttime = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string DTTMSTR { get { return ConverterValue.IntNullableToString(this._dttmstr); } set { this._dttmstr = ConverterValue.StringToIntNullable(value); } }

        public string DESCRIPTION { get { return ConverterValue.StringNullToEmpty(this._description); } set { this._description = value; } }
    }
}
