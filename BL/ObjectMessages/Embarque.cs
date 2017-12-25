using System;
using System.Xml.Serialization;
using BL.InnerUtil;
using BL.ObjectMessages;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    public class Embarque
    {
        #region XmlIgnore
        [XmlIgnore]
        private DateTime? _LASTUP_Date;
        [XmlIgnore]
        private bool _consultaDetalhe;
        [XmlIgnore]
        private bool _atualizaDetalhe;
        [XmlIgnore]
        private bool _enviaPrestConta;
        [XmlIgnore]
        private bool _consultaPrestConta;

        [XmlIgnore]
        public int ID { get; set; }

        [Column("IdDadosBroker")][XmlIgnore]
        public int DadosBrokerID { get; set; }

        [XmlIgnore]
        public virtual DadosBroker DadosBroker { get; set; }

        [XmlElement(IsNullable = false)][Column("LASTUP")][XmlIgnore]
        public DateTime? LASTUP_Date
        {
            get
            {
                if (_LASTUP_Date == null) return ConfigureDate.convertDateStringForDateTime(LASTUP);
                else return _LASTUP_Date;
            }
            set { _LASTUP_Date = value; }
        }

        [XmlIgnore]
        public bool ConsultaDetalhe { get { return _consultaDetalhe; } set { _consultaDetalhe = value; } }

        [XmlIgnore]
        public bool AtualizaDetalhe { get { return _atualizaDetalhe; } set { _atualizaDetalhe = value; } }

        [XmlIgnore]
        public bool EnviaPrestConta { get { return _enviaPrestConta; } set { _enviaPrestConta = value; } }

        [XmlIgnore]
        public bool ConsultaPrestConta { get { return _consultaPrestConta; } set { _consultaPrestConta = value; } }

        #endregion

        [XmlAttribute]
        [NotMapped]
        public string Type { get; set; }

        public string SBELN { get; set; }

        public string STCOD { get; set; }

        public string DESCR { get; set; }

        [NotMapped]
        public string LASTUP { get; set; }

        [NotMapped]
        public string LASTHR { get; set; }

        [NotMapped]
        public string BFMAR { get; set; }

        [NotMapped]
        public int IDEmbarque { get; set; }

    }
}
