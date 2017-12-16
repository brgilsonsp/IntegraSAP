using DAL.ProcessDB;
using DAL.ObjectMessages;
using BL.Business;
using Util.InnerUtil;
using System;
using System.Collections.Generic;

namespace BL.Command
{
    class Mensagem1 : Mensagem, SaveData<Msg1RetornoListaEmbarque, Status>
    {
        public string SwapXmlWithGTE(ConfigureService configureService)
        {
            string retorno = "";
            //Obtém o objeto com os dados necessário para efetuar uma requisição ao Web Service
            SelectDB<List<ConsultaGTE>> objetoConsulta = new SelectListaEmbarqueBD();
            List<ConsultaGTE> listaConsultaListaEmbarque = objetoConsulta.consultaRegistro(null);
            foreach (ConsultaGTE consultaListaEmbarque in listaConsultaListaEmbarque)
            {
                if (consultaListaEmbarque != null)
                {
                    retorno += ExecuteSwapXml(consultaListaEmbarque, configureService);
                }
                else // Não localizou os dados necessários para efetuar o Request
                {
                    retorno += string.Format("{0} {1}", MessagesOfReturn.ALERT_DATA_REQUEST_NOT_FOUND, Environment.NewLine);
                }
            }
            return retorno;
        }

        /// <summary>
        /// Executa a troca de mensagem com o Web Service e trata o Response
        /// </summary>
        /// <param name="consultaListaEmbarque">Msg1ConsultaListaEmbarque</param>
        /// <returns>string</returns>
        private string ExecuteSwapXml(ConsultaGTE consultaListaEmbarque, ConfigureService configureService)
        {
            string msgReturn = "";

            string xmlResponse = SwapWithGTE(consultaListaEmbarque, configureService);

            //Desserializa o XML da resposta do Web Service em um objeto
            ObjectForDB<Msg1RetornoListaEmbarque> retornoListaEmbarque = new ObjectForDB<Msg1RetornoListaEmbarque>();
            Msg1RetornoListaEmbarque objectRetornoListaEmbarque = retornoListaEmbarque.deserializeXmlForDB(xmlResponse);

            if (objectRetornoListaEmbarque != null)
            {
                AlimentaIdDadosBroker(objectRetornoListaEmbarque, consultaListaEmbarque.REQUEST.IDDadosBroker);
                Status status = GetStatus(objectRetornoListaEmbarque);
                if (objectRetornoListaEmbarque.RESPONSE.ListaEmbarque != null &&
                    objectRetornoListaEmbarque.RESPONSE.ListaEmbarque.Embarques.Count > 0)
                {//Recebeu os Embarques do GTE
                    msgReturn = SaveResponseSuccess(objectRetornoListaEmbarque, status);
                }
                else if (objectRetornoListaEmbarque.RESPONSE.ListaEmbarque != null &&
                    objectRetornoListaEmbarque.RESPONSE.ListaEmbarque.Embarques.Count == 0)
                { // Não recebeu os Embarques do GTE, GTE retornou mensagem de erro
                    new UpdateResponseAtualizacaoGTE().atualizaRegistro(status, null);
                    msgReturn = string.Format("{0} {1}", MessagesOfReturn.ALERT_RESPONSE_CONSULTA_EMBARQUE_EMPTY,
                        Environment.NewLine);
                }
                else if (objectRetornoListaEmbarque.RESPONSE.ListaEmbarque == null)
                {// GTE retornou mensagem de Erro de estrutura do XML
                    ObjectForDB<RetornoFatalErrorGTE> objectFatalError = new ObjectForDB<RetornoFatalErrorGTE>();
                    RetornoFatalErrorGTE retornoFatalError = objectFatalError.deserializeXmlForDB(xmlResponse);
                    retornoFatalError.DataRetorno = ConfigureDate.ActualDate;
                    retornoFatalError.Mensagem = Option.MENSAGEM1;
                    new UpdateResponseAtualizacaoGTE().atualizaRegistro(retornoFatalError.Status, null);
                    msgReturn = string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULT_LISTA_EMBARQUE_ESTRUTURA,
                        Environment.NewLine);
                }
                else // Se não recebeu nenhum Embarque do GTE
                {
                    msgReturn = string.Format("{0} {1}", MessagesOfReturn.ALERT_RETORNO_CONSULTA_LISTA_EMBARQUE,
                        Environment.NewLine);
                }
            }
            else// Não recebeu nenhum Embarque ou não foi possível desserializar o Xml e não lançou nenhum exception
            {
                msgReturn = string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULTA_EMBARQUE_NULL,
                    Environment.NewLine);
            }

