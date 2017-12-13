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
    public class UpdatePrestacaoContaEmbarqueAtualizado : UpdateDB<Embarque>
    {
        /// <summary>
        /// Altera a flag do Embarque para Prestação de Conta Atualizado
        /// </summary>
        /// <param name="registro">Embarque</param>
        /// <param name="embarque">string</param>
        /// <returns>Quantidade de registros afetados</returns>
        public int atualizaRegistro(Embarque registro, string embarque)
        {
            try
            {
                int retorno = 0;
                using(var bd = new BrokerMessageEntities())
                {
                    retorno = bd.spAlterarEnviaPrestContaEmbarqueAtualizado(embarque);
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                return retorno;
            }
            catch(Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_UPDATE_PC_EMBARQUE_ATUALIZADO.Replace("?", embarque), Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }
    }
}
