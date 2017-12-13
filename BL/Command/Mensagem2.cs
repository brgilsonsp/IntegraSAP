using BL.Business;
using DAL.ObjectMessages;
using DAL.ProcessDB;
using System.Collections.Generic;
using Util.InnerUtil;
using System;
using Util.InnerException;

namespace BL.Command
{
    class Mensagem2 : Mensagem, SaveData<Msg2RetornoDetalheEmbarque, string>
    {
        public string SwapXmlWithGTE()
        {
            string retorno = "";
            //Obtem dados para consulta
            List<ConsultaGTE> consultaEmbarques = new SelectListEmbarque().consultaRegistro(null);

            //Verificar se existe Embarque para consultar
            if (consultaEmbarques != null && consultaEmbarques.Count > 0)
            {
                //Executa o processo de troca de XML
                retorno = executeSwap(consultaEmbarques);
            }
            else //Não foi localizado nenhum embarque disponível para consultar detalhes
            {
                retorno = string.Format("{0} {1}", MessagesOfReturn.ALERT_CONSULTA_DETALHE_EMBARQUE_EMPTY, 
                    Environment.NewLine);
            }

            return retorno;
        }
        
        private string executeSwap(List<ConsultaGTE> consultaEmbarques)
        {
            string msgReturn = "";
            foreach (ConsultaGTE cadaEmbarque in consultaEmbarques)
            {
                if (cadaEmbarque != null && cadaEmbarque.REQUEST != null &&
                    !string.IsNullOrEmpty(cadaEmbarque.REQUEST.SBELN))
                {
                    string xmlResponse = SwapWithGTE(cadaEmbarque);

                    //Desserializar XML para salvar no banco de dados
                    ObjectForDB<Msg2RetornoDetalheEmbarque> objectForDB = new ObjectForDB<Msg2RetornoDetalheEmbarque>();
                    Msg2RetornoDetalheEmbarque embarqueForDB = objectForDB.deserializeXmlForDB(xmlResponse);
                    //Verifica se o Web Service enviou o Detalhe do Embarque
                    if (embarqueForDB != null && embarqueForDB.RESPONSE.TGTESHK_N != null &&
                        embarqueForDB.RESPONSE.STATUS != null)
                    {
                        embarqueForDB.RESPONSE.STATUS.DataRetorno = ConfigureDate.ActualDate;
                        embarqueForDB.RESPONSE.STATUS.Mensagem = Option.MENSAGEM2;
                        if (!string.IsNullOrEmpty(embarqueForDB.RESPONSE.TGTESHK_N.SBELN))
                        {
                            msgReturn += SaveResponseSuccess(embarqueForDB, embarqueForDB.RESPONSE.TGTESHK_N.SBELN);
                        }
                        else if (embarqueForDB.RESPONSE.STATUS != null)// GTE não retornou o Detalhe do Embarque, porém retornou o status
                        {
                            msgReturn += SaveResponseAlerta(embarqueForDB.RESPONSE.STATUS, cadaEmbarque.REQUEST.SBELN);
                        }
                        else //GTE retornou um erro
                        {
                            msgReturn += SaveResponseError(xmlResponse, cadaEmbarque.REQUEST.SBELN);
                        }
                    }
                    else // Objeto embarqueForDB não recebeu nenhum dado do GTE
                    {
                        msgReturn += string.Format("{0} {1}",
                            MessagesOfReturn.ALERT_RETORNO_DETALHE_EMBARQUE_EMPTY.Replace("?", cadaEmbarque.REQUEST.SBELN),
                            Environment.NewLine);
                    }
                    new UpdateDetalheEmbarqueConsultado().atualizaRegistroEmbarque(cadaEmbarque.REQUEST.SBELN);
                }
                else //O Embarque da List é nulo
                {
                    msgReturn += string.Format("{0} {1}", MessagesOfReturn.ALERT_EMBARQUE_EMPTY_OR_NULL,
                        Environment.NewLine);
                }
            }
            return msgReturn;
        }

