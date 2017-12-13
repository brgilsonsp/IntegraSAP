using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerException;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class IDPrestacaConta
    {
        /// <summary>
        /// Obtém o ID da Prestação de Conta do Embarque informado no parâmetro.
        /// Se o parâmetro for nulo ou em branco, retorna a constante Option.IDEmpty
        /// </summary>
        /// <param name="embarque">string</param>
        /// <returns>int com o id da Prestação de Conta ou a constante Option.IDEmpty</returns>
        public int GetIDPrestacaoConta(string embarque)
        {
            try
            {
                if (!string.IsNullOrEmpty(embarque) && !string.IsNullOrWhiteSpace(embarque))
                {                    
                    List<spObtemIDPrestacaoConta_Result> idResult = null;
                    using(var bd = new BrokerMessageEntities())
                    {
                        idResult = bd.spObtemIDPrestacaoConta(embarque).ToList();
                    }
                    //Aguarda um período para garantir o encerramento da conexão com o BD
                    TimeClosing.ThreadForCloseConnectionDB();
                    return GetID(idResult, embarque);
                }
                else
                {
                    string message = string.Format("{0} {1}", MessagesOfReturn.ERROR_OBTER_ID_PC_EMPTY, Environment.NewLine);
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_OBTER_ID_PRESTACAO_CONTA, Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }

        private int GetID(List<spObtemIDPrestacaoConta_Result> idResult, string embarque)
        {
            int idPC = Option.ID_EMPTY;
            if (idResult != null && idResult.Count > 0)
            {
                foreach (spObtemIDPrestacaoConta_Result idR in idResult)
                {
                    if (idR.SBELN.Equals(embarque))
                    {
                        idPC = idR.IDPC;
                        break;
                    }
                }
            }
            return idPC;
        }
    }
}
