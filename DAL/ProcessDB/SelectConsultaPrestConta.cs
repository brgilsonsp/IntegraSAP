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
    public class SelectConsultaPrestConta : SelectDB<List<ConsultaGTE>>
    {
        public List<ConsultaGTE> consultaRegistro(Embarque embarqueObj)
        {
            try
            {
                List<spConsultaPC_Result> embarquesPCConsultResult = null;
                using (var bd = new BrokerMessageEntities())
                {
                    var spEmbarque = bd.spConsultaPC();
                    embarquesPCConsultResult = spEmbarque.ToList();
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();

                if (embarquesPCConsultResult != null && embarquesPCConsultResult.Count > 0)
                {
                    return getObj(embarquesPCConsultResult);
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULTA_LISTA_PRESTACAO_CONTA_CONSULTA,
                    Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }

        private List<ConsultaGTE> getObj(List<spConsultaPC_Result> embarquesPCConsultResult)
        {
            List<ConsultaGTE> listaEmbarque = new List<ConsultaGTE>();
            foreach (spConsultaPC_Result registro in embarquesPCConsultResult)
            {
                if (registro.Mensagem.Equals(Option.MENSAGEM5))
                {
                    ConsultaGTE cadaEmbarque = new ConsultaGTE();
                    RequestConsultaGTE cadaRequest = new RequestConsultaGTE();
                    STR cadaStr = new STR();
                    cadaStr.Type = registro.STRType;
                    cadaStr.XMLVR = registro.XMLVR;
                    cadaStr.ENVRM = registro.ENVRM;
                    cadaStr.INTNR = registro.INTNR;
                    cadaRequest.Type = registro.RequestType;
                    cadaRequest.ACAO = registro.ACAO;
                    cadaRequest.IDBR = registro.IDBR;
                    cadaRequest.IDCL = registro.IDCL;
                    cadaRequest.SHKEY = registro.SHKEY;
                    cadaRequest.STR = cadaStr;
                    cadaRequest.SBELN = registro.SBELN;
                    cadaEmbarque.EDX = registro.EDX;
                    cadaEmbarque.REQUEST = cadaRequest;

                    listaEmbarque.Add(cadaEmbarque);
                }
            }
            return listaEmbarque;
        }
    }
}
