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
            MAKTX_TEXTDao maktDao = new MAKTX_TEXTDao();

            retornoWebService.RESPONSE.TGTESHP_N.ForEach(t => t.Embarque = embarque);
            IList<TGTESHP_N> listTGTESHP_N = tGTESHP_NDao.FindByIDEmbarque(embarque.ID);
            foreach (TGTESHP_N tgteshp_n in listTGTESHP_N)
            {
                IList<MAKTX_TEXT> listMaktx_text = maktDao.FindByIdTGTESHPN(tgteshp_n.ID);
                if(listMaktx_text.Count > 0)
                    maktDao.RemoveAll(listMaktx_text);
                  
                tGTESHP_NDao.Remove(tgteshp_n);
            }

            tGTESHP_NDao.SaveAll(retornoWebService.RESPONSE.TGTESHP_N);
            
            foreach (TGTESHP_N tgteshpn in retornoWebService.RESPONSE.TGTESHP_N)
            {
                //Em cada MAKTX_TEXT insiro o TGTESHP_N correspondente
                tgteshpn.MAKTX_TEXT.ForEach(m => m.TGTESHPN = tgteshpn);
                maktDao.SaveAll(tgteshpn.MAKTX_TEXT);
            }
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
            ADDINFO_TAB_TGTEDUEKDao daoAddInfo = new ADDINFO_TAB_TGTEDUEKDao();
            ADDRESS_TAB_TGTEDUEKDao daoAddress = new ADDRESS_TAB_TGTEDUEKDao();            
            IList<TGTEDUEK> listTgteduek = daoTgteduek.FindByIdEmbarque(embarque.ID);
            foreach(TGTEDUEK tgteduek in listTgteduek)
            {
                IList<ADDINFO_TAB_TGTEDUEK> listAddInfo =  daoAddInfo.FindByIdTGTEDUEK(tgteduek.ID);
                if (listAddInfo.Count > 0)
                    daoAddInfo.RemoveAll(listAddInfo);

                IList<ADDRESS_TAB_TGTEDUEK> listAddress =  daoAddress.FindByIdTGTEDUEK(tgteduek.ID);
                if (listAddress.Count > 0)
                    daoAddress.RemoveAll(listAddress);

                daoTgteduek.Remove(tgteduek);
            }

            daoTgteduek.SaveAll(retornoWebService.RESPONSE.TGTEDUEK);
            foreach (TGTEDUEK tgteduek in retornoWebService.RESPONSE.TGTEDUEK)
            {
                //Inserir na RESPONSE/TGTEDUEK/ADDINFO_TAB o RESPONSE/TGTEDUEK
                tgteduek.ADDINFO_TAB.ForEach(a => a.TGTEDUEK = tgteduek);
                daoAddInfo.SaveAll(tgteduek.ADDINFO_TAB);

                //Inserir na RESPONSE/TGTEDUEK/ADDRESS_TAB o RESPONSE/TGTEDUEK
                tgteduek.ADDRESS_TAB.ForEach(a => a.TGTEDUEK = tgteduek);
                daoAddress.SaveAll(tgteduek.ADDRESS_TAB);
            }
        }

        private void SaveTGTEDUEP(Msg2ResponseExportation retornoWebService, Embarque embarque)
        {
            retornoWebService.RESPONSE.TGTEDUEP.ForEach(t => t.Embarque = embarque);
            TGTEDUEPDao daoTgteduep = new TGTEDUEPDao();
            ADDINFO_TAB_TGTEDUEPDao daoAddInfo = new ADDINFO_TAB_TGTEDUEPDao();
            NFEREF_TAB_TGTEDUEPDao daoNfeRef = new NFEREF_TAB_TGTEDUEPDao();
            ATOCON_TAB_TGTEDUEPDao daoAtocon = new ATOCON_TAB_TGTEDUEPDao();
            DUEATRIB_TAB_TGTEDUEPDao daoDueatrib = new DUEATRIB_TAB_TGTEDUEPDao();
            IList<TGTEDUEP> listTgtedupe = daoTgteduep.FindByIdEmbarque(embarque.ID);
            foreach (TGTEDUEP tgteduep in listTgtedupe)
            {
                IList<ADDINFO_TAB_TGTEDUEP> listAddInfo = daoAddInfo.FindByIdTGTEDUEP(tgteduep.ID);
                if (listAddInfo.Count > 0)
                    daoAddInfo.RemoveAll(listAddInfo);

                IList<NFEREF_TAB_TGTEDUEP> listNfeRef = daoNfeRef.FindByIdTGTEDUEP(tgteduep.ID);
                if (listNfeRef.Count > 0)
                    daoNfeRef.RemoveAll(listNfeRef);

                IList<ATOCON_TAB_TGTEDUEP> listAtocon = daoAtocon.FindByIdTGTEDUEP(tgteduep.ID);
                if (listAtocon.Count > 0)
                    daoAtocon.RemoveAll(listAtocon);

                IList<DUEATRIB_TAB_TGTEDUEP> listDueatrib =  daoDueatrib.FindByIdTGTEDUEP(tgteduep.ID);
                if (listDueatrib.Count > 0)
                    daoDueatrib.RemoveAll(listDueatrib);

                daoTgteduep.Remove(tgteduep);
            }

            daoTgteduep.SaveAll(retornoWebService.RESPONSE.TGTEDUEP);
            foreach (TGTEDUEP tgteduep in retornoWebService.RESPONSE.TGTEDUEP)
            {
                //Inserir na RESPONSE/TGTEDUEP/ADDINFO_TAB o RESPONSE/TGTEDUEP
                tgteduep.ADDINFO_TAB.ForEach(a => a.TGTEDUEP = tgteduep);
                daoAddInfo.SaveAll(tgteduep.ADDINFO_TAB);

                //Inserir na RESPONSE/TGTEDUEP/NFEREF_TAB o RESPONSE/TGTEDUEP
                tgteduep.NFEREF_TAB.ForEach(n => n.TGTEDUEP = tgteduep);
                daoNfeRef.SaveAll(tgteduep.NFEREF_TAB);

                //Inserir na RESPONSE/TGTEDUEP/ATOCON_TAB o RESPONSE/TGTEDUEP
                tgteduep.ATOCON_TAB.ForEach(a => a.TGTEDUEP = tgteduep);
                daoAtocon.SaveAll(tgteduep.ATOCON_TAB);

                //Inserir na RESPONSE/TGTEDUEP/DUEATRIB_TAB o RESPONSE/TGTEDUEP
                tgteduep.DUEATRIB_TAB.ForEach(d => d.TGTEDUEP = tgteduep);
                daoDueatrib.SaveAll(tgteduep.DUEATRIB_TAB);
            }
        }
    }
}