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
    public class SelectAtualizaPrestacaConta : SelectDB<Msg4AtualizaPrestacaoConta>
    {
        public Msg4AtualizaPrestacaoConta consultaRegistro(Embarque embarqueObj)
        {
            String embarque = embarqueObj.SBELN;
            try
            {
                Msg4AtualizaPrestacaoConta atualizaPC = null;
                List<spConsultaRequest_Result> dadosBrokerResult = null;
                List<spConsultaAtualizacaoPC_TPCK_Result> listPCKResult = null;
                List<spConsultaAtualizacaoPC_TXPNS_Result> listTXPNSResult = null;
                using(var bd = new BrokerMessageEntities())
                {
                    //Obtém os dados da Request para a Mensagem 4
                    dadosBrokerResult = bd.spConsultaRequest(Option.MENSAGEM4, embarqueObj.IDDadosBroker).ToList();
                    //Obtém a Prestação de Conta do Embarque no BD, tabela PCK
                    listPCKResult = bd.spConsultaAtualizacaoPC_TPCK(embarque).ToList();
                    //Obtem as Informações de Despesas da Prestação de Conta do Embarque, tabela TXPNS
                    listTXPNSResult = bd.spConsultaAtualizacaoPC_TXPNS(embarque).ToList();
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();

                //Não localizou os registros necessários
                if ((dadosBrokerResult != null && dadosBrokerResult.Count > 0) && 
                        (listPCKResult != null && listPCKResult.Count > 0))
                {
                    atualizaPC = dadosBroker(dadosBrokerResult, Option.MENSAGEM4);
                    atualizaPC.REQUEST.PCK = listPCK(listPCKResult, embarque, listTXPNSResult);
                }
                
                if(atualizaPC != null && atualizaPC.REQUEST != null && atualizaPC.REQUEST.PCK != null) 
                {//Se obteve os registros necessários para Prestação de Contas, retorna o objeto
                    return atualizaPC;
                }
                else//Se não localizou os dados da Prestação de Contas, retorna nulo
                {
                    return null;
                }
                
            }catch(Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULTA_PRESTACA_CONTA.Replace("?", embarque),
                    Environment.NewLine);
                throw new SelectDBException(msg, ex);
            }
        }

        /// <summary>
        /// Extrai os dados do Broker
        /// </summary>
        /// <param name="dadosBrokerResult">List<spConsultaRequest_Result></param>
        /// <param name="mensagem">byte</param>
        /// <returns>AtualizaPrestacaConta</returns>
        private Msg4AtualizaPrestacaoConta dadosBroker (List<spConsultaRequest_Result> dadosBrokerResult, byte mensagem) {
            Msg4AtualizaPrestacaoConta atualizaPC = null;
            foreach(spConsultaRequest_Result dadosBrokerR in dadosBrokerResult)
            {
                if (dadosBrokerR != null)
                {
                    if (dadosBrokerR.Mensagem == mensagem)
                    {
                        atualizaPC = new Msg4AtualizaPrestacaoConta();
                        RequestMsg4 request = new RequestMsg4();
                        STR str = new STR();
                        request.Type = dadosBrokerR.RquestType;
                        request.ACAO = dadosBrokerR.ACAO;
                        request.IDBR = dadosBrokerR.IDBR;
                        request.IDCL = dadosBrokerR.IDCL;
                        request.SHKEY = dadosBrokerR.SHKEY;

                        str.Type = dadosBrokerR.STRType;
                        str.XMLVR = dadosBrokerR.XMLVR;
                        str.ENVRM = dadosBrokerR.ENVRM;
                        str.INTNR = dadosBrokerR.INTNR;

                        atualizaPC.EDX = dadosBrokerR.EDX;
                        atualizaPC.REQUEST = request;
                        atualizaPC.REQUEST.STR = str;
                    }
                }
            }
            return atualizaPC;
        }

        /// <summary>
        /// Extra os dados da Prestação de Contas
        /// </summary>
        /// <param name="listPCKResult">List<spConsultaAtualizacaoPC_PCK_Result> </param>
        /// <param name="embarque">string</param>
        /// <returns>PrestacaoContas</returns>
        private List<PrestacaoContas> listPCK(List<spConsultaAtualizacaoPC_TPCK_Result> listPCKResult, string embarque,
            List<spConsultaAtualizacaoPC_TXPNS_Result> listTXPNSResult) {
            List<PrestacaoContas> listPCAtualiza = new List<PrestacaoContas>();
            foreach(spConsultaAtualizacaoPC_TPCK_Result listPCKR in listPCKResult)
            {
                if (listPCKR != null)
                {
                    if (listPCKR.SBELN.Equals(embarque))
                    {
                        PrestacaoContas pcAtualiza = new PrestacaoContas();
                        pcAtualiza = new PrestacaoContas();
                        pcAtualiza.Type = listPCKR.TPCK_TypePCK;
                        pcAtualiza.SBELN = listPCKR.SBELN;
                        pcAtualiza.DOCNR = listPCKR.TPCK_DOCNR;
                        pcAtualiza.PCTYP = listPCKR.TPCK_PCTYP;
                        pcAtualiza.PARID = listPCKR.TPCK_PARID;
                        pcAtualiza.BLDAT = ConfigureDate.converDateTimeForDateString(listPCKR.TPCK_BLDAT);
                        pcAtualiza.XBLNR = listPCKR.TPCK_XBLNR;
                        pcAtualiza.ZUONR = listPCKR.TPCK_ZUONR;
                        pcAtualiza.BKTXT = listPCKR.TPCK_BKTXT;
                        pcAtualiza.SGTXT = listPCKR.TPCK_SGTXT;
                        pcAtualiza.ZFBDT = ConfigureDate.converDateTimeForDateString(listPCKR.TPCK_ZFBDT);
                        pcAtualiza.ABLFD = ConfigureDate.converDateTimeForDateString(listPCKR.TPCK_ABLFD);
                        pcAtualiza.STATU = listPCKR.TPCK_STATU;
                        pcAtualiza.TXPNS = listTXPNS(listTXPNSResult, embarque);

                        listPCAtualiza.Add(pcAtualiza);
                    }
                }
            }
            return listPCAtualiza;
        }

        /// <summary>
        /// Extrai os dados das Informações de Despesas da Prestaçao de Contas
        /// </summary>
        /// <param name="listTXPNSResult">List<spConsultaAtualizacaoPC_TXPNS_Result></param>
        /// <param name="embarque">string</param>
        /// <returns>InfoDespesas</returns>
        private List<InfoDespesas>  listTXPNS(List<spConsultaAtualizacaoPC_TXPNS_Result> listTXPNSResult, string embarque) {
            List<InfoDespesas> listInfoDesp = new List<InfoDespesas>();
            foreach(spConsultaAtualizacaoPC_TXPNS_Result listTXPNSR in listTXPNSResult)
            {
                if (listTXPNSR != null)
                {
                    if (listTXPNSR.SBELN.Equals(embarque))
                    {
                        InfoDespesas infoDesp = new InfoDespesas();
                        infoDesp.Type = listTXPNSR.TXPNS_TypeTXPNS;
                        infoDesp.KSCHL = (string.IsNullOrEmpty(listTXPNSR.TXPNS_KSCHL) ? "" : listTXPNSR.TXPNS_KSCHL);
                        infoDesp.NETWR = ((listTXPNSR.TXPNS_NETWR == null) ? 00 : listTXPNSR.TXPNS_NETWR);

                        listInfoDesp.Add(infoDesp);
                    }
                }
            }
            return listInfoDesp;
        }
    }
}
