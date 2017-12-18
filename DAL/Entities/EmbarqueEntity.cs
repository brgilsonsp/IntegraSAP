using System;

namespace DAL.Entities
{
    public class EmbarqueEntity
    {
        public int Id { get; set; }

        public string SBELN { get; set; }

        public string STCOD { get; set; }

        public string DESCR { get; set; }

        public DateTime? LASTUP { get; set; }

        public bool ConsultaDetalhe { get; set; }

        public bool AtualizaDetalhe { get; set; }

        public bool EnviaPrestConta { get; set; }

        public bool ConsultaPrestConta { get; set; }

        public int IdDadosBroker { get; set; }

        public virtual DadosBroker DadosBroker { get; set; }

    }
}
