using DAL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.InnerException;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class SelectEmbarquetAtualizaDetalhe : SelectDB<List<Embarque>>
    {
        /// <summary>
        /// Obtém um ou mais Embarques configurado para Atualizar Detalhes. 
        /// Se não localizar nenhum Embarque para Atualizar Detalhes, retorna null.
        /// </summary>
        /// <returns>List<Embarque></returns>
        public List<Embarque> consultaRegistro(Embarque embarqueObj)
        {
            try
            {
                List<spConsultaEmbarquesAtualizarDetalhe_Result> spEmbarquesResult = null;
                using (var bd = new BrokerMessageEntities())
                {
                    spEmbarquesResult = bd.spConsultaEmbarquesAtualizarDetalhe().ToList();
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();

                if (spEmbarquesResult != null && spEmbarquesResult.Count > 0) // Se obter um ou mais registros, retorna a List
                {
                    return getEmbarques(spEmbarquesResult);
                }
                else // Se não obteve nenhum registro, retorna null
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULT_LIST_EMBARQUE_ATUALIZA_DETALHE,
                    Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }

        private List<Embarque> getEmbarques(List<spConsultaEmbarquesAtualizarDetalhe_Result> embarquesResult)
        {
            List<Embarque> embarques = new List<Embarque>();
            foreach (spConsultaEmbarquesAtualizarDetalhe_Result embarqueR in embarquesResult)
            {
                Embarque emb = new Embarque();
                emb.IDEmbarque = embarqueR.ID;
                emb.SBELN = embarqueR.SBELN;
                emb.IDDadosBroker = (int)embarqueR.IdDadosBroker;
                embarques.Add(emb);
            }
            return embarques;
        }
    }
}
