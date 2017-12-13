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
    public class UpdateConsultaPrestacaoContaRealizado
    {
        /// <summary>
        /// Altera a Flag PrestContaEmbarque no Banco de Dados, de um determinado embarque
        /// </summary>
        /// <param name="embarque">string</param>
        /// <returns>Quantidade de registros afetados</returns>
        public int atualizaRegistroPrestConta(string embarque)
        {
            try
            {
                int retorno = 0;
                using (var bd = new BrokerMessageEntities())
                {
                    retorno = bd.spAlterarConsultaPrestContaEmbarqueRealizado(embarque);
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                return retorno;
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", 
                    MessagesOfReturn.ERROR_ALTERA_FLAG_CONSULTA_PREST_CONTA.Replace("?", embarque), Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }
    }
}
