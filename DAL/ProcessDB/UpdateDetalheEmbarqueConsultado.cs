using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerException;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class UpdateDetalheEmbarqueConsultado
    {
        /// <summary>
        /// Altera a Flag Consultar Detalha do embarque informado no parâmetro para false
        /// </summary>
        /// <param name="embarque">string</param>
        /// <returns>Quantidade de registros afetados</returns>
        public int atualizaRegistroEmbarque(string embarque)
        {
            try
            {
                int retorno = 0;
                using(var bd = new BrokerMessageEntities())
                {
                    retorno = bd.spAlterarDetalheEmbarqueConsultado(embarque);
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                return retorno;
            }
            catch(Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERRO_ALTERA_FLAG_EMBARQUECONSULTADO,
                    Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }   
        }
        
    }
}
