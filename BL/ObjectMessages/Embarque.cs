using System;
using System.Xml.Serialization;
using BL.InnerUtil;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    public class Embarque
    {
        #region only DB
        
        [XmlIgnore]
        public int ID { get; set; }

        [Column("IdDadosBroker")]
        [XmlIgnore]
        public int DadosBrokerID { get; set; }

        [XmlIgnore]
        public virtual DadosBroker DadosBroker { get; set; }

        [XmlIgnore]
        public string Tipo { get; set; }

        [Column("LASTUP")]
        [XmlIgnore]
        public DateTime? LASTUPDB { get { return this._lastup; } set { this._lastup = value; } }

        [XmlIgnore]
        public bool ConsultaDetalhe { get { return _consultaDetalhe; } set { _consultaDetalhe = value; } }

        [XmlIgnore]
        public bool AtualizaDetalhe { get { return _atualizaDetalhe; } set { _atualizaDetalhe = value; } }

        [XmlIgnore]
        public bool EnviaPrestConta { get { return _enviaPrestConta; } set { _enviaPrestConta = value; } }

        [XmlIgnore]
        public bool ConsultaPrestConta { get { return _consultaPrestConta; } set { _consultaPrestConta = value; } }

        #endregion


        #region private

        private DateTime? _lastup;
        private bool _consultaDetalhe;
        private bool _atualizaDetalhe;
        private bool _enviaPrestConta;
        private bool _consultaPrestConta;

        #endregion

        [XmlAttribute]
        [NotMapped]
        public string Type { get; set; }

        public string SBELN { get; set; }

        public string STCOD { get; set; }

        public string DESCR { get; set; }

        [NotMapped]
        public string LASTUP { get { return ConverterValue.DateTimeNullableForString(this._lastup); } set { this._lastup = ConverterValue.StringForDateTimeNullable(value); } }

        [NotMapped]
        public string LASTHR { get; set; }

        public string BFMAR { get; set; }

        public override string ToString()
        {
            return $"Embarque: {SBELN}";
        }

    }
}
