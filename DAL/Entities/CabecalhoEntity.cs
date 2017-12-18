using System.Collections.Generic;

namespace DAL.Entities
{
    public class CabecalhoEntity
    {
        public int ID { get; set; }

        public string RequestType { get; set; }

        public string MensagemEDX { get; set; }

        public string ACAO { get; set; }

        public byte Mensagem { get; set; }

        public virtual IList<CabecalhoDadosBrokerEntity> DadosBroker { get; set; }
    }
}