        /// <summary>
        /// Executa a troca de Mensagem como GTE e devolve o Response
        /// </summary>
        /// <param name="embarque">ConsultaGTE</param>
        /// <returns>string com o Response do GTE</returns>
        private string SwapWithGTE(ConsultaGTE embarque)
        {
            //Serializar XML para envio ao GTE
            XmlForGTE<ConsultaGTE> xmlFotGTE = new XmlForGTE<ConsultaGTE>();
            string xmlRequest = xmlFotGTE.serializeXmlForGTE(embarque);

            //Enviar requisição e receber resposta do Web Service GTE
            ComunicaGTE comunicateGTE = new ComunicaGTE();
            string xmlResponse = comunicateGTE.doRequestGTE(xmlRequest);
            SaveXMLOriginal(xmlResponse, xmlRequest, embarque.REQUEST.SBELN);
            return xmlResponse;
        }

        /// <summary>
        /// Solicita a gravação do conteúdo XML que foi trocado com o GTE
        /// </summary>
        /// <param name="xmlResponse">string</param>
        /// <param name="xmlRequest">string</param>
        /// <param name="embarque">string</param>
        public void SaveXMLOriginal(string xmlResponse, string xmlRequest, string embarque)
        {
            //Salva o Response do GTE em um arquivo XML
            new SaveXMLOriginal().SaveXML(Option.MENSAGEM2, xmlRequest, embarque, true, false);
            //Salva o Response do GTE em um arquivo XML
            new SaveXMLOriginal().SaveXML(Option.MENSAGEM2, xmlResponse, embarque, false, true);
        }

        /// <summary>
        /// Trata o Response com sucesso do GTE
        /// </summary>
        /// <param name="embarqueForDB">Msg2RetornoDetalheEmbarque</param>
        /// <param name="status">Status</param>
        /// <returns>string com o log</returns>
        public string SaveResponseSuccess(Msg2RetornoDetalheEmbarque embarqueForDB, string embarque)
        {
            //Salvar Detalhes do Embarque no banco de dados
            UpdateDB<Msg2RetornoDetalheEmbarque> salvaDetalheEmbarque = new UpdateDetalheEmbarque();
            salvaDetalheEmbarque.atualizaRegistro(embarqueForDB, embarque);
            //Salva o status
            new UpdateResponseAtualizacaoGTE().atualizaRegistro(embarqueForDB.RESPONSE.STATUS, 
                embarqueForDB.RESPONSE.TGTESHK_N.SBELN);
            return string.Format("{0} {1}",
                MessagesOfReturn.ALERT_RETORNO_DETALHE_EMBARQUE.Replace("?", embarque),
                Environment.NewLine);
        }

        /// <summary>
        /// Trata o Response com erro do GTE
        /// </summary>
        /// <param name="status">Status</param>
        /// <param name="embarque">string</param>
        /// <returns>string com o log</returns>
        public string SaveResponseAlerta(Status status, string embarque)
        {
            new UpdateResponseAtualizacaoGTE().atualizaRegistro(status, embarque);

            return string.Format("{0} {1}", MessagesOfReturn.ALERT_RESPONSE_CONSULTA_DETALHE_EMBARQUE_EMPTY.Replace("?", embarque),
                Environment.NewLine);
        }

        /// <summary>
        /// Trata o Response com erro do GTE
        /// </summary>
        /// <param name="xmlResponse">string</param>
        /// <param name="embarque">string</param>
        /// <returns>string com o log</returns>
        public string SaveResponseError(string xmlResponse, string embarque)
        {
            ObjectForDB<RetornoFatalErrorGTE> errorGTE = new ObjectForDB<RetornoFatalErrorGTE>();
            RetornoFatalErrorGTE retornoError = errorGTE.deserializeXmlForDB(xmlResponse);
            retornoError.DataRetorno = ConfigureDate.ActualDate;
            retornoError.Mensagem = Option.MENSAGEM2;
            new UpdateResponseAtualizacaoGTE().atualizaRegistro(retornoError.Status, embarque);

            return string.Format("{0} {1}", MessagesOfReturn.ERROR_CONSULT_DETALHE_EMBARQUE_ESTRUTURA.Replace("?", embarque), 
                Environment.NewLine);
        }
    }
}
