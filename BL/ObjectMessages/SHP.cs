using BL.InnerUtil;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class SHP
    {
        #region only DB
        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDMain")]
        public int MainID { get; set; }

        [XmlIgnore]
        public virtual MAIN Main { get; set; }

        #endregion

        #region private

        private string _type;
        private string _sbelp;
        private string _xbeln;
        private string _xbelp;
        private string _nbelp;
        private string _xblnr;
        private string _knttp;
        private string _epstp;
        private string _matnr;
        private string _maktx;
        private string _mengee;
        private string _netpr;
        private string _netwr;
        private string _waers;
        private string _peinh;
        private string _meins;
        private string _nladh;
        private string _nalda;
        private string _aladi;
        private string _adicao;
        private string _seqad;
        private string _bprme;
        private string _j_1bnbm;
        private string _charg;
        private string _lgort;
        private string _werks;
        private string _ekgrp;
        private string _ntgew;
        private string _brgew;
        private string _ntgcv;
        private string _brgcv;
        private string _gewei;
        private string _volum;
        private string _volcv;
        private string _voleh;
        private string _mfrnr;
        private string _lifnr;
        private string _zterm;
        private string _inco1;
        private string _li;
        private string _linum;
        private string _lidat;
        private string _lidef;
        private string _ndrbck;
        private string _mwskz;
        private string _free;
        private string _contnum;
        private string _orig;
        private string _mdtyp;
        private string _field1;
        private string _field2;
        private string _field3;
        private string _field4;
        private string _cb1;
        private string _cb2;
        private string _cb3;
        private string _cb4;
        #endregion

        [XmlAttribute]
        public string Type { get { return ConverterValue.StringNullToEmpty(this._type); } set { this._type = value; } }

        [NotMapped]
        public string SBELN { get; set; }

        public string SBELP { get { return ConverterValue.StringNullToEmpty(this._sbelp); } set { this._sbelp = value; } }

        public string XBELN { get { return ConverterValue.StringNullToEmpty(this._xbeln); } set { this._xbeln = value; } }

        public string XBELP { get { return ConverterValue.StringNullToEmpty(this._xbelp); } set { this._xbelp = value; } }

        public string NBELP { get { return ConverterValue.StringNullToEmpty(this._nbelp); } set { this._nbelp = value; } }

        public string XBLNR { get { return ConverterValue.StringNullToEmpty(this._xblnr); } set { this._xblnr = value; } }

        public string KNTTP { get { return ConverterValue.StringNullToEmpty(this._knttp); } set { this._knttp = value; } }

        public string EPSTP { get { return ConverterValue.StringNullToEmpty(this._epstp); } set { this._epstp = value; } }

        public string MATNR { get { return ConverterValue.StringNullToEmpty(this._matnr); } set { this._matnr = value; } }

        public string MAKTX { get { return ConverterValue.StringNullToEmpty(this._maktx); } set { this._maktx = value; } }

        [XmlElement("MAKTX_TEXT")]
        public List<MAKTX_TEXT_SHP> MAKTX_TEXT { get; set; }

        public string MENGEE { get { return ConverterValue.StringNullToEmpty(this._mengee); } set { this._mengee = value; } }

        public string NETPR { get { return ConverterValue.StringNullToEmpty(this._netpr); } set { this._netpr = value; } }

        public string NETWR { get { return ConverterValue.StringNullToEmpty(this._netwr); } set { this._netwr = value; } }

        public string WAERS { get { return ConverterValue.StringNullToEmpty(this._waers); } set { this._waers = value; } }

        public string PEINH { get { return ConverterValue.StringNullToEmpty(this._peinh); } set { this._peinh = value; } }

        public string MEINS { get { return ConverterValue.StringNullToEmpty(this._meins); } set { this._meins = value; } }

        public string NLADH { get { return ConverterValue.StringNullToEmpty(this._nladh); } set { this._nladh = value; } }

        public string NALDA { get { return ConverterValue.StringNullToEmpty(this._nalda); } set { this._nalda = value; } }

        public string ALADI { get { return ConverterValue.StringNullToEmpty(this._aladi); } set { this._aladi = value; } }

        public string ADICAO { get { return ConverterValue.StringNullToEmpty(this._adicao); } set { this._adicao = value; } }

        public string SEQAD { get { return ConverterValue.StringNullToEmpty(this._seqad); } set { this._seqad = value; } }

        public string BPRME { get { return ConverterValue.StringNullToEmpty(this._bprme); } set { this._bprme = value; } }
        
        public string J_1BNBM { get { return ConverterValue.StringNullToEmpty(this._j_1bnbm); } set { this._j_1bnbm = value; } }

        public string CHARG { get { return ConverterValue.StringNullToEmpty(this._charg); } set { this._charg = value; } }

        public string LGORT { get { return ConverterValue.StringNullToEmpty(this._lgort); } set { this._lgort = value; } }

        public string WERKS { get { return ConverterValue.StringNullToEmpty(this._werks); } set { this._werks = value; } }

        public string EKGRP { get { return ConverterValue.StringNullToEmpty(this._ekgrp); } set { this._ekgrp = value; } }

        public string NTGEW { get { return ConverterValue.StringNullToEmpty(this._ntgew); } set { this._ntgew = value; } }

        public string BRGEW { get { return ConverterValue.StringNullToEmpty(this._brgew); } set { this._brgew = value; } }

        public string NTGCV { get { return ConverterValue.StringNullToEmpty(this._ntgcv); } set { this._ntgcv = value; } }

        public string BRGCV { get { return ConverterValue.StringNullToEmpty(this._brgcv); } set { this._brgcv = value; } }

        public string GEWEI { get { return ConverterValue.StringNullToEmpty(this._gewei); } set { this._gewei = value; } }

        public string VOLUM { get { return ConverterValue.StringNullToEmpty(this._volum); } set { this._volum = value; } }

        public string VOLCV { get { return ConverterValue.StringNullToEmpty(this._volcv); } set { this._volcv = value; } }

        public string VOLEH { get { return ConverterValue.StringNullToEmpty(this._voleh); } set { this._voleh = value; } }

        public string MFRNR { get { return ConverterValue.StringNullToEmpty(this._mfrnr); } set { this._mfrnr = value; } }

        public string LIFNR { get { return ConverterValue.StringNullToEmpty(this._lifnr); } set { this._lifnr = value; } }

        public string ZTERM { get { return ConverterValue.StringNullToEmpty(this._zterm); } set { this._zterm = value; } }

        public string INCO1 { get { return ConverterValue.StringNullToEmpty(this._inco1); } set { this._inco1 = value; } }

        public string LI { get { return ConverterValue.StringNullToEmpty(this._li); } set { this._li = value; } }

        public string LINUM { get { return ConverterValue.StringNullToEmpty(this._linum); } set { this._linum = value; } }

        public string LIDAT { get { return ConverterValue.StringNullToEmpty(this._lidat); } set { this._lidat = value; } }

        public string LIDEF { get { return ConverterValue.StringNullToEmpty(this._lidef); } set { this._lidef = value; } }

        public string NDRBCK { get { return ConverterValue.StringNullToEmpty(this._ndrbck); } set { this._ndrbck = value; } }

        public string MWSKZ { get { return ConverterValue.StringNullToEmpty(this._mwskz); } set { this._mwskz = value; } }

        public string FREE { get { return ConverterValue.StringNullToEmpty(this._free); } set { this._free = value; } }

        public string CONTNUM { get { return ConverterValue.StringNullToEmpty(this._contnum); } set { this._contnum = value; } }

        public string ORIG { get { return ConverterValue.StringNullToEmpty(this._orig); } set { this._orig = value; } }

        public string MDTYP { get { return ConverterValue.StringNullToEmpty(this._mdtyp); } set { this._mdtyp = value; } }

        public string FIELD1 { get { return ConverterValue.StringNullToEmpty(this._field1); } set { this._field1 = value; } }

        public string FIELD2 { get { return ConverterValue.StringNullToEmpty(this._field2); } set { this._field2 = value; } }

        public string FIELD3 { get { return ConverterValue.StringNullToEmpty(this._field3); } set { this._field3 = value; } }

        public string FIELD4 { get { return ConverterValue.StringNullToEmpty(this._field4); } set { this._field4 = value; } }

        public string CB1 { get { return ConverterValue.StringNullToEmpty(this._cb1); } set { this._cb1 = value; } }

        public string CB2 { get { return ConverterValue.StringNullToEmpty(this._cb2); } set { this._cb2 = value; } }

        public string CB3 { get { return ConverterValue.StringNullToEmpty(this._cb3); } set { this._cb3 = value; } }

        public string CB4 { get { return ConverterValue.StringNullToEmpty(this._cb4); } set { this._cb4 = value; } }

        [XmlElement("NFSK")]
        public List<NFSK> NFSK { get; set; }

        [XmlElement("TTAX")]
        public List<TTAX> TTAX { get; set; }

        [XmlElement("INVP")]
        public List<INVP> INVP { get; set; }

        [XmlElement("CHARGS")]
        public List<CHARGS> CHARGS { get; set; }
    }
}

