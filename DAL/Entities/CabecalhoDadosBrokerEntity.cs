namespace DAL.Entities
{
    public class CabecalhoDadosBrokerEntity
    {
        public int ID { get; set; }

        public int CabecalhoID { get; set; }

        public virtual CabecalhoEntity Cabecalho { get; set; }

        public int DadosBrokerID { get; set; }

        public virtual DadosBroker DadosBroker { get; set; }
    }
}
