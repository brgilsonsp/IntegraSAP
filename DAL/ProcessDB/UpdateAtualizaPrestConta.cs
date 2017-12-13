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
    public class UpdateAtualizaPrestConta : UpdateDB<PrestacaoContas>
    {
        /// <summary>
        /// Atualiza a tabela TPCK da prestação de contas
        /// </summary>
        /// <param name="registro">PrestacaoContas</param>
        /// <param name="embarque">string</param>
        /// <returns>Retorna a quantidade de registros afetados</returns>
        public int atualizaRegistro(PrestacaoContas registro, string embarque)
        {
            try
            {
                int idEmbarque = new IDEmbarque().getIdEmbarque(embarque);
                int retorno = 0;
                using (var bd = new BrokerMessageEntities())
                {
                    if (registro.SBELN.Equals(embarque))
                    {//Se a Prestação de Contas for igual ao Embarque informado no parâmetro embarque
                        retorno = bd.spAtualizaPrestacaoConta_TPCK(idEmbarque, registro.PCTYP, registro.DOCNR, registro.STATU);
                    }
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                return retorno;
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_ATUALIZA_PC.Replace("?", embarque),
                    Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }
    }
}
