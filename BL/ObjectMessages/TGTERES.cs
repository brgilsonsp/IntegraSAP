using System;
using System.Xml.Serialization;
using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;

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
    public class TGTERES
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
        [Column("DDEADT")]
        public DateTime? DDEADTDB { get { return this._ddeadt; } set { this._ddeadt = value; } }
        
        [XmlIgnore]
        [Column("DDEDT")]
        public DateTime? DDEDTDB { get { return this._ddedt; } set { this._ddedt = value; } }

        [XmlIgnore]
        [Column("AVBDT")]
        public DateTime? AVBDTDB { get { return this._avbdt; } set { this._avbdt = value; } }

        [XmlIgnore]
        [Column("REDAT")]
        public DateTime? REDATDB { get { return this._redat; } set { this._redat = value; } }

        [XmlIgnore]
        [Column("ANDAT")]
        public DateTime? ANDATDB { get { return this._andat; } set { this._andat = value; } }

        [XmlIgnore]
        [Column("DSESQ")]
        public int? DSESQDB { get { return this._dsesq; } set { this._dsesq = value; } }

        #endregion


        #region private

        private DateTime? _ddeadt;
        private DateTime? _ddedt;
        private DateTime? _avbdt;
        private DateTime? _redat;
        private DateTime? _andat;
        private int? _dsesq;
        private string _dsenum;
        private string _renum;
        private string _canal;
        private string _ddenum;
        private string _ddesq;
        private string _reanx;
        private string _docfat;
        private string _xblnr;
        private string _inco1;
        private string _waers;

        #endregion


        [XmlAttribute]
        [Column("TypeTGTERES")]
        public string Type { get; set; }

        [NotMapped]
        public string SBELN { get; set; }

        public string DSENUM { get { return ConverterValue.StringNullToEmpty(this._dsenum); } set { this._dsenum = value; } }

        public string RENUM { get { return ConverterValue.StringNullToEmpty(this._renum); } set { this._renum = value; } }

        [NotMapped]
        public string ANDAT { get { return ConverterValue.DateTimeNullableForString(this._andat); } set { this._andat = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string REDAT { get { return ConverterValue.DateTimeNullableForString(this._redat); } set { this._redat = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string AVBDT { get { return ConverterValue.DateTimeNullableForString(this._avbdt); } set { this._avbdt = ConverterValue.StringForDateTimeNullable(value); } }

        public string CANAL { get { return ConverterValue.StringNullToEmpty(this._canal); } set { this._canal = value; } }

        public string DDENUM { get { return ConverterValue.StringNullToEmpty(this._ddenum); } set { this._ddenum = value; } }
        
        [NotMapped]
        public string DDEDT { get { return ConverterValue.DateTimeNullableForString(this._ddedt); } set { this._ddedt = ConverterValue.StringForDateTimeNullable(value); } }

        public string DDESQ { get { return ConverterValue.StringNullToEmpty(this._ddesq); } set { this._ddesq = value; } }

        public string REANX { get { return ConverterValue.StringNullToEmpty(this._reanx); } set { this._reanx = value; } }

        [NotMapped]
        public string DSESQ { get { return ConverterValue.IntNullableToString(this._dsesq); } set { this._dsesq = ConverterValue.StringToIntNullable(value); } }

        public string DOCFAT { get { return ConverterValue.StringNullToEmpty(this._docfat); } set { this._docfat = value; } }

        public string XBLNR { get { return ConverterValue.StringNullToEmpty(this._xblnr); } set { this._xblnr = value; } }

        public string INCO1 { get { return ConverterValue.StringNullToEmpty(this._inco1); } set { this._inco1 = value; } }

        public string WAERS { get { return ConverterValue.StringNullToEmpty(this._waers); } set { this._waers = value; } }

        [NotMapped]
        public string DDEADT { get { return ConverterValue.DateTimeNullableForString(this._ddeadt); } set { this._ddeadt = ConverterValue.StringForDateTimeNullable(value); } }










        
    }
}
