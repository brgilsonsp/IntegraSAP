using BL.ObjectMessages;
using BL.Business;
using BL.InnerUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using BL.DAO;
using BL.ObjectMessages;

namespace BL.Command
{
    class Mensagem1 : ConfigStatus, Mensagem, SaveData<Msg1ResponseExportation, Status>
    {
        public string Message { get { return MessagesOfReturn.ProcessExportation(Option.MENSAGEM1); } }

        public string SwapXmlWithGTE()
        {
            string messageReturn = "";
            //Obtem do servidor os dados para requisição
            IDictionary<string, string> objectsToRequest = new DatasToRequestExportation1().GetDatasToRequest();
            foreach (string id in objectsToRequest.Keys)
            {
                string xmlRequest = objectsToRequest[id];
                ////salva o xml da request
                SaveXMLOriginal.SaveXML(new ExportationMessageRequest(xmlRequest, "ListaEmbarque", Option.MENSAGEM1));

                //Efetua o request ao WebService enviando o XML serializado
                string xmlResponse = ComunicaGTE.doRequestWebService(xmlRequest, Message);
                //salva o xml response
                SaveXMLOriginal.SaveXML(new ExportationMessageResponse(xmlResponse, "ListaEmbarque", Option.MENSAGEM1));

                //salva o response no banco de dados
                messageReturn += SaveResponseDataBase(xmlResponse, id);
            }

            return messageReturn;
        }

        private string SaveResponseDataBase(string xmlResponse, string idBroker)
        {
            Msg1ResponseExportation responseExportation1 = new ObjectForDB<Msg1ResponseExportation>().deserializeXmlForDB(xmlResponse);
            if (responseExportation1 != null)
            {
                if (responseExportation1.RESPONSE != null && responseExportation1.RESPONSE.ListaEmbarque == null)
                {// WebService retornou mensagem de Erro de estrutura do XML
                    return SaveResponseError(xmlResponse, idBroker.ToString());
                }

                ConfigureStatus(responseExportation1.RESPONSE.STATUS, Option.MENSAGEM1);
                AlimentaIdDadosBroker(responseExportation1, int.Parse(idBroker));
                             
                if (responseExportation1.RESPONSE.ListaEmbarque != null &&
                    responseExportation1.RESPONSE.ListaEmbarque.Embarques.Count > 0)
                {//Recebeu os Embarques do WebService
                    return SaveResponseSuccess(responseExportation1);
                }
                else if (responseExportation1.RESPONSE.ListaEmbarque != null &&
                    responseExportation1.RESPONSE.ListaEmbarque.Embarques.Count == 0)
                { // Não recebeu os Embarques do WebService, WebService retornou mensagem de erro
                    return SaveResponseAlerta(responseExportation1.RESPONSE.STATUS);
                }
                else // Se não recebeu nenhum Embarque do GTE
                    return MessagesOfReturn.AlertResponseEmptyByIdBroker(Message, idBroker.ToString());
            }
            else// Não recebeu nenhum Embarque ou não foi possível desserializar o Xml e não lançou nenhum exception
                return MessagesOfReturn.AlertResponseEmptyByIdBroker(Message, idBroker.ToString());
        }

        public string SaveResponseSuccess(Msg1ResponseExportation retornoWebService)
        {
            foreach (Embarque embarque in retornoWebService.RESPONSE.ListaEmbarque.Embarques)
                new EmbarqueDao().Save(embarque);

            return MessagesOfReturn.EmbarqueAtualiza(retornoWebService.RESPONSE.ListaEmbarque.Embarques.FirstOrDefault().DadosBrokerID);
        }

        public string SaveResponseError(string xmlResponse, string idBroker)
        {
            //Desserializa o erro
            ObjectForDB<RetornoFatalErrorGTE> objectFatalError = new ObjectForDB<RetornoFatalErrorGTE>();
            RetornoFatalErrorGTE retornoFatalError = objectFatalError.deserializeXmlForDB(xmlResponse);
            //Complementa com as informações de data atual e qual a Mensagem que esta sendo processada
            ConfigureStatus(retornoFatalError.RESPONSE.STATUS, Option.MENSAGEM1);

            //Salva o Status Retorno
            SaveStatus(retornoFatalError.RESPONSE.STATUS);
            
            return MessagesOfReturn.ErrorStructureRequest(Message, idBroker, retornoFatalError.RESPONSE.STATUS.ERRORS);
        }

        public string SaveResponseAlerta(Status status)
        {
            SaveStatus(status);
            
            return MessagesOfReturn.AlertResponseEmptyByIdBroker(Message, status.idBroker.ToString());
        }

        /// <summary>
        /// Alimentado o ID do CNPJ ao Embarque
        /// </summary>
        /// <param name="msg1">BL.ObjectMessages.Msg1RetornoListaEmbarque</param>
        /// <param name="idCabecalho">int</param>
        private void AlimentaIdDadosBroker(Msg1ResponseExportation msg1, int idBroker)
        {
            foreach(Embarque cadaEmbarque in msg1.RESPONSE.ListaEmbarque.Embarques)
                cadaEmbarque.DadosBrokerID = idBroker;

            if (msg1.RESPONSE.STATUS != null)
                msg1.RESPONSE.STATUS.idBroker = idBroker;

        }

    }
}