using System.ComponentModel.DataAnnotations;

namespace BL.Entities
{
    public class DetalheError
    {
        public int Id { get; set; }

        public string CODE { get; set; }

        public string DESCR { get; set; }

        [Key]
        public int StatusRetornoId { get; set; }

        [Required]
        public virtual StatusRetorno StatusRetorno { get; set; }
    }
}
