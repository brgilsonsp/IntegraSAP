using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Entities
{
    public class CabecalhoDadosBrokerEntity
    {
        
        public int ID { get; set; }

        [Column("IdCabecalho")]
        public int CabecalhoID { get; set; }

        [Column("IdDadosBroker")]
        public int DadosBrokerID { get; set; }

        [Required]
        public virtual CabecalhoEntity Cabecalho { get; set; }

        [Required]
        public virtual DadosBroker DadosBroker { get; set; }
    }
}
