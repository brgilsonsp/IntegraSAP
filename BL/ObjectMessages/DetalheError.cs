using BL.ObjectMessages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.ObjectMessages
{
    public class DetalheError
    {
        public int ID { get; set; }

        public string CODE { get; set; }

        public string DESCR { get; set; }

        [Column("IdStatusRetorno")]
        public int StatusId { get; set; }

        [Required]
        public virtual Status Status { get; set; }

        public DetalheError() {   }

        public DetalheError(Status errorReturn, Status statusRetorno)
        {
            this.Status = statusRetorno;
            if (errorReturn != null)
            {
                this.CODE = errorReturn.CODE;
                this.DESCR = errorReturn.DESC;
            }
            else
            {
                this.CODE = "Código não informado";
                this.DESCR = "Descrição não informada";
            }
        }
    }
}
