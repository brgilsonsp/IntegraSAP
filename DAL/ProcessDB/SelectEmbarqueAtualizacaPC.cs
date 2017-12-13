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
    public class SelectEmbarqueAtualizacaPC : SelectDB<List<Embarque>>
    {
        //public List<Embarque> consultaRegistro(string embarque)
        public List<Embarque> consultaRegistro(Embarque embarqueObj)
        {
            try
            {                
                List<spConsultaEmbarquePrestacaoConta_Result> embarquesResult;
                using(var bd = new BrokerMessageEntities())
                {
                    embarquesResult = bd.spConsultaEmbarquePrestacaoConta().ToList();
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();

                return GetObjeto(embarquesResult);

            }catch(Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULTA_EMBARQUES_PRESTACAO_CONTA, 
                    Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }

        private List<Embarque> GetObjeto(List<spConsultaEmbarquePrestacaoConta_Result> embarquesResult)
        {
            List<Embarque> embarques = null;
            if (embarquesResult != null && embarquesResult.Count > 0)
            {
                embarques = new List<Embarque>();
                foreach (spConsultaEmbarquePrestacaoConta_Result embarquesR in embarquesResult)
                {
                    Embarque cadaEmbarque = new Embarque();
                    cadaEmbarque.IDEmbarque = embarquesR.Id;
                    cadaEmbarque.SBELN = embarquesR.SBELN;
                    cadaEmbarque.IDDadosBroker = (int)embarquesR.IDDadosBroker;
                    embarques.Add(cadaEmbarque);
                }
                return embarques;
            }
            else
            {
                return embarques;
            }
        }
    }
}