            return msgReturn;
        }

        /// <summary>
        /// Executa a troca de Mensagem como GTE e retorno o Response
        /// </summary>
        /// <param name="dadosConsulta">ConsultaGTE</param>
        /// <returns>string com o response do GTE</returns>
        private string SwapWithGTE(ConsultaGTE dadosConsulta, ConfigureService configureService)
        {
            //Obtém a string xml serializada para efetuar uma requisição ao Web Service
            XmlForGTE<ConsultaGTE> configureXml = new XmlForGTE<ConsultaGTE>();
            string xmlRequest = configureXml.serializeXmlForGTE(dadosConsulta);
            new SaveXMLOriginal().SaveXML(new ExportationMessageRequest(xmlRequest, "ListaEmbarque", 1,configureService));

            //Efetua a requisição e recebe a resposta do Web Service
            ComunicaGTE comunicaGTE = new ComunicaGTE();
            string xmlResponse = comunicaGTE.doRequestGTE(xmlRequest);
            new SaveXMLOriginal().SaveXML(new ExportationMessageResponse(xmlResponse, "ListaEmbarque", 1, configureService));

            return xmlResponse;
        }

        /// <summary>
        /// Alimentado o ID do CNPJ ao Embarque
        /// </summary>
        /// <param name="msg1">DAL.ObjectMessages.Msg1RetornoListaEmbarque</param>
        /// <param name="idCabecalho">int</param>
        private void AlimentaIdDadosBroker(Msg1RetornoListaEmbarque msg1, int idCabecalho)
        {
            foreach(Embarque cadaEmbarque in msg1.RESPONSE.ListaEmbarque.Embarques)
            {
                cadaEmbarque.IDDadosBroker = idCabecalho;
            }
        }

        /// <summary>
        /// Obtém o Status do GTE, caso contrário cria um Status interno
        /// </summary>
        /// <param name="objectRetorno">Msg1RetornoListaEmbarque</param>
        /// <returns>Status</returns>
        private Status GetStatus(Msg1RetornoListaEmbarque objectRetorno)
        {
            Status status;
            if (objectRetorno.RESPONSE.STATUS != null)
            {
                status = objectRetorno.RESPONSE.STATUS;
                status.Mensagem = Option.MENSAGEM1;
                status.DataRetorno = ConfigureDate.ActualDate;
            }
            else
            {
                status = new Status();
                status.CODE = MessagesOfReturn.INTERN_CODE;
                status.DESC = MessagesOfReturn.DESC_CODE;
                status.DataRetorno = ConfigureDate.ActualDate;
                status.Mensagem = Option.MENSAGEM1;
            }
            return status;
        }

        /// <summary>
        /// Trata os Embarques recebidos do GTE
        /// </summary>
        /// <param name="objectRetornoListaEmbarque">Msg1RetornoListaEmbarque</param>
        /// <param name="status">Status</param>
        /// <returns>strin com o log</returns>
        public string SaveResponseSuccess(Msg1RetornoListaEmbarque objectRetornoListaEmbarque, Status status)
        {
            UpdateDB<ListaEmbarque> salvaEmbarqueBD = new UpdateListaEmbarque();
            salvaEmbarqueBD.atualizaRegistro(objectRetornoListaEmbarque.RESPONSE.ListaEmbarque, null);
            return string.Format("{0} {1}", MessagesOfReturn.EMBARQUE_ATUALIZADO, Environment.NewLine);
        }

        public string SaveResponseAlerta(Status status, string embarque)
        {
            throw new NotImplementedException();
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            throw new NotImplementedException();
        }
    }
}
