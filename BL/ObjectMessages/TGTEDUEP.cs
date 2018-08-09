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
    public class TGTEDUEP
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
        [Column("DUEPOSNR")]
        public int? DUEPOSNRDB { get { return this._dueposnr; } set { this._dueposnr = value; } }

        [XmlIgnore]
        [Column("DUEITM")]
        public int? DUEITMDB { get { return this._dueitm; } set { this._dueitm = value; } }

        [XmlIgnore]
        [Column("PRCFOB")]
        public decimal? PRCFOBDB { get { return this._prcfob; } set { this._prcfob = value; } }

        [XmlIgnore]
        [Column("MENGE")]
        public decimal? MENGEDB { get { return this._menge; } set { this._menge = value; } }

        [XmlIgnore]
        [Column("NETWR")]
        public decimal? NETWRDB { get { return this._netwr; } set { this._netwr = value; } }

        [XmlIgnore]
        [Column("MENGE_TRIB")]
        public decimal? MENGE_TRIBDB { get { return this._menge_trib; } set { this._menge_trib = value; } }

        [XmlIgnore]
        [Column("NTGEW")]
        public decimal? NTGEWDB { get { return this._ntgew; } set { this._ntgew = value; } }

        [XmlIgnore]
        [Column("PRVTPCODE")]
        public int? PRVTPCODEDB { get { return this._prvtpcode; } set { this._prvtpcode = value; } }

        [XmlIgnore]
        [Column("PCTCOM")]
        public decimal? PCTCOMDB { get { return this._pctcom; } set { this._pctcom = value; } }

        [XmlIgnore]
        [Column("TPCDREM")]
        public int? TPCDREMDB { get { return this._tpcdrem; } set { this._tpcdrem = value; } }

        [XmlIgnore]
        [Column("CNPJCPF")]
        public long? CNPJCPFDB { get { return this._cnpjcpf; } set { this._cnpjcpf = value; } }

        [XmlIgnore]
        [Column("CPNJCPFEXP")]
        public long? CPNJCPFEXPDB { get { return this._cpnjcpfexp; } set { this._cpnjcpfexp = value; } }

        #endregion

        #region private

        private string _dueid;
        private int? _dueposnr;
        private string _duenum;
        private int? _dueitm;
        private string _rucnum;
        private decimal? _prcfob;
        private string _cdlandd;
        private decimal? _menge;
        private decimal? _netwr;
        private decimal? _menge_trib;
        private decimal? _ntgew;
        private string _enqdm;
        private string _prvdocid;
        private int? _prvtpcode;
        private decimal? _pctcom;
        private string _chavenfe;
        private int? _tpcdrem;
        private long? _cnpjcpf;
        private string _chavenf_form;
        private string _cdnfr;
        private long? _cpnjcpfexp;

        #endregion


        [XmlAttribute]
        public string Type { get; set; }

        public string DUEID { get { return ConverterValue.StringNullToEmpty(this._dueid); } set { this._dueid = value; } }

        [NotMapped]
        public string DUEPOSNR { get { return ConverterValue.IntNullableToString(this._dueposnr); } set { this._dueposnr = ConverterValue.StringToIntNullable(value); } }

        public string DUENUM { get { return ConverterValue.StringNullToEmpty(this._duenum); } set { this._duenum = value; } }

        [NotMapped]
        public string DUEITM { get { return ConverterValue.IntNullableToString(this._dueitm); } set { this._dueitm = ConverterValue.StringToIntNullable(value); } }

        public string RUCNUM { get { return ConverterValue.StringNullToEmpty(this._rucnum); } set { this._rucnum = value; } }
                
        [NotMapped]
        public string PRCFOB { get { return ConverterValue.DecimalNullableToString(this._prcfob); } set { this._prcfob = ConverterValue.StringToDecimalNullable(value); } }

        public string CDLANDD { get { return ConverterValue.StringNullToEmpty(this._cdlandd); } set { this._cdlandd = value; } }

        [NotMapped]
        public string MENGE { get { return ConverterValue.DecimalNullableToString(this._menge); } set { this._menge = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string NETWR { get { return ConverterValue.DecimalNullableToString(this._netwr); } set { this._netwr = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string MENGE_TRIB { get { return ConverterValue.DecimalNullableToString(this._menge_trib); } set { this._menge_trib = ConverterValue.StringToDecimalNullable(value); } }

        [NotMapped]
        public string NTGEW { get { return ConverterValue.DecimalNullableToString(this._ntgew); } set { this._ntgew = ConverterValue.StringToDecimalNullable(value); } }

        public string ENQDM { get { return ConverterValue.StringNullToEmpty(this._enqdm); } set { this._enqdm = value; } }

        public string PRVDOCID { get { return ConverterValue.StringNullToEmpty(this._prvdocid); } set { this._prvdocid = value; } }

        [NotMapped]
        public string PRVTPCODE { get { return ConverterValue.IntNullableToString(this._prvtpcode); } set { this._prvtpcode = ConverterValue.StringToIntNullable(value); } }
        
        [NotMapped]
        public string PCTCOM { get { return ConverterValue.DecimalNullableToString(this._pctcom); } set { this._pctcom = ConverterValue.StringToDecimalNullable(value); } }

        public string CHAVENFE { get { return ConverterValue.StringNullToEmpty(this._chavenfe); } set { this._chavenfe = value; } }

        [NotMapped]
        public string TPCDREM { get { return ConverterValue.IntNullableToString(this._tpcdrem); } set { this._tpcdrem = ConverterValue.StringToIntNullable(value); } }

        [NotMapped]
        public string CNPJCPF { get { return ConverterValue.LongNullableToString(this._cnpjcpf); } set { this._cnpjcpf = ConverterValue.StringToLongNullable(value); } }

        public string CHAVENF_FORM { get { return ConverterValue.StringNullToEmpty(this._chavenf_form); } set { this._chavenf_form = value; } }

        public string CDNFR { get { return ConverterValue.StringNullToEmpty(this._cdnfr); } set { this._cdnfr = value; } }

        [NotMapped]
        public string CPNJCPFEXP { get { return ConverterValue.LongNullableToString(this._cpnjcpfexp); } set { this._cpnjcpfexp = ConverterValue.StringToLongNullable(value); } }

        [XmlElement("ADDINFO_TAB")]
        public List<ADDINFO_TAB_TGTEDUEP> ADDINFO_TAB { get; set; }

        [XmlElement("NFEREF_TAB")]
        public List<NFEREF_TAB_TGTEDUEP> NFEREF_TAB { get; set; }

        [XmlElement("ATOCON_TAB")]
        public List<ATOCON_TAB_TGTEDUEP> ATOCON_TAB { get; set; }

        [XmlElement("DUEATRIB_TAB")]
        public List<DUEATRIB_TAB_TGTEDUEP> DUEATRIB_TAB { get; set; }
    }
    
}
