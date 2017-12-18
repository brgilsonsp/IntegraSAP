using BL.Business;
using BL.ObjectMessages;
using System;

namespace BL.Command
{
    class Mensagem4 : Mensagem, SaveData<Status, Embarque>
    {
        public string SaveResponseAlerta(Status status, string embarque)
        {
            throw new NotImplementedException();
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            throw new NotImplementedException();
        }

        public string SaveResponseSuccess(Status retornoWebService, Embarque embarque)
        {
            throw new NotImplementedException();
        }

        //public string SwapXmlWithGTE(ConfigureService configureService)
        //{
        //    string msgReturn = "";
        //    //Verifica se existe Prestação de Contas para Atualizar
        //    List<Embarque> listaEmbarque = new SelectEmbarqueAtualizacaPC().consultaRegistro(null);
        //    if(listaEmbarque != null && listaEmbarque.Count > 0)//Possui Embarque para Envio da Prestação de Conta
        //    {
        //        //Executa a Atualização da Prestação de Contas
        //        msgReturn = executeSwapXML(listaEmbarque,configureService);
        //    }
        //    else //Não existe Atualização de Prestação de Contas Pendente
        //    {
        //        msgReturn = string.Format("{0} {1}", MessagesOfReturn.ALERT_ATUALIZA_PRESTACAO_CONTA_EMPTY, Environment.NewLine);
        //    }
        //    return msgReturn;
        //}

        ///// <summary>
        ///// Executa a troca de Mensagem com o Web Service e trata o Response
        ///// </summary>
        ///// <param name="listEmbarque">List<Embarque></param>
        ///// <returns>string</returns>
        //private string executeSwapXML(List<Embarque> listEmbarque, ConfigureService configureService)
        //{
        //    string msgReturn = "";
        //    foreach (Embarque embarque in listEmbarque)
        //    {
        //        try
        //        {
        //            //Obtém a Prestação de Contas disponível para atualização
        //            Msg4AtualizaPrestacaoConta prestacaoContas = new SelectAtualizaPrestacaConta().consultaRegistro(embarque);
        //            if (prestacaoContas != null)// Encontrou registro da Prestaçao de Contas
        //            {
        //                //Efetua a troca de Mensagem com o GTE, enviando o objeto e recebendo a string
        //                string xmlResponse = SwapWithGTE(prestacaoContas, embarque.SBELN, configureService);

        //                //Desserializa o Xml Response
        //                ObjectForDB<RetornoAtualizaGTE> objectForDB = new ObjectForDB<RetornoAtualizaGTE>();
        //                RetornoAtualizaGTE retornoAtualizaGTE = objectForDB.deserializeXmlForDB(xmlResponse);

        //                if (retornoAtualizaGTE.RESPONSE.STATUS != null)
        //                { // Se o retorno do GTE for sucesso
        //                    if(retornoAtualizaGTE.RESPONSE.STATUS.ERRORS != null 
        //                        && retornoAtualizaGTE.RESPONSE.STATUS.ERRORS.Count > 0)
        //                    {//Response retornou com erro
        //                        msgReturn += SaveResponseAlerta(retornoAtualizaGTE.RESPONSE.STATUS, embarque.SBELN);
        //                    }
        //                    else { //Response retornou com sucesso
        //                        msgReturn += SaveResponseSuccess(retornoAtualizaGTE.RESPONSE.STATUS, embarque);
        //                    }                            
        //                }
        //                else { // Response retornou com erro fatal
        //                    msgReturn += SaveResponseError(xmlResponse, embarque.SBELN);
        //                }
        //            }else //Não existe registro de Prestação de Contas para o Embarque específico
        //            {
        //                msgReturn += string.Format("{0} {1}",
        //                    MessagesOfReturn.ALERT_ATUALIZA_PC_EMBARQUE_REG_EMPTY.Replace("?", embarque.SBELN),
        //                    Environment.NewLine);
        //            }
        //        }
        //        catch(BaseInnerException baseEx)
        //        {
        //            msgReturn += string.Format("{0} {1} {2} {1} {3} {1}",
        //                MessagesOfReturn.ERROR_ATUALIZA_PC_GTE.Replace("?", embarque.SBELN), Environment.NewLine,
        //                baseEx.Message, baseEx.InnerException);
        //        }
        //        //Altera a flag Embarque para Prestação de Contas para Atualizada
        //        new UpdatePrestacaoContaEmbarqueAtualizado().atualizaRegistro(embarque, embarque.SBELN);
        //    }

