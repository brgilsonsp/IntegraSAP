using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    public class CabecalhoDadosBroker
    {        
        public int ID { get; set; }

        [Column("IdCabecalho")]
        public int CabecalhoID { get; set; }

        [Column("IdDadosBroker")]
        public int DadosBrokerID { get; set; }

        [Required]
        public virtual Cabecalho Cabecalho { get; set; }

        [Required]
        public virtual DadosBroker DadosBroker { get; set; }
    }
}
