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
    public class NFEREF_TAB_TGTEDUEP
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
        public int? DUEPOSNRBD { get { return this._dueposnr; } set { this._dueposnr = value; } }

        [XmlIgnore]
        [Column("DOCNUM")]
        public int? DOCNUMBD { get { return this._docnum; } set { this._docnum = value; } }

        [XmlIgnore]
        [Column("ITMNUM")]
        public int? ITMNUMBD { get { return this._itmnum; } set { this._itmnum = value; } }
        
        [XmlIgnore]
        [Column("MENGE")]
        public decimal? MENGEBD { get { return this._menge; } set { this._menge = value; } }
        #endregion


        #region private

        private string _dueid;
        private int? _dueposnr;
        private int? _docnum;
        private int? _itmnum;
        private string _nfenum;
        private string _series;
        private string _parid;
        private decimal? _menge;

        #endregion
                
        [XmlElement]
        public string Type { get; set; }

        public string DUEID { get { return ConverterValue.StringNullToEmpty(this._dueid); } set { this._dueid = value; } }

        [NotMapped]
        public string DUEPOSNR { get { return ConverterValue.IntNullableToString(this._dueposnr); } set { this._dueposnr = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string DOCNUM { get { return ConverterValue.IntNullableToString(this._docnum); } set { this._docnum = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string ITMNUM { get { return ConverterValue.IntNullableToString(this._itmnum); } set { this._itmnum = ConverterValue.StringToIntNullable(value); } }
        
        public string NFENUM { get { return ConverterValue.StringNullToEmpty(this._nfenum); } set { this._nfenum = value; } }

        public string SERIES { get { return ConverterValue.StringNullToEmpty(this._series); } set { this._series = value; } }

        public string PARID { get { return ConverterValue.StringNullToEmpty(this._parid); } set { this._parid = value; } }

        [NotMapped]
        public string MENGE { get { return ConverterValue.DecimalNullableToString(this._menge); } set { this._menge = ConverterValue.StringToDecimalNullable(value); } }

    }
}
