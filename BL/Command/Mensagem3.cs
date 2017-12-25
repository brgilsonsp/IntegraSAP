using BL.ObjectMessages;
using System;

namespace BL.Command
{
    class Mensagem3 : Mensagem, SaveData<RetornoAtualizaGTE, Embarque>
    {
        public string Message
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string SaveResponseAlerta(Status status)
        {
            throw new NotImplementedException();
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            throw new NotImplementedException();
        }

        public string SaveResponseSuccess(RetornoAtualizaGTE retornoWebService)
        {
            throw new NotImplementedException();
        }


        //public string SwapXmlWithGTE(ConfigureService configureService)
        //{
        //    string msgReturn = "";
        //    //Verifica se existe Detalhe de um ou mais Embarque para atualizar
        //    SelectDB<List<Embarque>> listEmbarqueAtualDet = new SelectEmbarquetAtualizaDetalhe();
        //    List<Embarque> embarques = listEmbarqueAtualDet.consultaRegistro(null);
        //    if (embarques != null && embarques.Count > 0) //Possui Detalhe Embarque para atualizar
        //    {
        //        //Executa a atualização no GTE
        //        msgReturn = executeSwapXml(embarques, configureService);
        //    }
        //    else //Não possui Detalhe Embarque para atualizar
        //    {
        //        msgReturn = string.Format("{0} {1}", MessagesOfReturn.ALERT_RETORNO_ATUALIZA_DETALHE_EMBARQUE_EMPTY,
        //            Environment.NewLine);
        //    }
        //    return msgReturn;
        //}

        ///// <summary>
        ///// Executa a troca de Mensagem com o Web Service e trato o Response
        ///// </summary>
        ///// <param name="embarques">List<Embarque></param>
        ///// <returns>string</returns>
        //private string executeSwapXml(List<Embarque> embarques, ConfigureService configureService)
        //{
        //    string msgReturn = "";
        //    foreach (Embarque embarque in embarques)
        //    {
        //        try
        //        {
        //            //Obtem dados para Atualizar Embarque no GTE
        //            SelectDB<Msg3AtualizaDetalheEmbarque> registroBD = new SelectDetalheEmbarque();
        //            Msg3AtualizaDetalheEmbarque detalheEmbarque = registroBD.consultaRegistro(embarque);

        //            if (detalheEmbarque != null) // Possui Detalhe do embarque específico
        //            {
        //                //Executa a troca de Mensagem com o GTE
        //                string xmlResponse = SwapWithGTE(detalheEmbarque, configureService);

        //                //Desserializa o Response
        //                ObjectForDB<RetornoAtualizaGTE> objectForBDSuccess = new ObjectForDB<RetornoAtualizaGTE>();
        //                RetornoAtualizaGTE responseGTESuccess = objectForBDSuccess.deserializeXmlForDB(xmlResponse);
        //                if (responseGTESuccess.RESPONSE.STATUS != null) // GTE recebeu o conteúdo enviado na Request
        //                {
        //                    //O conteúdo enviado ao GTE esta com erro
        //                    if (responseGTESuccess.RESPONSE.STATUS.ERRORS != null && responseGTESuccess.RESPONSE.STATUS.ERRORS.Count > 0)
        //                    {
        //                        msgReturn += SaveResponseAlerta(responseGTESuccess.RESPONSE.STATUS, embarque.SBELN);
        //                    }
        //                    else // O conteúdo enviado ao GTE esta ok
        //                    {
        //                        msgReturn += SaveResponseSuccess(responseGTESuccess, embarque);
        //                    }

        //                }
        //                else // Respota GTE Error Fatal
        //                {
        //                    msgReturn += SaveResponseError(xmlResponse, embarque.SBELN);
        //                }
        //            }
        //            else //Não localizou os registros do Detalhe do embarque específico
        //            {
        //                msgReturn += string.Format("{0} {1}",
        //                    MessagesOfReturn.ALERT_ATUALIZA_DETALHE_EMBARQUE_REG_EMPTY.Replace("?", embarque.SBELN),
        //                    Environment.NewLine);
        //            }
        //        }
        //        catch (BaseInnerException baseEx)
        //        {
        //            msgReturn += string.Format("{0} {1} {2} {1} {3} {1}",
        //                MessagesOfReturn.ERROR_ATUALIZA_EMBARQUE_GTE.Replace("?", embarque.SBELN),
        //                Environment.NewLine,
        //                baseEx.Message, baseEx.InnerException);
        //        }
        //        //Altera a flag do Embarque para Já Atualizado
        //        new UdapteDetalheEmbarqueAtualizado().atualizaRegistro(embarque, embarque.SBELN);
        //    }

