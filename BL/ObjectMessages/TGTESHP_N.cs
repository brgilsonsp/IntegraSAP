using System;
using System.Collections.Generic;
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
    public class TGTESHP_N
    {
        #region Only DataBase

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }

        [XmlIgnore]
        [Column("FKDAT")]
        public DateTime? FKDATBD { get { return this._fkdat; } set { this._fkdat = value; } }

        [XmlIgnore]
        [Column("SBELP")]
        public int? SBELPDB { get { return this._sbelp; } set { this._sbelp = value; } }

        [XmlIgnore]
        [Column("NBELP")]
        public int? NBELPDB { get { return this._nbelp; } set { this._nbelp = value; } }

        [XmlIgnore]
        [Column("ITMFAT")]
        public decimal? ITMFATDB { get { return this._itmfat; } set { this._itmfat = value; } }

        [XmlIgnore]
        [Column("QTDITM")]
        public decimal? QTDITMDB { get { return this._qtditm; } set { this._qtditm = value; } }

        [XmlIgnore]
        [Column("NETPR")]
        public decimal? NETPRDB { get { return this._netpr; } set { this._netpr = value; } }

        [XmlIgnore]
        [Column("KPEIN")]
        public decimal? KPEINDB { get { return this._kpein; } set { this._kpein = value; } }

        [XmlIgnore]
        [Column("NETWR")]
        public decimal? NETWRDB { get { return this._netwr; } set { this._netwr = value; } }

        [XmlIgnore]
        [Column("FRTLOC")]
        public decimal? FRTLOCDB { get { return this._frtloc; } set { this._frtloc = value; } }

        [XmlIgnore]
        [Column("FRTINT")]
        public decimal? FRTINTDB { get { return this._frtint; } set { this._frtint = value; } }

        [XmlIgnore]
        [Column("SEGINT")]
        public decimal? SEGINTDB { get { return this._segint; } set { this._segint = value; } }

        [XmlIgnore]
        [Column("PRCFOB")]
        public decimal? PRCFOBDB { get { return this._prcfob; } set { this._prcfob = value; } }

        [XmlIgnore]
        [Column("PRCEXW")]
        public decimal? PRCEXWDB { get { return this._prcexw; } set { this._prcexw = value; } }

        [XmlIgnore]
        [Column("PCTCOM")]
        public decimal? PCTCOMDB { get { return this._pctcom; } set { this._pctcom = value; } }

        [XmlIgnore]
        [Column("VLRCOM")]
        public decimal? VLRCOMDB { get { return this._vlrcom; } set { this._vlrcom = value; } }

        [XmlIgnore]
        [Column("ITMRE")]
        public int? ITMREDB { get { return this._itmre; } set { this._itmre = value; } }

        [XmlIgnore]
        [Column("BRGEW")]
        public decimal? BRGEWDB { get { return this._brgew; } set { this._brgew = value; } }

        [XmlIgnore]
        [Column("NTGEW")]
        public decimal? NTGEWDB { get { return this._ntgew; } set { this._ntgew = value; } }

        [XmlIgnore]
        [Column("VOLUM")]
        public decimal? VOLUMDB { get { return this._volum; } set { this._volum = value; } }

        [XmlIgnore]
        [Column("NETPRORI")]
        public decimal? NETPRORIDB { get { return this._netprori; } set { this._netprori = value; } }

        [XmlIgnore]
        [Column("KPEINORI")]
        public decimal? KPEINORIDB { get { return this._kpeinori; } set { this._kpeinori = value; } }

        [XmlIgnore]
        [Column("NETWRORI")]
        public decimal? NETWRORIDB { get { return this._netwrori; } set { this._netwrori = value; } }

        #endregion

        #region private
        
        private int? _sbelp;        
        private int? _nbelp;        
        private decimal? _itmfat;        
        private decimal? _qtditm;        
        private decimal? _netpr;        
        private decimal? _kpein;        
        private decimal? _netwr;        
        private decimal? _frtloc;        
        private decimal? _frtint;        
        private decimal? _segint;        
        private decimal? _prcfob;        
        private decimal? _prcexw;        
        private decimal? _pctcom;        
        private decimal? _vlrcom;        
        private int? _itmre;        
        private decimal? _brgew;        
        private decimal? _ntgew;        
        private decimal? _volum;        
        private decimal? _netprori;        
        private decimal? _kpeinori;        
        private decimal? _netwrori;        
        private DateTime? _fkdat;
        private string _docfat;
        private string _matnr;
        private string _maktx;
        private string _meins;
        private string _renum;
        private string _enqdm;
        private string _gewei;
        private string _voleh;
        private string _steuc;
        private string _naladish;
        private string _fabitm;
        private string _atocon;
        private string _amccptc;
        private string _brccptc;
        private string _ccrom;
        private string _fabriluf;
        private string _meinsori;
        private string _prod;

        #endregion
        
        [XmlAttribute]
        [Column("TypeTGTESHPN")]
        public string Type { get; set; }

        [NotMapped]
        [XmlElement(IsNullable = true)]
        public string SBELN { get; set; }

        [NotMapped]
        public string SBELP { get { return ConverterValue.IntNullableToString(this._sbelp); } set { this._sbelp = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string NBELP { get { return ConverterValue.IntNullableToString(this._nbelp); } set { this._nbelp = ConverterValue.StringToIntNullable(value); } }
                
        public string DOCFAT { get { return ConverterValue.StringNullToEmpty(this._docfat); } set { this._docfat = value; } }

        [NotMapped]
        public string ITMFAT { get { return ConverterValue.DecimalNullableToString(this._itmfat); } set { this._itmfat = ConverterValue.StringToDecimalNullable(value); } }
        
        public string MATNR { get { return ConverterValue.StringNullToEmpty(this._matnr); } set { this._matnr = value; } }

        public string MAKTX { get { return ConverterValue.StringNullToEmpty(this._maktx); } set { this._maktx = value; } }

        [XmlElement("MAKTX_TEXT")]
        public virtual List<MAKTX_TEXT> MAKTX_TEXT { get; set; }

        [NotMapped]
        public string QTDITM { get { return ConverterValue.DecimalNullableToString(this._qtditm); } set { this._qtditm = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string NETPR { get { return ConverterValue.DecimalNullableToString(this._netpr); } set { this._netpr = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string KPEIN { get { return ConverterValue.DecimalNullableToString(this._kpein); } set { this._kpein = ConverterValue.StringToDecimalNullable(value); } }

        public string MEINS { get { return ConverterValue.StringNullToEmpty(this._meins); } set { this._meins = value; } }

        [NotMapped]
        public string NETWR { get { return ConverterValue.DecimalNullableToString(this._netwr); } set { this._netwr = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string FRTLOC { get { return ConverterValue.DecimalNullableToString(this._frtloc); } set { this._frtloc = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string FRTINT { get { return ConverterValue.DecimalNullableToString(this._frtint); } set { this._frtint = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string SEGINT { get { return ConverterValue.DecimalNullableToString(this._segint); } set { this._segint = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string PRCFOB { get { return ConverterValue.DecimalNullableToString(this._prcfob); } set { this._prcfob = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string PRCEXW { get { return ConverterValue.DecimalNullableToString(this._prcexw); } set { this._prcexw = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string PCTCOM { get { return ConverterValue.DecimalNullableToString(this._pctcom); } set { this._pctcom = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string VLRCOM { get { return ConverterValue.DecimalNullableToString(this._vlrcom); } set { this._vlrcom = ConverterValue.StringToDecimalNullable(value); } }

        public string RENUM { get { return ConverterValue.StringNullToEmpty(this._renum); } set { this._renum = value; } }

        [NotMapped]
        public string ITMRE { get { return ConverterValue.IntNullableToString(this._itmre); } set { this._itmre = ConverterValue.StringToIntNullable(value); } }

        public string ENQDM { get { return ConverterValue.StringNullToEmpty(this._enqdm); } set { this._enqdm = value; } }

        [NotMapped]
        public string BRGEW { get { return ConverterValue.DecimalNullableToString(this._brgew); } set { this._brgew = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string NTGEW { get { return ConverterValue.DecimalNullableToString(this._ntgew); } set { this._ntgew = ConverterValue.StringToDecimalNullable(value); } }

        public string GEWEI { get { return ConverterValue.StringNullToEmpty(this._gewei); } set { this._gewei = value; } }

        [NotMapped]
        public string VOLUM { get { return ConverterValue.DecimalNullableToString(this._volum); } set { this._volum = ConverterValue.StringToDecimalNullable(value); } }
                
        public string VOLEH { get { return ConverterValue.StringNullToEmpty(this._voleh); } set { this._voleh = value; } }

        public string STEUC { get { return ConverterValue.StringNullToEmpty(this._steuc); } set { this._steuc = value; } }

        public string NALADISH { get { return ConverterValue.StringNullToEmpty(this._naladish); } set { this._naladish = value; } }

        public string FABITM { get { return ConverterValue.StringNullToEmpty(this._fabitm); } set { this._fabitm = value; } }

        public string ATOCON { get { return ConverterValue.StringNullToEmpty(this._atocon); } set { this._atocon = value; } }

        public string AMCCPTC { get { return ConverterValue.StringNullToEmpty(this._amccptc); } set { this._amccptc = value; } }

        public string BRCCPTC { get { return ConverterValue.StringNullToEmpty(this._brccptc); } set { this._brccptc = value; } }

        public string CCROM { get { return ConverterValue.StringNullToEmpty(this._ccrom); } set { this._ccrom = value; } }

        public string FABRILUF { get { return ConverterValue.StringNullToEmpty(this._fabriluf); } set { this._fabriluf = value; } }

        [NotMapped]
        public string NETPRORI { get { return ConverterValue.DecimalNullableToString(this._netprori); } set { this._netprori = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string KPEINORI { get { return ConverterValue.DecimalNullableToString(this._kpeinori); } set { this._kpeinori = ConverterValue.StringToDecimalNullable(value); } }

        public string MEINSORI { get { return ConverterValue.StringNullToEmpty(this._meinsori); } set { this._meinsori = value; } }

        [NotMapped]
        public string NETWRORI { get { return ConverterValue.DecimalNullableToString(this._netwrori); } set { this._netwrori = ConverterValue.StringToDecimalNullable(value); } }

        public string PROD { get { return ConverterValue.StringNullToEmpty(this._prod); } set { this._prod = value; } }

        [NotMapped]
        public string FKDAT { get { return ConverterValue.DateTimeNullableForString(this._fkdat); } set { this._fkdat = ConverterValue.StringForDateTimeNullable(value); } }


    }
}
