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
    public class ATOCON_TAB_TGTEDUEP
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
        [Column("ATOCONITM")]
        public int? ATOCONITMDB { get { return this._atoconitm; } set { this._atoconitm = value; } }

        [XmlIgnore]
        [Column("VLRCOMCOB")]
        public decimal? VLRCOMCOBDB { get { return this._vlrcomcob; } set { this._vlrcomcob = value; } }

        [XmlIgnore]
        [Column("VLRSEMCOB")]
        public decimal? VLRSEMCOBDB { get { return this._vlrsemcob; } set { this._vlrsemcob = value; } }

        [XmlIgnore]
        [Column("CNPJ_BENEF")]
        public int? CNPJ_BENEFDB { get { return this._cnpj_benef; } set { this._cnpj_benef = value; } }
        #endregion

        #region private

        private string _dueid;
        private int? _dueposnr;
        private string _atocon;
        private int? _atoconitm;
        private decimal? _vlrcomcob;
        private decimal? _vlrsemcob;
        private string _steuc;
        private int? _cnpj_benef;

        #endregion
        

        [XmlElement]
        public string Type { get; set; }

        public string DUEID { get { return ConverterValue.StringNullToEmpty(this._dueid); } set { this._dueid = value; } }

        [NotMapped]
        public string DUEPOSNR { get { return ConverterValue.IntNullableToString(this._dueposnr); } set { this._dueposnr = ConverterValue.StringToIntNullable(value); } }

        public string ATOCON { get { return ConverterValue.StringNullToEmpty(this._atocon); } set { this._atocon = value; } }

        [NotMapped]
        public string ATOCONITM { get { return ConverterValue.IntNullableToString(this._atoconitm); } set { this._atoconitm = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string VLRCOMCOB { get { return ConverterValue.DecimalNullableToString(this._vlrcomcob); } set { this._vlrcomcob = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string VLRSEMCOB { get { return ConverterValue.DecimalNullableToString(this._vlrsemcob); } set { this._vlrsemcob = ConverterValue.StringToDecimalNullable(value); } }

        public string STEUC { get { return ConverterValue.StringNullToEmpty(this._steuc); } set { this._steuc = value; } }

        [NotMapped]
        public string CNPJ_BENEF { get { return ConverterValue.IntNullableToString(this._cnpj_benef); } set { this._cnpj_benef = ConverterValue.StringToIntNullable(value); } }
    }
}
