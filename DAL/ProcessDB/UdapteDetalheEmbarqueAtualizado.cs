using DAL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerException;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class UdapteDetalheEmbarqueAtualizado : UpdateDB<Embarque>
    {
        /// <summary>
        /// Altera a flag, no banco de dados, do Embarque para Já Atualizado.
        /// </summary>
        /// <param name="idEmbarque">int</param>
        /// <param name="embarque">string</param>
        /// <returns>Retorna a quantidade de registro afetados</returns>
        /// <exception cref="UpdateDBException">Lança a exceção se ocorrer erro.</exception>
        public int atualizaRegistro(Embarque registro, string embarque)
        {
            try
            {
                int idEmbarque = new IDEmbarque().getIdEmbarque(embarque);
                int retorno = 0;
                using (var bd = new BrokerMessageEntities())
                {
                    retorno = bd.spAlterarDetalheEmbarqueAtualizado(idEmbarque);
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                return retorno;
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_ALTERA_DETALHE_EMBARQUE_ATUALIZADO.Replace("?", embarque), Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }
    }
}
