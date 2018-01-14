using BL.Business;
using BL.DAO;
using BL.Infra;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;

namespace BL.Command
{
    class Mensagem2 : ConfigStatus, IMessage, ISaveData<ResponseMessage2Exportation>
    {
        public string Message { get { return MessagesOfReturn.Message(Option.MENSAGEM2, Option.EXPORTACAO); } }

        public string SwapXmlWithGTE()
        {
            string messageReturn = "";
            //Obtem do servidor os dados para requisição
            IDictionary<string, string> objectsToRequest = new DatasToRequestExportation2().GetDatasToRequest();
            if (objectsToRequest.Count > 0)
            {
                foreach (string sbeln in objectsToRequest.Keys)
                {
                    if (!string.IsNullOrEmpty(objectsToRequest[sbeln]))
                    {
                        try
                        {
                            string xmlRequest = objectsToRequest[sbeln];

                            ////salva o xml da request
                            SaveXMLOriginal.SaveXML(new ExportationMessageRequest(xmlRequest, "", Option.MENSAGEM2));

                            //Efetua o request ao WebService enviando o XML serializado
                            string xmlResponse = RequestWebService.doRequestWebService(xmlRequest, Message);

                            //salva o xml response
                            SaveXMLOriginal.SaveXML(new ExportationMessageResponse(xmlResponse, "", Option.MENSAGEM2));

                            //salva o response no banco de dados
                            messageReturn += SaveResponseDataBase(xmlResponse, sbeln);
                        }
                        catch (Exception ex)
                        {
                            string messageError = MessagesOfReturn.ExceptionMessageLogSupport(Message, sbeln);
                            int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, $"{Message} - Embarque: {sbeln}");
                            messageReturn += MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, messageError);
                        }
                    }
                    else
                        messageReturn += MessagesOfReturn.DatasToRequestEmpty(Message, sbeln);
                }
            }
            else
                messageReturn = MessagesOfReturn.NotRequest(Message);

