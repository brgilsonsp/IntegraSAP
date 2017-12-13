using DAL.ObjectMessages;
using System;
using System.Linq;
using Util.InnerException;
using Util.InnerUtil;
using System.Collections.Generic;

namespace DAL.ProcessDB
{
    public class SelectListaEmbarqueBD : SelectDB<List<ConsultaGTE>>
    {
        public List<ConsultaGTE> consultaRegistro(Embarque embarqueObj)
        {
            try
            {
                List<spConsultaListaEmbarque_Result> retornoBD = null;
                using (var bd = new BrokerMessageEntities())
                {
                    //Obtém no banco de dados os dados necessários para efetuar o Resquest
                    var regConsultaLista = bd.spConsultaListaEmbarque();
                    retornoBD = regConsultaLista.ToList();
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();
                if (retornoBD != null && retornoBD.Count > 0)
                {
                    //Instancia e retorna um ojeto Msg1ConsultaListaEmbarque
                    return getObj(retornoBD);
                }
                else // Se não retornou nenhum registro, retorna null
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULTA_LISTA_EMBARQUE_DB, Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }

        /// <summary>
        /// Instancia um objeto Msg1ConsultaListaEmbarque com os dados dos registros do banco dados.
        /// Se não localizar o registro da Mensagem1 retorna null.
        /// </summary>
        /// <param name="registro">List<spConsultaListaEmbarque_Result></param>
        /// <returns>Msg1ConsultaListaEmbarque</returns>
        private List<ConsultaGTE> getObj(List<spConsultaListaEmbarque_Result> registro)
        {
            List<ConsultaGTE> listConsultaListaEmbarque = new List<ConsultaGTE>();
            foreach (spConsultaListaEmbarque_Result embarque in registro)
            {
                if (embarque.Mensagem.Equals(Option.MENSAGEM1))
                {
                    ConsultaGTE consultaListaEmbarque = new ConsultaGTE();
                    RequestConsultaGTE request = new RequestConsultaGTE();
                    request.Type = embarque.RquestType;
                    request.ACAO = embarque.ACAO;
                    request.IDBR = embarque.IDBR;
                    request.IDCL = embarque.IDCL;
                    request.SHKEY = embarque.SHKEY;
                    request.IDDadosBroker = embarque.IDDadosBroker;
                    STR str = new STR();
                    str.Type = embarque.STRType;
                    str.XMLVR = embarque.XMLVR;
                    str.ENVRM = embarque.ENVRM;
                    str.INTNR = embarque.INTNR;
                    request.STR = str;
                    consultaListaEmbarque.REQUEST = request;
                    consultaListaEmbarque.EDX = embarque.EDX;
                    listConsultaListaEmbarque.Add(consultaListaEmbarque);
                }
            }
            return listConsultaListaEmbarque;
        }
    }
}
