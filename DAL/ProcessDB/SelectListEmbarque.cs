using DAL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.InnerException;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class SelectListEmbarque : SelectDB<List<ConsultaGTE>>
    {
        public List<ConsultaGTE> consultaRegistro(Embarque embarque)
        {
            try
            {
                List<spConsultaEmbarque_Result> registros = null;
                using (var bd = new BrokerMessageEntities())
                {
                    registros = bd.spConsultaEmbarque().ToList();
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                if (registros != null && registros.Count > 0) // Se retornar algum registro do BD retorna a List
                {
                    return getObj(registros);
                }
                else // Se não retornar nenhum registro do BD retorna nulo
                {
                    return null;
                }
            }catch(Exception ex)
            {
                string msg = string.Format("{0}{1}", MessagesOfReturn.ERROR_CONSULTA_EMBARQUE_DB, Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }

        private List<ConsultaGTE> getObj(List<spConsultaEmbarque_Result> registros)
        {
            List<ConsultaGTE> listaEmbarque = new List<ConsultaGTE>();
            foreach(spConsultaEmbarque_Result registro in registros)
            {
                if (registro.Mensagem.Equals(Option.MENSAGEM2))
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