        //    return msgReturn;
        //}

        ///// <summary>
        ///// Serializa a strign XML, efetua a troca de Mensagem com o GTE,
        ///// </summary>
        ///// <param name="prestacaoContas">Msg4AtualizaPrestacaoConta</param>
        ///// <returns>string, resposta do GTE</returns>
        //private string SwapWithGTE(Msg4AtualizaPrestacaoConta prestacaoContas, string embarque, ConfigureService configureService)
        //{
        //    SaveXMLOriginal saveXml = new SaveXMLOriginal();
        //    //Serializa  XML Request
        //    XmlForGTE<Msg4AtualizaPrestacaoConta> xmlForGTE = new XmlForGTE<Msg4AtualizaPrestacaoConta>();
        //    string xmlRequest = xmlForGTE.serializeXmlForGTE(prestacaoContas);
        //    saveXml.SaveXML(new ExportationMessageRequest(xmlRequest, embarque, 4, configureService));

        //    //Envio o Xml Request e retorna o Xml Response
        //    ComunicaGTE comunicaGTE = new ComunicaGTE();
        //    string xmlResponse = comunicaGTE.doRequestGTE(xmlRequest);
        //    saveXml.SaveXML(new ExportationMessageResponse(xmlResponse, embarque, 4, configureService));

        //    return xmlResponse;

        //}

        ///// <summary>
        ///// Trata o Response Sucesso do GTE
        ///// </summary>
        ///// <param name="status">Status</param>
        ///// <param name="embarque">Embarqueparam>
        ///// <returns>string</returns>
        //public string SaveResponseSuccess(Status status, Embarque embarque)
        //{
        //    SaveResponse(status, embarque.SBELN);
        //    //Alimenta o Log
        //    return string.Format("{0} {1}",
        //        MessagesOfReturn.SUCCESS_ATUALIZA_PRESTACAO_CONTA.Replace("?", embarque.SBELN),
        //        Environment.NewLine);
        //}

        ///// <summary>
        ///// Trata o Response Error do GTE
        ///// </summary>
        ///// <param name="status">Status</param>
        ///// <param name="embarque">Embarqueparam>
        ///// <returns>string</returns>
        //public string SaveResponseAlerta(Status status, string embarque)
        //{
        //    SaveResponse(status, embarque);
        //    //Alimenta o Log
        //    return string.Format("{0} {1}",
        //        MessagesOfReturn.ALERT_ATUALIZA_PRESTACAO_CONTA_ERROR.Replace("?", embarque),
        //        Environment.NewLine);
        //}

        ///// <summary>
        ///// Trata o Response Error Fatal do GTE
        ///// </summary>
        ///// <param name="xmlResponse">string</param>
        ///// <param name="embarque">Embarqueparam>
        ///// <returns>string</returns>
        //public string SaveResponseError(string xmlResponse, string embarque)
        //{
        //    ObjectForDB<RetornoFatalErrorGTE> objectForBDError = new ObjectForDB<RetornoFatalErrorGTE>();
        //    RetornoFatalErrorGTE retornoAtualizaGTEError = objectForBDError.deserializeXmlForDB(xmlResponse);
        //    SaveResponse(retornoAtualizaGTEError.Status, embarque);
        //    //Alimenta o logo
        //    return string.Format("{0} {1}",
        //        MessagesOfReturn.ALERT_ATUALIZA_PRESTACAO_CONTA_ERROR.Replace("?", embarque),
        //        Environment.NewLine);
        //}

        ///// <summary>
        ///// Trata o Response com sucesso
        ///// </summary>
        ///// <param name="retornoAtualizaGTE">RetornoAtualizaGTE</param>
        ///// <param name="embarque">Embarque</param>
        ///// <returns>String com a mensagem para o log</returns>
        //private void SaveResponse(Status status, string embarque)
        //{
        //    status.DataRetorno = ConfigureDate.ActualDate;
        //    status.Mensagem = Option.MENSAGEM4;
        //    //Atualiza o Response no banco de dados
        //    UpdateDB<Status> salvaResponseBD = new UpdateResponseAtualizacaoGTE();
        //    salvaResponseBD.atualizaRegistro(status, embarque);            
        //}
        public string SwapXmlWithGTE(ConfigureService configureService)
        {
            throw new NotImplementedException();
        }
    }
}
