using System;

namespace BL.Entities
{
    public class StatusRetorno
    {
        public int ID { get; set; }

        public string CODE { get; set; }

        public string DESCR { get; set; }

        public DateTime DataRetorno { get; set; }

        public int Mensagem { get; set; }

        public string SBELN { get; set; }

        //public int DetalheErrorID { get; set; }

        public virtual DetalheError DetalheError { get; set; }
    }
}
