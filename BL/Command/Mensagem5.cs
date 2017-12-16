using BL.Business;
using DAL.ObjectMessages;
using DAL.ProcessDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerUtil;

namespace BL.Command
{
    class Mensagem5 : Mensagem, SaveData<Msg5RetornoConsultaPrestacaConta, ConsultaGTE>
    {
        public string SwapXmlWithGTE(ConfigureService configureService)
        {
            string msgReturn = "";
            //Verifica se existe Prestação de Contas para Consultar
            SelectDB<List<ConsultaGTE>> obtemConsultaPrestaContas = new SelectConsultaPrestConta();
            List<ConsultaGTE> listaEmbarque = obtemConsultaPrestaContas.consultaRegistro(null);
            if (listaEmbarque != null && listaEmbarque.Count > 0)
            {//Possui Embarque para efetuar a Consulta de Prestação de Conta
                msgReturn = executeSwapXML(listaEmbarque, configureService);
            }
            else //Não existe Embarque pendente para Consulta de Prestação de Contas
            {
                msgReturn = string.Format("{0} {1}", MessagesOfReturn.ALERT_CONSULTA_PRESTACAO_CONTA_EMPTY,
                    Environment.NewLine);
            }
            return msgReturn;
        }

        /// <summary>
        /// Executa a troca da Mensagem como GTE e trata o retorno
        /// </summary>
        /// <param name="listEmbarque">List<ConsultaGTE></param>
        /// <returns>string</returns>
        private string executeSwapXML(List<ConsultaGTE> listEmbarque, ConfigureService configureService)
        {
            string msgReturn = "";
            foreach (ConsultaGTE embarque in listEmbarque)
            {
                if (embarque != null && !string.IsNullOrEmpty(embarque.REQUEST.SBELN) &&
                    !string.IsNullOrWhiteSpace(embarque.REQUEST.SBELN))
                {
                    string xmlResponse = SwapWithGTE(embarque, configureService);

                    //Desserializa o Xml Response
                    ObjectForDB<Msg5RetornoConsultaPrestacaConta> objectForDB = new ObjectForDB<Msg5RetornoConsultaPrestacaConta>();
                    Msg5RetornoConsultaPrestacaConta retornoConsultaGTE = objectForDB.deserializeXmlForDB(xmlResponse);

                    if (retornoConsultaGTE != null && retornoConsultaGTE.RESPONSE.PCK != null)
                    {//Obteve alguma resposta do GTE

                        if (retornoConsultaGTE.RESPONSE.STATUS != null)
                        {//Possui alguma Resposta refetente a Consulta Prestação de Conta
                            retornoConsultaGTE.RESPONSE.STATUS.DataRetorno = ConfigureDate.ActualDate;
                            retornoConsultaGTE.RESPONSE.STATUS.Mensagem = Option.MENSAGEM5;
                            if (retornoConsultaGTE.RESPONSE.PCK.Count > 0)
                            {//Dados da Consulta da Prestação de Contas recebido com sucesso
                                msgReturn += SaveResponseSuccess(retornoConsultaGTE, embarque);
                            }
                            else // Não recebeu os dados da Consulta da Prestação de Conta, porém retornou uma mensagem
                            {
                                msgReturn += SaveResponseAlerta(retornoConsultaGTE.RESPONSE.STATUS, embarque.REQUEST.SBELN);
                            }
                        }
                        else //Não recebeu nenhuma resposta de Status
                        {
                            msgReturn += SaveResponseError(xmlResponse, embarque.REQUEST.SBELN);
                        }
                    }
                    else// Objeto retornoConsultaGTE não obteve nenhum dado do GTE
                    {
                        msgReturn += string.Format("{0} {1}",
                            MessagesOfReturn.ALERT_ATUALIZA_PC_EMPTY.Replace("?", embarque.REQUEST.SBELN),
                            Environment.NewLine);
                    }
                    
                    //Atualiza o Response no banco de dados
                    new UpdateConsultaPrestacaoContaRealizado().atualizaRegistroPrestConta(embarque.REQUEST.SBELN);
                }
                else //Embarque específico em branco
                {
                    msgReturn = string.Format("{0} {1}", MessagesOfReturn.ALERT_EMBARQUE_PRESTACAO_CONTA_EMPTY,
                    Environment.NewLine);
                }
            }
            return msgReturn;
        }

        /// <summary>
        /// Executa a troca de Mensagem com o GTE e retorna o Response
        /// </summary>
        /// <param name="embarque">ConsultaGTE</param>
        /// <returns>string com o response do GTE</returns>
        private string SwapWithGTE(ConsultaGTE embarque, ConfigureService configureService)
        {
            SaveXMLOriginal saveXml = new SaveXMLOriginal();
            //Serializa  XML Request
            XmlForGTE<ConsultaGTE> xmlForGTE = new XmlForGTE<ConsultaGTE>();
            string xmlRequest = xmlForGTE.serializeXmlForGTE(embarque);
            saveXml.SaveXML(new ExportationMessageRequest(xmlRequest, embarque.REQUEST.SBELN, 5, configureService));

            //Envio o Xml Request e recebe o Xml Response
            ComunicaGTE comunicaGTE = new ComunicaGTE();            
            string xmlResponse = comunicaGTE.doRequestGTE(xmlRequest);
            saveXml.SaveXML(new ExportationMessageResponse(xmlResponse, embarque.REQUEST.SBELN, 5, configureService));

            

            return xmlResponse;
        }

