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

        [XmlIgnore]
        private int? _stmcode;
        [XmlIgnore]
        private int? _lmtdttime;
        [XmlIgnore]
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
