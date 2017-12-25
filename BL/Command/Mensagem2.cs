using BL.Business;
using BL.DAO;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Command
{
    class Mensagem2 : ConfigStatus, Mensagem, SaveData<Msg2ResponseExportation, string>
    {

        public string Message { get { return MessagesOfReturn.ProcessExportation(Option.MENSAGEM2); } }

        public string SwapXmlWithGTE()
        {
            string messageReturn = "";
            //Obtem do servidor os dados para requisição
            IDictionary<string, string> objectsToRequest = new DatasToRequestExportation2().GetDatasToRequest();
            if (objectsToRequest.Count > 0)
            {
                foreach (string sbeln in objectsToRequest.Keys)
                {
                    string xmlRequest = objectsToRequest[sbeln];
                    ////salva o xml da request
                    SaveXMLOriginal.SaveXML(new ExportationMessageRequest(xmlRequest, "", Option.MENSAGEM2));

                    //Efetua o request ao WebService enviando o XML serializado
                    string xmlResponse = ComunicaGTE.doRequestWebService(xmlRequest, Message);
                    //salva o xml response
                    SaveXMLOriginal.SaveXML(new ExportationMessageResponse(xmlResponse, "", Option.MENSAGEM2));

                    //salva o response no banco de dados
                    messageReturn += SaveResponseDataBase(xmlResponse, sbeln);
                }
            }
            else
                messageReturn = MessagesOfReturn.AlertRequestMessage2ExportationEmpty;

            return messageReturn;
        }

        private string SaveResponseDataBase(string xmlResponse, string sbeln)
        {
            string msgReturn = "";
            Msg2ResponseExportation embarqueForDB = new ObjectForDB<Msg2ResponseExportation>().deserializeXmlForDB(xmlResponse);
            //Verifica se o Web Service enviou o Resposta
            if (embarqueForDB != null && embarqueForDB.RESPONSE.STATUS != null)
            {
                try
                {
                    ConfigureStatus(embarqueForDB.RESPONSE.STATUS, Option.MENSAGEM2, sbeln);

                    if (embarqueForDB.RESPONSE.TGTESHK_N != null && !string.IsNullOrEmpty(embarqueForDB.RESPONSE.TGTESHK_N.SBELN))
                    {
                        msgReturn = SaveResponseSuccess(embarqueForDB);
                    }
                    else if (embarqueForDB.RESPONSE.STATUS != null)// GTE não retornou o Detalhe do Embarque, porém retornou o status
                    {
                        msgReturn = SaveResponseAlerta(embarqueForDB.RESPONSE.STATUS);
                    }
                    else //GTE retornou um erro
                    {
                        msgReturn = SaveResponseError(xmlResponse, sbeln);
                    }
                    AlterEmbarqueConsulted(sbeln);
                }catch(Exception e)
                {
                    msgReturn = MessagesOfReturn.ErrorSaveDetalheEmbarqueDB(sbeln);
                    MakeLog.FactoryLogForError(e, msgReturn);
                }
            }
            else // Objeto embarqueForDB não recebeu nenhum dado do GTE
            {
                msgReturn = MessagesOfReturn.AlertResponseEmptyOrError(Message, sbeln);
            }
            return msgReturn;            
        }

        private void AlterEmbarqueConsulted(string sbeln)
        {
            EmbarqueDao dao = new EmbarqueDao();
            Embarque embarque = dao.FindBySbeln(sbeln);
            embarque.ConsultaDetalhe = false;
            dao.Update();
        }

        public string SaveResponseAlerta(Status status)
        {
            SaveStatus(status);
            return MessagesOfReturn.AlertResponseConsultaDetalheEmbarqueEmpty(status.SBELN);
        }

        public string SaveResponseError(string xmlResponse, string embarque)
        {
            RetornoFatalErrorGTE retornoError = new ObjectForDB<RetornoFatalErrorGTE>().deserializeXmlForDB(xmlResponse);
            ConfigureStatus(retornoError.RESPONSE.STATUS, Option.MENSAGEM2, embarque);
            SaveStatus(retornoError.RESPONSE.STATUS);
            return MessagesOfReturn.AlertResponseEmptyOrError(Message, embarque);
        }

        public string SaveResponseSuccess(Msg2ResponseExportation retornoWebService)
        {
            try
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
                return MessagesOfReturn.SucessoRetornoDetalheEmbarque(embarque.SBELN);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SaveTGTESHK_N(Msg2ResponseExportation retornoWebService, Embarque embarque)
        {
            TGTESHK_NDao dao = new TGTESHK_NDao();

            retornoWebService.RESPONSE.TGTESHK_N.Embarque = embarque;
            IList<TGTESHK_N> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.Save(retornoWebService.RESPONSE.TGTESHK_N);
        }

        private void SaveTGTESHP_N(Msg2ResponseExportation retornoWebService, Embarque embarque)
        {
            TGTESHP_NDao tGTESHP_NDao = new TGTESHP_NDao();

            retornoWebService.RESPONSE.TGTESHP_N.ForEach(t => t.Embarque = embarque);
            IList<TGTESHP_N> listTGTESHP_N = tGTESHP_NDao.FindByIDEmbarque(embarque.ID);
            if(listTGTESHP_N.Count > 0)
                tGTESHP_NDao.RemoveAll(listTGTESHP_N);

            tGTESHP_NDao.SaveAll(retornoWebService.RESPONSE.TGTESHP_N);
        }

        private void SaveTGTERES(Msg2ResponseExportation retornoWebService, Embarque embarque)
        {
            TGTERESDao dao = new TGTERESDao();
            retornoWebService.RESPONSE.TGTERES.ForEach(t => t.Embarque = embarque);
            IList<TGTERES> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.SaveAll(retornoWebService.RESPONSE.TGTERES);
        }

        private void SaveTGTEPRD(Msg2ResponseExportation retornoWebService, Embarque embarque)
        {
            TGTEPRDDao dao = new TGTEPRDDao();
            retornoWebService.RESPONSE.TGTEPRD.ForEach(t => t.Embarque = embarque);
            IList<TGTEPRD> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.SaveAll(retornoWebService.RESPONSE.TGTEPRD);
        }

        private void SaveSHP_TEXT(Msg2ResponseExportation retornoWebService, Embarque embarque)
        {
            SHP_TEXTDao dao = new SHP_TEXTDao();
            retornoWebService.RESPONSE.SHP_TEXT.ForEach(s => s.Embarque = embarque);
            IList<SHP_TEXT> list = dao.FindByIdEmbarque(embarque.ID);
            if (list.Count > 0)
                dao.RemoveAll(list);

            dao.SaveAll(retornoWebService.RESPONSE.SHP_TEXT);
        }

        private void SaveTGTEDUEK(Msg2ResponseExportation retornoWebService, Embarque embarque)
        {
            retornoWebService.RESPONSE.TGTEDUEK.ForEach(t => t.Embarque = embarque);
            TGTEDUEKDao daoTgteduek = new TGTEDUEKDao();           
            IList<TGTEDUEK> listTgteduek = daoTgteduek.FindByIdEmbarque(embarque.ID);
            if (listTgteduek.Count > 0)
                daoTgteduek.RemoveAll(listTgteduek);

            daoTgteduek.SaveAll(retornoWebService.RESPONSE.TGTEDUEK);
        }

        private void SaveTGTEDUEP(Msg2ResponseExportation retornoWebService, Embarque embarque)
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