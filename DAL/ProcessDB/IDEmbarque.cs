using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using Util.InnerUtil;
using Util.InnerException;

namespace DAL.ProcessDB
{
    public class IDEmbarque
    {
        /// <summary>
        /// Retorno o ID do embarque informado no parâmetro, se não encontrar o embarque retorna Option.IDEmbarqueIsEmpty.
        /// </summary>
        /// <param name="embarque"></param>
        /// <returns>Retorna o ID do Embarque ou, se não encontrar o embarque, retorna Option.IDEmbarqueIsEmpty.</returns>
        /// <exception cref="Util.InnerException.SelectDBException">Lança a exceção se ocorrer algum erro
        /// ao obter o ID do Embarque no banco de dados</exception>
        /// <exception cref="Exception">Lança a exceção se o parâmetro for nulo, vazio ou em branco</exception>
        public int getIdEmbarque(string embarque)
        {
            try
            {
                if (!string.IsNullOrEmpty(embarque) || !string.IsNullOrWhiteSpace(embarque))
                {
                    int idEmbarque = Option.ID_EMPTY;
                    ObjectParameter outputEmbarque = new ObjectParameter("OUTID", typeof(int));
                    using (var bd = new BrokerMessageEntities())
                    {
                        bd.spObtemIDEmbarque(embarque, outputEmbarque);
                        idEmbarque = (int)outputEmbarque.Value;

                    }
                    //Aguarda um período para garantir o encerramento da conexão com o BD
                    TimeClosing.ThreadForCloseConnectionDB();
                    return idEmbarque;
                }else // Se o parâmetro for nulo, vazio ou em branco, lança uma Exception
                {
                    string message = string.Format("{0} {1}", MessagesOfReturn.ALERT_EMBARQUE_EMPTY, Environment.NewLine);
                    throw new Exception(message);
                }
            }catch(Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_OBTEM_ID_EMBARQUE, Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }
    }
}
