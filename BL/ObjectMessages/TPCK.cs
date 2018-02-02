using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using BL.InnerUtil;

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
    public class TPCK
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
        [Column("ABLFD")]
        public DateTime? ABLFDDB { get { return this._ablfd; } set { this._ablfd = value; } }
        
        [XmlIgnore]
        [Column("BLDAT")]
        public DateTime? BLDATDB { get { return this._bldat; } set { this._bldat = value; } }
        
        [XmlIgnore]
        [Column("ZFBDT")]
        public DateTime? ZFBDTDB { get { return this._zfbdt; } set { this._zfbdt = value; } }

        #endregion
        
        #region private
        
        private DateTime? _ablfd;
        private DateTime? _bldat;
        private DateTime? _zfbdt;
        private Embarque _embarque;
        private string _docnr;
        private string _pctyp;
        private string _parid;
        private string _xblnr;
        private string _zuonr;
        private string _bktxt;
        private string _sgtxt;
        private string _statu;

        #endregion


        [XmlAttribute]
        [Column("TypePCK")]
        public string Type { get; set; }

        [XmlElement(Order = 1)]
        [NotMapped]
        public string SBELN { get; set; }
        
        [XmlElement(Order = 2)]
        public string DOCNR { get { return ConverterValue.StringNullToEmpty(this._docnr); } set { this._docnr = value; } }

        [XmlElement(Order = 3)]
        public string PCTYP { get { return ConverterValue.StringNullToEmpty(this._pctyp); } set { this._pctyp = value; } }

        [XmlElement(Order = 4)]
        public string PARID { get { return ConverterValue.StringNullToEmpty(this._parid); } set { this._parid = value; } }

        [XmlElement(Order = 5)]
        [NotMapped]
        public string BLDAT { get { return ConverterValue.DateTimeNullableForString(this._bldat); } set { this._bldat = ConverterValue.StringForDateTimeNullable(value); } }

        [XmlElement(Order = 6)]
        public string XBLNR { get { return ConverterValue.StringNullToEmpty(this._xblnr); } set { this._xblnr = value; } }

        [XmlElement(Order = 7)]
        public string ZUONR { get { return ConverterValue.StringNullToEmpty(this._zuonr); } set { this._zuonr = value; } }

        [XmlElement(Order = 8)]
        public string BKTXT { get { return ConverterValue.StringNullToEmpty(this._bktxt); } set { this._bktxt = value; } }

        [XmlElement(Order = 9)]
        public string SGTXT { get { return ConverterValue.StringNullToEmpty(this._sgtxt); } set { this._sgtxt = value; } }

        [XmlElement(Order = 10)]
        [NotMapped]
        public string ZFBDT { get { return ConverterValue.DateTimeNullableForString(this._zfbdt); } set { this._zfbdt = ConverterValue.StringForDateTimeNullable(value); } }

        [XmlElement(Order = 11)]
        [NotMapped]
        public string ABLFD { get { return ConverterValue.DateTimeNullableForString(this._ablfd); } set { this._ablfd = ConverterValue.StringForDateTimeNullable(value); } }

        [XmlElement(Order = 12)]
        public string STATU { get { return ConverterValue.StringNullToEmpty(this._statu); } set { this._statu = value; } }

        [XmlElement("TXPNS", Order = 13)]
        public List<TXPNS> TXPNS { get; set; }
    }
}
