using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class Status
    {
        #region XmlIgnore

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [NotMapped]
        public int idBroker { get; set; }

        [XmlIgnore]
        public byte Mensagem { get; set; }

        [XmlIgnore]
        public string SBELN { get; set; }

        [XmlElement(IsNullable = false)]
        [XmlIgnore]
        public DateTime DataRetorno { get; set; }

        #endregion


        [XmlAttribute]
        [NotMapped]
        public string Type { get; set; }

        public string CODE { get; set; }

        [Column("DESCR")]
        public string DESC { get; set; }

        [XmlElement("ERRORS")]
        [NotMapped]
        public List<Status> ERRORS { get; set; }
    }
}