            return messageReturn;
        }

        private string SaveResponseDataBase(string xmlResponse, string sbeln)
        {
            string msgReturn = "";
            ResponseMessage2Exportation responseMsg2 = new DeserializeXml<ResponseMessage2Exportation>().deserializeXmlForDB(xmlResponse);
            //Verifica se o Web Service enviou o Resposta
            if (responseMsg2 != null && responseMsg2.RESPONSE != null && responseMsg2.RESPONSE.STATUS != null)
            {
                ConfigureStatus(responseMsg2.RESPONSE.STATUS, Option.MENSAGEM2, Option.EXPORTACAO, sbeln);

                if (responseMsg2.RESPONSE.TGTESHK_N != null && !string.IsNullOrEmpty(responseMsg2.RESPONSE.TGTESHK_N.SBELN))
                    msgReturn = SaveResponseSuccess(responseMsg2);
                else if (responseMsg2.RESPONSE.STATUS != null)// GTE não retornou o Detalhe do Embarque, porém retornou o status
                    msgReturn = SaveResponseAlerta(responseMsg2.RESPONSE.STATUS);
                else //GTE retornou um erro
                    msgReturn = SaveResponseError(xmlResponse, sbeln);                
            }
            else // WebService retornou Erro
                msgReturn = SaveResponseError(xmlResponse, sbeln);

            AlterFlagChangeMessage(sbeln);

            return msgReturn;            
        }

        public void AlterFlagChangeMessage(string sbeln)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln);
            embarque.ConsultaDetalhe = false;
            dao.Update();
        }

        public string SaveResponseAlerta(Status status)
        {
            SaveStatus(status);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, status.SBELN);
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            SaveStatusError(xmlResponse, Option.MENSAGEM2, Option.EXPORTACAO);
            return MessagesOfReturn.AlertResponseWebServiceErrorWithSbeln(Message, embarque);
        }

        public string SaveResponseSuccess(ResponseMessage2Exportation retornoWebService)
        {
            Embarque embarque = new EmbarqueDao().FindBySbeln(retornoWebService.RESPONSE.TGTESHK_N.SBELN);
            SaveStatus(retornoWebService.RESPONSE.STATUS, embarque);
            SaveTGTESHK_N(retornoWebService, embarque);
            SaveTGTESHP_N(retornoWebService, embarque);
            SaveTGTERES(retornoWebService, embarque);
            SaveTGTEPRD(retornoWebService, embarque);
            SaveSHP_TEXT(retornoWebService, embarque);
            SaveTGTEDUEK(retornoWebService, embarque);
            SaveTGTEDUEP(retornoWebService, embarque);
            return MessagesOfReturn.ProcessMessageSuccess(Message, embarque.SBELN);
        }

        private void SaveTGTESHK_N(ResponseMessage2Exportation retornoWebService, Embarque embarque)
        {
            TGTESHK_NDao dao = new TGTESHK_NDao();

            retornoWebService.RESPONSE.TGTESHK_N.Embarque = embarque;
            IList<TGTESHK_N> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.Save(retornoWebService.RESPONSE.TGTESHK_N);
        }

        private void SaveTGTESHP_N(ResponseMessage2Exportation retornoWebService, Embarque embarque)
        {
            TGTESHP_NDao tGTESHP_NDao = new TGTESHP_NDao();

            retornoWebService.RESPONSE.TGTESHP_N.ForEach(t => t.Embarque = embarque);
            IList<TGTESHP_N> listTGTESHP_N = tGTESHP_NDao.FindByIDEmbarque(embarque.ID);
            if(listTGTESHP_N.Count > 0)
                tGTESHP_NDao.RemoveAll(listTGTESHP_N);

            tGTESHP_NDao.SaveAll(retornoWebService.RESPONSE.TGTESHP_N);
        }

        private void SaveTGTERES(ResponseMessage2Exportation retornoWebService, Embarque embarque)
        {
            TGTERESDao dao = new TGTERESDao();
            retornoWebService.RESPONSE.TGTERES.ForEach(t => t.Embarque = embarque);
            IList<TGTERES> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.SaveAll(retornoWebService.RESPONSE.TGTERES);
        }

        private void SaveTGTEPRD(ResponseMessage2Exportation retornoWebService, Embarque embarque)
        {
            TGTEPRDDao dao = new TGTEPRDDao();
            retornoWebService.RESPONSE.TGTEPRD.ForEach(t => t.Embarque = embarque);
            IList<TGTEPRD> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.SaveAll(retornoWebService.RESPONSE.TGTEPRD);
        }

        private void SaveSHP_TEXT(ResponseMessage2Exportation retornoWebService, Embarque embarque)
        {
            SHP_TEXTDao dao = new SHP_TEXTDao();
            retornoWebService.RESPONSE.SHP_TEXT.ForEach(s => s.Embarque = embarque);
            IList<SHP_TEXT> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.SaveAll(retornoWebService.RESPONSE.SHP_TEXT);
        }

        private void SaveTGTEDUEK(ResponseMessage2Exportation retornoWebService, Embarque embarque)
        {
            retornoWebService.RESPONSE.TGTEDUEK.ForEach(t => t.Embarque = embarque);
            TGTEDUEKDao daoTgteduek = new TGTEDUEKDao();           
            IList<TGTEDUEK> listTgteduek = daoTgteduek.FindByIdEmbarque(embarque.ID);
            if (listTgteduek.Count > 0)
                daoTgteduek.RemoveAll(listTgteduek);

            daoTgteduek.SaveAll(retornoWebService.RESPONSE.TGTEDUEK);
        }

        private void SaveTGTEDUEP(ResponseMessage2Exportation retornoWebService, Embarque embarque)
        {
            retornoWebService.RESPONSE.TGTEDUEP.ForEach(t => t.Embarque = embarque);
            TGTEDUEPDao daoTgteduep = new TGTEDUEPDao();
            IList<TGTEDUEP> listTgtedupe = daoTgteduep.FindByIdEmbarque(embarque.ID);
            if (listTgtedupe.Count > 0)
                daoTgteduep.RemoveAll(listTgtedupe);

            daoTgteduep.SaveAll(retornoWebService.RESPONSE.TGTEDUEP);
        }
    }
}