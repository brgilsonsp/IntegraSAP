using DAL.ObjectMessages;
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

    public class UpdateResponseAtualizacaoGTE : UpdateDB<Status>
    {
        /// <summary>
        /// Salva o status do retorno do GTE
        /// </summary>
        /// <param name="registro">Status</param>
        /// <param name="embarque">string</param>
        /// <returns>ID do Status armazenado no banco de dados</returns>
        public int atualizaRegistro(Status registro, string embarque)
        {
            try
            {                
                int idStatusRetorno = SaveStatus(registro, embarque);
                                
                if (idStatusRetorno > 0)
                {
                    //Se possuir detalhes de erro, salva no BD
                    if (registro.ERRORS != null && registro.ERRORS.Count > 0)
                    {
                        SaveError(registro.ERRORS, idStatusRetorno);
                    }
                }
                return idStatusRetorno;
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_SAVE_RESPONSE_ATUALIZACAO_GTE.Replace("?", registro.Mensagem.ToString()),
                    Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        /// <summary>
        /// Salva o Status no BD
        /// </summary>
        /// <param name="registro">Status</param>
        /// <param name="embarque">string</param>
        /// <returns>int</returns>
        private int SaveStatus(Status registro, string embarque)
        {
            ObjectParameter outID = new ObjectParameter("OUTID", typeof(int));
            using (var bd = new BrokerMessageEntities())
            {
                bd.spSalvaRetorno(embarque, registro.CODE, registro.DESC,
                    registro.DataRetorno, registro.Mensagem, outID);
            }
            //Aguarda um período para garantir o encerramento da conexão com o BD
            TimeClosing.ThreadForCloseConnectionDB();
            return (int)outID.Value;
        }

        /// <summary>
        /// Salva os detalhes do erro
        /// </summary>
        /// <param name="errors">List<DescErrors> </param>
        /// <param name="idStatusRetorno">int</param>
        private void SaveError(List<DescErrors> errors, int idStatusRetorno)
        {
            using (var bd = new BrokerMessageEntities())
            {
                foreach (DescErrors error in errors)
                {
                    bd.spDetalheError(idStatusRetorno, error.CODE, error.DESC);
                }
            }
            //Aguarda um período para garantir o encerramento da conexão com o BD
            TimeClosing.ThreadForCloseConnectionDB();
        }
    }
}
