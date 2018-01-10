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
    public class ADDINFO_TAB_TGTEDUEK
    {

        #region only DataBase

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDTGTEDUEK")]
        public int TGTEDUEKID { get; set; }

        [XmlIgnore]
        public virtual TGTEDUEK TGTEDUEK { get; set; }
        
        [XmlIgnore][Column("STMCODE")]
        private int? STMCODEBD { get { return this._stmcode; } set { this._stmcode = value; } }

        [XmlIgnore][Column("LMTDTTIME")]
        private int? LMTDTTIMEBD { get { return this._lmtdttime; } set { this._lmtdttime = value; } }

        [XmlIgnore][Column("DTTMSTR")]
        private int? DTTMSTRBD { get { return this._dttmstr; } set { this._dttmstr = value; } }

        #endregion

        #region private

        [XmlIgnore][NotMapped]
        private int? _stmcode;

        [XmlIgnore][NotMapped]
        private int? _lmtdttime;

        [XmlIgnore][NotMapped]
        private int? _dttmstr;

        #endregion


        [XmlAttribute]
        public string Type { get; set; }

        public string DUEID { get; set; }

        public string DUEPOSNR { get; set; }

        public string STMTPCODE { get; set; }

        [NotMapped]
        public string STMCODE { get { return ConverterValue.IntNullableToString(this._stmcode); } set { this._stmcode = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string LMTDTTIME { get { return ConverterValue.IntNullableToString(this._lmtdttime); } set { this._lmtdttime = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string DTTMSTR { get { return ConverterValue.IntNullableToString(this._dttmstr); } set { this._dttmstr = ConverterValue.StringToIntNullable(value); } }

        public string DESCRIPTION { get; set; }
    }
}