        /// <summary>
        /// Trata o Response Sucesso do GTE
        /// </summary>
        /// <param name="retornoConsultaGTE">Msg5RetornoConsultaPrestacaConta</param>
        /// <param name="embarque">ConsultaGTE</param>
        /// <returns>string com o log</returns>
        public string SaveResponseSuccess(Msg5RetornoConsultaPrestacaConta retornoConsultaGTE, ConsultaGTE embarque)
        {
            string msgReturn = "";
            foreach(PrestacaoContas pck in retornoConsultaGTE.RESPONSE.PCK)
            {
                string retPCTYP = pck.PCTYP.Trim();
                if (retPCTYP.Equals(Option.PCTYP_AD))
                {
                    //Salva tabela TXPNS
                    msgReturn += SaveTXPNS(pck, retornoConsultaGTE.RESPONSE.STATUS, embarque);
                }
                else if (retPCTYP.Equals(Option.PCTYP_PC))
                {
                    //Atualiza tabela TPCK 
                    msgReturn += UpdateTPCK(pck, retornoConsultaGTE.RESPONSE.STATUS, embarque);
                }
                else
                {
                    msgReturn += string.Format("{0} {1}", MessagesOfReturn.ERROR_PC_NO_INFO.Replace("?", embarque.REQUEST.SBELN),
                        Environment.NewLine);
                }
            }
            return msgReturn;            
        }

        /// <summary>
        /// Salva o Status do Response
        /// </summary>
        /// <param name="status">Status</param>
        /// <param name="embarque">string</param>
        /// <returns>string com o log</returns>
        public string SaveResponseAlerta(Status status, string embarque)
        {
            new UpdateResponseAtualizacaoGTE().atualizaRegistro(status, embarque);

            return string.Format("{0} {1}", MessagesOfReturn.ALERT_CONSULTA_PC_EMPTY.Replace("?", embarque),
                Environment.NewLine);
        }

        /// <summary>
        /// Trata o Response Error do GTE
        /// </summary>
        /// <param name="xmlResponse">string</param>
        /// <param name="embarque">string</param>
        /// <returns>string com o log</returns>
        public string SaveResponseError(string xmlResponse, string embarque)
        {
            ObjectForDB<RetornoFatalErrorGTE> errorGTE = new ObjectForDB<RetornoFatalErrorGTE>();
            RetornoFatalErrorGTE retornoError = errorGTE.deserializeXmlForDB(xmlResponse);
            retornoError.DataRetorno = ConfigureDate.ActualDate;
            retornoError.Mensagem = Option.MENSAGEM5;
            new UpdateResponseAtualizacaoGTE().atualizaRegistro(retornoError.Status, embarque);

            return string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULTA_PC_ESTRUTURA.Replace("?", embarque),
                Environment.NewLine);
        }

        /// <summary>
        /// Salva a tabela TXPNS
        /// </summary>
        /// <param name="pck">PrestacaoContas</param>
        /// <param name="embarque">ConsultaGTE</param>
        /// <returns>string</returns>
        private string SaveTXPNS(PrestacaoContas pck, Status status, ConsultaGTE embarque)
        {
            int retorno = new UpdateSalvaPrestContaTXPNS().atualizaRegistro(pck, embarque.REQUEST.SBELN);
            if (retorno > 0)
            {
                //Salva o status
                new UpdateResponseAtualizacaoGTE().atualizaRegistro(status, embarque.REQUEST.SBELN);
                return string.Format("{0} {1}",
                    MessagesOfReturn.SUCCESS_SALVA_PRESTACAO_CONTA_TXPNS.Replace("?", embarque.REQUEST.SBELN),
                    Environment.NewLine);
            }
            else
            {
                return PCIncorrect(embarque);
            }
        }

        /// <summary>
        /// Atualiza a tabela TPCK
        /// </summary>
        /// <param name="pck">PrestacaoContas</param>
        /// <param name="embarque">ConsultaGTE</param>
        /// <returns>string</returns>
        private string UpdateTPCK(PrestacaoContas pck, Status status,ConsultaGTE embarque)
        {
            int retorno = new UpdateAtualizaPrestConta().atualizaRegistro(pck, embarque.REQUEST.SBELN);
            //Alimenta o Log
            if (retorno > 0)
            {
                //Salva o status
                new UpdateResponseAtualizacaoGTE().atualizaRegistro(status, embarque.REQUEST.SBELN);
                return string.Format("{0} {1}",
                    MessagesOfReturn.SUCCESS_CONSULTA_PRESTACAO_CONTA.Replace("?", embarque.REQUEST.SBELN),
                    Environment.NewLine);
            }
            else
            {
                return PCIncorrect(embarque);
            }
        }

        /// <summary>
        /// Cria um status e salva no banco de dados
        /// </summary>
        /// <param name="embarque"></param>
        /// <returns></returns>
        private string PCIncorrect(ConsultaGTE embarque)
        {
            Status status = new Status();
            status.DataRetorno = ConfigureDate.ActualDate;
            status.Mensagem = Option.MENSAGEM5;
            status.CODE = MessagesOfReturn.CODE_INTERN;
            status.DESC = MessagesOfReturn.DESC_INTER_PC;
            SaveResponseAlerta(status, embarque.REQUEST.SBELN);
            return string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_PC_INCORRECT.Replace("?", embarque.REQUEST.SBELN), Environment.NewLine);
        }
    }
}
