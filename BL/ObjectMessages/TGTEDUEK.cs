using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class TGTEDUEK
    {
        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [Column("IDEmbarque")]
        public int EmbarqueID { get; set; }

        [XmlIgnore]
        public virtual Embarque Embarque { get; set; }
        #endregion


        [XmlAttribute]
        public string Type { get; set; }
        public string DUEID { get; set; }
        public string XLOCEMBARQ { get; set; }
        public string XLOCDESPACHO { get; set; }

        public int? CDRAD { get; set; }
        public int? EMRAD { get; set; }
        public decimal? LATITUDE { get; set; }
        public decimal? LONGITUDE { get; set; }
        public int? CDRAE { get; set; }
        public int? EMRAE { get; set; }
        public int? CNPJ_DESP { get; set; }
        public string WAERS { get; set; }
        public string INCO1 { get; set; }

        [XmlElement("ADDRESS_TAB")]
        public virtual List<ADDRESS_TAB_TGTEDUEK> ADDRESS_TAB { get; set; }

        [XmlElement("ADDINFO_TAB")]
        public virtual List<ADDINFO_TAB_TGTEDUEK> ADDINFO_TAB { get; set; }
    }   
}
