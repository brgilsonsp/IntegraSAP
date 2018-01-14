using BL.InnerUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    public class Status
    {
        public Status() { }

        public Status(ResponseError responseError)
        {
            CODE = responseError.CODE;
            DESC = responseError.DESC;
        }

        #region only DB

        [XmlIgnore]
        public int ID { get; set; }

        [XmlIgnore]
        [NotMapped]
        public int idBroker { get; set; }

        [XmlIgnore]
        public byte Mensagem { get; set; }

        [XmlIgnore]
        public string SBELN { get; set; }
        
        [XmlIgnore]
        public DateTime DataRetorno
        {
            get
            {
                return this._dataretorno.CompareTo(ConfigureDate.DateMin) <= 0 ? ConfigureDate.ActualDate : this._dataretorno;
            }
            set { this._dataretorno = value; }
        }

        [XmlIgnore]
        public string Tipo { get; set; }

        #endregion

        #region private

        private DateTime _dataretorno;

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
