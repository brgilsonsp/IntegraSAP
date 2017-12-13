using DAL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class UpdateSalvaPrestContaTXPNS : UpdateDB<PrestacaoContas>
    {
        /// <summary>
        /// Atualiza a tabela TXPNS da prestação de contas
        /// </summary>
        /// <param name="registro">PrestacaoContas</param>
        /// <param name="embarque">string</param>
        /// <returns>Quantidade de registro afetados</returns>
        public int atualizaRegistro(PrestacaoContas registro, string embarque)
        {
            try
            {
                int retorno = 0;
                using (var bd = new BrokerMessageEntities())
                {
                    int idPC = new IDPrestacaConta().GetIDPrestacaoConta(embarque);
                    foreach (InfoDespesas txpns in registro.TXPNS)
                    {
                        retorno = bd.spAtualizaPrestacaoConta_TXPNS(idPC, txpns.KSCHL, txpns.NETWR);
                    }
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                return retorno;
            }
            catch(Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_SAVE_PC_TXPNS, Environment.NewLine);
                throw new UpdateException(msg, ex);
            }
        }
    }
}