        //    return msgReturn;
        //}

        ///// <summary>
        ///// Executa a troca do XML com o Web Service, retorna o Response
        ///// </summary>
        ///// <param name="detalheEmbarque">Msg3AtualizaDetalheEmbarque</param>
        ///// <returns>string com o response do GTE</returns>
        //private string SwapWithGTE(Msg3AtualizaDetalheEmbarque detalheEmbarque, ConfigureService configureService)
        //{
        //    SaveXMLOriginal saveXml = new SaveXMLOriginal();
        //    //Serializa o XML para Request
        //    XmlForGTE<Msg3AtualizaDetalheEmbarque> xmlForGTE = new XmlForGTE<Msg3AtualizaDetalheEmbarque>();
        //    string xmlRequest = xmlForGTE.serializeXmlForGTE(detalheEmbarque);
        //    saveXml.SaveXML(new ExportationMessageRequest(xmlRequest, detalheEmbarque.REQUEST.TGTESHK_N.SBELN, 3, configureService));

        //    //Efetua o Request e recebe o Response do Web Service GTE
        //    ComunicaGTE comunicaGTE = new ComunicaGTE();
        //    string xmlResponse = comunicaGTE.doRequestGTE(xmlRequest);
        //    saveXml.SaveXML(new ExportationMessageResponse(xmlResponse, detalheEmbarque.REQUEST.TGTESHK_N.SBELN, 3, configureService));

        //    return xmlResponse;
        //}

        ///// <summary>
        ///// Trata a resposta sucesso do GTE
        ///// </summary>
        ///// <param name="responseGTESuccess">RetornoAtualizaGTE</param>
        ///// <param name="embarque">Embarque</param>
        ///// <returns>string</returns>
        //public string SaveResponseSuccess(RetornoAtualizaGTE responseGTESuccess, Embarque embarque)
        //{
        //    SaveResponse(responseGTESuccess.RESPONSE.STATUS, embarque.SBELN);
        //    //Define o log
        //    return string.Format("{0} {1}",
        //        MessagesOfReturn.SUCCESS_ATUALIZA_DETALHE_EMBARQUE.Replace("?", embarque.SBELN),
        //        Environment.NewLine);
        //}

        //public string SaveResponseAlerta(Status status, string embarque)
        //{
        //    SaveResponse(status, embarque);
        //    //Define o log
        //    return string.Format("{0} {1}",
        //        MessagesOfReturn.ALERT_ATUALIZA_DETALHE_EMBARQUE_ERROR.Replace("?", embarque),
        //        Environment.NewLine);
        //}

        ///// <summary>
        ///// Se o GTE retornar um erro fatal, será salvo no BD
        ///// </summary>
        ///// <param name="xmlResponse">string</param>
        ///// <param name="embarque">Embarque</param>
        ///// <returns>string</returns>
        //public string SaveResponseError(string xmlResponse, string embarque)
        //{
        //    ObjectForDB<RetornoFatalErrorGTE> objectForBDError = new ObjectForDB<RetornoFatalErrorGTE>();
        //    RetornoFatalErrorGTE responseGTEError = objectForBDError.deserializeXmlForDB(xmlResponse);
        //    SaveResponse(responseGTEError.Status, embarque);
        //    return string.Format("{0} {1}",
        //        MessagesOfReturn.ALERT_ATUALIZA_DETALHE_EMBARQUE_ERROR.Replace("?", embarque),
        //        Environment.NewLine);
        //}

        ///// <summary>
        ///// Trata o Response
        ///// </summary>
        ///// <param name="responseGTESuccess">RetornoAtualizaGTE</param>
        ///// <param name="embarque">Embarqueparam>
        ///// <returns>string com o log</returns>
        //private int SaveResponse(Status status, string embarque)
        //{
        //    //Alimenta o banco de dados
        //    status.DataRetorno = ConfigureDate.ActualDate;
        //    status.Mensagem = Option.MENSAGEM3;
        //    return new UpdateResponseAtualizacaoGTE().atualizaRegistro(status, embarque);
        //}
        public string SwapXmlWithGTE()
        {
            throw new NotImplementedException();
        }
    }
}