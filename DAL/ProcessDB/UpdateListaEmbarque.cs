using DAL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Util.InnerException;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class UpdateListaEmbarque : UpdateDB<ListaEmbarque>
    {
        /// <summary>
        /// Salva no banco de dados os embarques recebidos do GTE
        /// </summary>
        /// <param name="registro">ListaEmbarque</param>
        /// <param name="embarque">string</param>
        /// <returns>Quantidade de embarques salvo</returns>
        public int atualizaRegistro(ListaEmbarque registro, string embarque)
        {
            List<Embarque> embarques = registro.Embarques;
            try
            {
                int retorno = 0;
                using (var bd = new BrokerMessageEntities())
                {
                    foreach (Embarque cadaEmbarque in embarques)
                    {
                        retorno += SaveEmbarque(bd, cadaEmbarque);
                    }
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                return retorno;
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_UPDATE_LISTA_EMBARQUE_DB, Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        private int SaveEmbarque(BrokerMessageEntities bd, Embarque cadaEmbarque)
        {
            try
            {
                return bd.spSalvaEmbarque(cadaEmbarque.SBELN, cadaEmbarque.STCOD, cadaEmbarque.DESCR, 
                    cadaEmbarque.LASTUP_Date, cadaEmbarque.IDDadosBroker);
            }
            catch (Exception ex)
            {
                SqlException sqlEx = ex.InnerException as SqlException;
                if (!(sqlEx.Number == 2601 || sqlEx.Number == 2627))//Embarque salvo, ignora a exceçao
                {
                    throw new Exception();
                }
                return 0;
            }
        }
    }
}
