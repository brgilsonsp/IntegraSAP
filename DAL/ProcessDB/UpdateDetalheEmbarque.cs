using System;
using DAL.ObjectMessages;
using Util.InnerException;
using Util.InnerUtil;
using System.Collections.Generic;
using System.Data.Objects;

namespace DAL.ProcessDB
{
    public class UpdateDetalheEmbarque : UpdateDB<Msg2RetornoDetalheEmbarque>
    {
        /// <summary>
        /// Atualiza o Detalhe do Embarque no banco de dados
        /// </summary>
        /// <param name="registro">Msg2RetornoDetalheEmbarque</param>
        /// <param name="embarque">string</param>
        /// <returns>Quantidade de Detalhes salvo</returns>
        public int atualizaRegistro(Msg2RetornoDetalheEmbarque registro, string embarque)
        {
            try
            {
                //Obtém no banco de dados o ID do embarque
                int idEmbarque = new IDEmbarque().getIdEmbarque(embarque);

                //Verifica se o Detalhe para esse embarque já esta salvo
                if (IsSaveDetalheEmbarque(idEmbarque, registro.RESPONSE.TGTESHK_N.SBELN))
                {
                    //Se o Detalhe já foi salvo, excluir todo o Detalhe
                    DeleteDetalheEmbarque(idEmbarque);
                }
                //Salvar o Detalhe
                return SaveDetalheEmbarque(registro, idEmbarque);
            }
            catch (BaseInnerException baseEx)
            {
                throw new UpdateDBException(baseEx.Message, baseEx);
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_UPDATE_DETALHE_EMBARQUE_DB, Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        private int SaveDetalheEmbarque(Msg2RetornoDetalheEmbarque registro, int idEmbarque)
        {
            int retorno = 0;
            using (var bd = new BrokerMessageEntities())
            {
                //Salva o detalhe do embarque
                //salva cabeçalho
                retorno = SaveHeader(bd, registro.RESPONSE.TGTESHK_N, idEmbarque);
                //salva itens
                SaveItems(bd, registro.RESPONSE.TGTESHP_N, idEmbarque);
                //salva parceiros
                SavePartners(bd, registro.RESPONSE.TGTEPRD, idEmbarque);
                //salva textoscabecalho
                SaveTextsReader(bd, registro.RESPONSE.SHP_TEXT, idEmbarque);
                //salva res
                SaveREs(bd, registro.RESPONSE.TGTERES, idEmbarque);
            }
            //Aguarda um período para garantir o encerramento da conexão com o BD
            TimeClosing.ThreadForCloseConnectionDB();
            return retorno;
        }

        /// <summary>
        /// Salva o cabeçalho do Detalhe do Embarque, a tabela TGTESHKN
        /// </summary>
        /// <param name="bd">BrokerMessageEntities</param>
        /// <param name="header">TGTESHKN</param>
        /// <param name="idEmbarque">int</param>
        private int SaveHeader(BrokerMessageEntities bd, TGTESHKN header, int idEmbarque)
        {
            try
            {                
                return bd.spSalvaTGTESHKN(idEmbarque, header.LOCSE, header.TIPSE, header.TSETMP, header.SEDAT_DateTime,
                    header.ETADT_DateTime, header.ENVDT_DateTime, header.PREVDT_DateTime, header.TRANS, header.ZOLLAO,
                    header.ZLANDO, header.ZOLLAD, header.ZLANDD, header.NETWR, header.WAERSRF, header.INCO1, header.ZTERM,
                    header.SESTAT, header.WAERS, header.BFMAR, header.SHPTRIP, header.ETDDT_DateTime, header.BLNMB,
                    header.BLDTA_DateTime, header.HSAWB, header.SHPNAM, header.INVNR, header.DT_INVNR_DateTime, header.VOLUM,
                    header.NTGEW, header.BRGEW, header.VLFRETE, header.MOEDAFRT, header.VLSEGURO, header.MOEDASGR,
                    header.VLCOAGT, header.MOEDACOAGT, header.PCCOAGT, header.TPCOAGT, header.DTCLTC_DateTime,
                    header.DTEARM_DateTime, header.DTENTC_DateTime, header.URFDESP, header.URFEMBA, header.MODPAG, header.BASCOM,
                    header.PRECLCT, header.DTCOLETA_DateTime, header.DTCHGARM_DateTime, header.DTPRESC_DateTime,
                    header.DTAVERB_DateTime, header.DTENTREGA_DateTime, header.BROKNM, header.NMBOOK, header.DTBOOK_DateTime,
                    header.TPVEIC, header.TPCARG, header.UFEMBARQ, header.INSTNEG, header.TPPRP, header.DTSHIP_DateTime,
                    header.NROCE, header.DTCE_DateTime, header.Type);
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_UPDATE_TABLE_DETALHE_EMBARQUE_BD.Replace("?", "TGTESHKN"), Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        /// <summary>
        /// Salva os Itens do Detalhe do Embarque, a tabela TGTESHPN
        /// </summary>
        /// <param name="bd">BrokerMessageEntities</param>
        /// <param name="itens">List<TGTESHPN></param>
        /// <param name="idEmbarque">int</param>
        private void SaveItems(BrokerMessageEntities bd, List<TGTESHPN> itens, int idEmbarque)
        {
            try
            {
                if (itens != null && itens.Count > 0)
                {
                    foreach (TGTESHPN item in itens)
                    {
                        if (item != null)
                        {
                            ObjectParameter idTGTESHPN = new ObjectParameter("OUTId", typeof(int));

                            bd.spSalvaTGTESHPN(idEmbarque, item.SBELP, item.NBELP, item.DOCFAT, item.ITMFAT, item.MATNR, item.MAKTX,
                                item.QTDITM, item.NETPR, item.KPEIN, item.MEINS, item.NETWR, item.FRTLOC, item.FRTINT, item.SEGINT,
                                item.PRCFOB, item.PRCEXW, item.PCTCOM, item.VLRCOM, item.RENUM, item.ITMRE, item.ENQDM, item.BRGEW,
                                item.NTGEW, item.GEWEI, item.VOLUM, item.VOLEH, item.STEUC, item.NALADISH, item.FABITM, item.ATOCON,
                                item.AMCCPTC, item.BRCCPTC, item.CCROM, item.FABRILUF, item.NETPRORI, item.KPEINORI, item.MEINSORI,
                                item.NETWRORI, item.PROD, item.FKDAT_DateTime, item.Type, idTGTESHPN);

                            int idTGTESHPNSalvo = (int)idTGTESHPN.Value;
                            //Salva as Descrições detalhadas do material
                            if (item.MAKTX_TEXT != null && item.MAKTX_TEXT.Count > 0)
                            {
                                foreach (MAKTXTEXT texto in item.MAKTX_TEXT)
                                {
                                    if (texto != null)
                                    {
                                        bd.spSalvaMAKTX_TEXT(idTGTESHPNSalvo, texto.TEXT, texto.Type);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_UPDATE_TABLE_DETALHE_EMBARQUE_BD.Replace("?", "TGTESHPN"), Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        /// <summary>
        /// Salva os Parceiros do Detalhe do Embarque, tabela TGTEPRD
        /// </summary>
        /// <param name="bd">BrokerMessageEntities</param>
        /// <param name="parceiros">List<TGTEPRD></param>
        /// <param name="idEmbarque">int</param>
        private void SavePartners(BrokerMessageEntities bd, List<TGTEPRD> parceiros, int idEmbarque)
        {
            try
            {
                if (parceiros != null && parceiros.Count > 0)
                {
                    foreach (TGTEPRD parceiro in parceiros)
                    {
                        if (parceiro != null)
                        {
                            bd.spSalvaTGTEPRD(idEmbarque, parceiro.PARVW, parceiro.PARID, parceiro.NAME1, parceiro.NAME2,
                                parceiro.STREET, parceiro.HOUSE_NUM1, parceiro.HOUSE_NUM2, parceiro.POSTE_CODE1, parceiro.CITY1,
                                parceiro.CITY2, parceiro.PSTLZ, parceiro.REGION, parceiro.COUNTRY, parceiro.STCD1, parceiro.STCD3,
                                parceiro.STCD4, parceiro.Type);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_UPDATE_TABLE_DETALHE_EMBARQUE_BD.Replace("?", "TGTEPRD"), Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        /// <summary>
        /// Salva os Textos do Cabeçalho do Detalhe do Embarque, tabela SHPTEXT
        /// </summary>
        /// <param name="bd">BrokerMessageEntities</param>
        /// <param name="textosCabecalho">List<SHPTEXT></param>
        /// <param name="idEmbarque">int</param>
        private void SaveTextsReader(BrokerMessageEntities bd, List<SHPTEXT> textosCabecalho, int idEmbarque)
        {
            try
            {
                if (textosCabecalho != null && textosCabecalho.Count > 0)
                {
                    foreach (SHPTEXT textoCabecalho in textosCabecalho)
                    {
                        if (textoCabecalho != null)
                        {
                            bd.spSalvaSHPTEXT(idEmbarque, textoCabecalho.TDID, textoCabecalho.TDLINE, textoCabecalho.Type);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_UPDATE_TABLE_DETALHE_EMBARQUE_BD.Replace("?", "SHPTEXT"), Environment.NewLine);
                msg += string.Format("{0} {1}", ex.Message, Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        /// <summary>
        /// Salva as RE's do Detalhe do Embarque, tabela TGTERES
        /// </summary>
        /// <param name="bd">BrokerMessageEntities</param>
        /// <param name="res">List<TGTERES></param>
        /// <param name="idEmbarque">int</param>
        private void SaveREs(BrokerMessageEntities bd, List<TGTERES> res, int idEmbarque)
        {
            try
            {
                if (res != null && res.Count > 0)
                {
                    foreach (TGTERES re in res)
                    {
                        if (re != null)
                        {
                            bd.spSalvaTGTERES(idEmbarque, re.DSENUM, re.RENUM, re.ANDAT_DateTime, re.REDAT_DateTime, re.AVBDT_DateTime,
                                re.CANAL, re.DDENUM, re.DDEDT_DateTime, re.DDESQ, re.REANX, re.DSESQ, re.DOCFAT, re.XBLNR, re.INCO1,
                                re.WAERS, re.DDEADT_DateTime, re.Type);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}",
                    MessagesOfReturn.ERROR_UPDATE_TABLE_DETALHE_EMBARQUE_BD.Replace("?", "SHPTEXT"), Environment.NewLine);
                throw new UpdateDBException(msg, ex);
            }
        }

        /// <summary>
        /// Verifica se o Detalhe do Embarque já esta salvo. Retorna true se 
        /// o Detalhe do Embarque esta salvo e false caso contrário.
        /// </summary>
        /// <param name="idEmbarque">int</param>
        /// <param name="embarque">string</param>
        /// <returns>true se o Detalhe do Embarque esta salvo e false caso contrário.</returns>
        private bool IsSaveDetalheEmbarque(int idEmbarque, string embarque)
        {
            bool retorno = false;
            using (var bd = new BrokerMessageEntities())
            {
                var embarqueSalvo = bd.spConsultaDetalheEmbarqueSalvo(idEmbarque);

                foreach (string reg in embarqueSalvo)
                {
                    if (reg.Equals(embarque))
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Exclui o Detalhe do Embarque no banco de dados
        /// </summary>
        /// <param name="idEmbarque">int</param>
        private void DeleteDetalheEmbarque(int idEmbarque)
        {
            using (var bd = new BrokerMessageEntities())
            {
                bd.spExcluiDetalheEmbarque(idEmbarque);
            }
        }
    }
}
