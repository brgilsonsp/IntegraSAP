using DAL.ObjectMessages;
using DAL.ProcessDB;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerException;
using Util.InnerUtil;

namespace DAL.ProcessDB
{
    public class SelectDetalheEmbarque : SelectDB<Msg3AtualizaDetalheEmbarque>
    {
        public Msg3AtualizaDetalheEmbarque consultaRegistro(Embarque embarqueObj)
        {
            String embarque = embarqueObj.SBELN;
            try
            {
                List<spConsultaRequest_Result> spRequest;
                List<spConsultaDetalheEmbarqueTGTESHKN_Result> spCabecalho;
                List<spConsultaDetalheEmbarqueTGTESHPN_Result> spItem;
                List<spConsultaDetalheEmbarqueMAKTX_TEXT_Result> spTextoItem;
                List<spConsultaDetalheEmbarqueTGTEPRD_Result> spPaceiro;
                List<spConsultaDetalheEmbarqueSHPTEXT_Result> spTextoCabecalho;
                List<spConsultaDetalheEmbarqueTGTERES_Result> spRE;
                using (var bd = new BrokerMessageEntities())
                {
                    //Obtém os dados de configuração da Request
                    spRequest = bd.spConsultaRequest(Option.MENSAGEM3, embarqueObj.IDDadosBroker).ToList();
                    //Obtem o Cabeçalho, tabela TGTESHKN
                    spCabecalho = bd.spConsultaDetalheEmbarqueTGTESHKN(embarque).ToList();
                    //Obtem uma lista de Itens, tabela TGTESKPN
                    spItem = bd.spConsultaDetalheEmbarqueTGTESHPN(embarque).ToList();
                    //Obtem uma lista de Texto de Itens, tabela MAKTX_TEXT
                    spTextoItem = bd.spConsultaDetalheEmbarqueMAKTX_TEXT(embarque).ToList();
                    //Obtem uma lista de Parceiros, tabela TGTEPRD
                    spPaceiro = bd.spConsultaDetalheEmbarqueTGTEPRD(embarque).ToList();
                    //Obtem uma lista de Textos do Cabeçalho, tabela SHPTEXT
                    spTextoCabecalho = bd.spConsultaDetalheEmbarqueSHPTEXT(embarque).ToList();
                    //Obtem uma lista de RE, tabela TGTERES
                    spRE = bd.spConsultaDetalheEmbarqueTGTERES(embarque).ToList();
                }
                //Aguarda um período para garantir o encerramento da conexão com o BD
                TimeClosing.ThreadForCloseConnectionDB();

                //Se os dados do Broker e/ou o Cabeçalho forem nulo, não deve continuar
                Msg3AtualizaDetalheEmbarque detalheEmbarque = GetRequest(spRequest, Option.MENSAGEM3);
                TGTESHKN tgteshkn = GetCabecalho(spCabecalho, embarque);
                if (detalheEmbarque != null && tgteshkn != null)
                {
                    detalheEmbarque.REQUEST.TGTESHK_N = tgteshkn;
                    detalheEmbarque.REQUEST.TGTESHP_N = GetItem(spItem, embarque, spTextoItem);
                    detalheEmbarque.REQUEST.TGTEPRD = GetPaceiro(spPaceiro, embarque);
                    detalheEmbarque.REQUEST.SHP_TEXT = GetTextoCabecalho(spTextoCabecalho, embarque);
                    detalheEmbarque.REQUEST.TGTERES = GetRE(spRE, embarque);
                    return detalheEmbarque;
                }else // Um ou mais dados necessário para a atualização do Detalhe não foram preenchidos
                {
                    return null;
                }
            } catch (Exception ex)
            {
                string msg = string.Format("{0} {1} {2} {1}",
                    MessagesOfReturn.ERROR_CONSULT_DETALHE_EMBARQUE.Replace("?", embarque), Environment.NewLine, ex.InnerException);
                throw new SelectDBException(msg, ex);
            }
        }

        /// <summary>
        /// Instancia um objeto Msg3AtualizaDetalheEmbarque e alimenta com os dados do registro
        /// enviado no parâmetro requestsResult
        /// </summary>
        /// <param name="requestsResult">List<spConsultaRequest_Result></param>
        /// <param name="mensagem">byte</param>
        /// <returns>Msg3AtualizaDetalheEmbarque</returns>
        public Msg3AtualizaDetalheEmbarque GetRequest(List<spConsultaRequest_Result> requestsResult, byte mensagem)
        {
            Msg3AtualizaDetalheEmbarque embarque = null;
            if (requestsResult != null && requestsResult.Count > 0)
            {                
                foreach (spConsultaRequest_Result requestResult in requestsResult)
                {
                    if (requestResult.Mensagem == mensagem)
                    {
                        embarque = new Msg3AtualizaDetalheEmbarque();
                        RequestMsg3 requestMsg3 = new RequestMsg3();
                        STR str = new STR();
                        str.Type = requestResult.STRType;
                        str.XMLVR = requestResult.XMLVR;
                        str.ENVRM = requestResult.ENVRM;
                        str.INTNR = requestResult.INTNR;

                        requestMsg3.Type = requestResult.RquestType;
                        requestMsg3.ACAO = requestResult.ACAO;
                        requestMsg3.IDBR = requestResult.IDBR;
                        requestMsg3.IDCL = requestResult.IDCL;
                        requestMsg3.SHKEY = requestResult.SHKEY;

                        embarque.EDX = requestResult.EDX;
                        embarque.REQUEST = requestMsg3;
                        embarque.REQUEST.STR = str;
                    }
                }
            }
            return embarque;
        }

        /// <summary>
        /// Alimenta em um objeto o registro da tabela TGTESHN
        /// </summary>
        /// <param name="cabecalho">ObjectResult<spConsultaDetalheEmbarqueTGTESHKN_Result></param>
        /// <param name="embarque">string</param>
        /// <returns>Um objeto TGTESHKN, ou null se não localizar os dados</returns>
        private TGTESHKN GetCabecalho(List<spConsultaDetalheEmbarqueTGTESHKN_Result> cabecalhosResult, string embarque)
        {
            TGTESHKN cabecalho = null;
            if (cabecalhosResult != null && cabecalhosResult.Count > 0)
            {
                foreach (spConsultaDetalheEmbarqueTGTESHKN_Result cabecalhoResult in cabecalhosResult)
                {
                    if (cabecalhoResult.SBELN.Equals(embarque))
                    {
                        cabecalho = new TGTESHKN();
                        cabecalho.SBELN = cabecalhoResult.SBELN;
                        cabecalho.LOCSE = cabecalhoResult.TGTESHKN_LOCSE;
                        cabecalho.TIPSE = cabecalhoResult.TGTESHKN_TIPSE;
                        cabecalho.TSETMP = cabecalhoResult.TGTESHKN_TSETMP;
                        cabecalho.SEDAT = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_SEDAT);
                        cabecalho.ETADT = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_ETADT);
                        cabecalho.ENVDT = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_ENVDT);
                        cabecalho.PREVDT = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_PREVDT);
                        cabecalho.TRANS = cabecalhoResult.TGTESHKN_TRANS;
                        cabecalho.ZOLLAO = cabecalhoResult.TGTESHKN_ZOLLAO;
                        cabecalho.ZLANDO = cabecalhoResult.TGTESHKN_ZOLANDO;
                        cabecalho.ZOLLAD = cabecalhoResult.TGTESHKN_ZOLLAD;
                        cabecalho.ZLANDD = cabecalhoResult.TGTESHKN_ZOLANDD;
                        cabecalho.NETWR = (decimal)cabecalhoResult.TGTESHKN_NETWR;
                        cabecalho.WAERSRF = cabecalhoResult.TGTESHKN_WAERSRF;
                        cabecalho.INCO1 = cabecalhoResult.TGTESHKN_INCO1;
                        cabecalho.ZTERM = cabecalhoResult.TGTESHKN_ZTERM;
                        cabecalho.SESTAT = cabecalhoResult.TGTESHKN_SESTAT;
                        cabecalho.WAERS = cabecalhoResult.TGTESHKN_WAERS;
                        cabecalho.BFMAR = cabecalhoResult.TGTESHKN_BFMAR;
                        cabecalho.SHPTRIP = cabecalhoResult.TGTESHKN_SHPTRIP;
                        cabecalho.ETDDT = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_ETDDT);
                        cabecalho.BLNMB = cabecalhoResult.TGTESHKN_BLNMB;
                        cabecalho.BLDTA = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_BLDTA);
                        cabecalho.HSAWB = cabecalhoResult.TGTESHKN_HSAWB;
                        cabecalho.SHPNAM = cabecalhoResult.TGTESHKN_SHPNAM;
                        cabecalho.INVNR = cabecalhoResult.TGTESHKN_INVNR;
                        cabecalho.DT_INVNR = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DT_INVMR);
                        cabecalho.VOLUM = (decimal)cabecalhoResult.TGTESHKN_VOLUM;
                        cabecalho.NTGEW = (decimal)cabecalhoResult.TGTESHKN_NTGEW;
                        cabecalho.BRGEW = (decimal)cabecalhoResult.TGTESHKN_BRGEW;
                        cabecalho.VLFRETE = (decimal)cabecalhoResult.TGTESHKN_VLFRETE;
                        cabecalho.MOEDAFRT = cabecalhoResult.TGTESHKN_MOEDAFRT;
                        cabecalho.VLSEGURO = (decimal)cabecalhoResult.TGTESHKN_VLSEGURO;
                        cabecalho.MOEDASGR = cabecalhoResult.TGTESHKN_MOEDASGR;
                        cabecalho.VLCOAGT = (decimal)cabecalhoResult.TGTESHKN_VLCOAGT;
                        cabecalho.MOEDACOAGT = cabecalhoResult.TGTESHKN_MOEDACOAGT;
                        cabecalho.PCCOAGT = (decimal)cabecalhoResult.TGTESHKN_PCCOAGT;
                        cabecalho.TPCOAGT = cabecalhoResult.TGTESHKN_TPCOAGT;
                        cabecalho.DTCLTC = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTCLTC);
                        cabecalho.DTEARM = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTEARM);
                        cabecalho.DTENTC = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTENTC);
                        cabecalho.URFDESP = cabecalhoResult.TGTESHKN_URFDESP;
                        cabecalho.URFEMBA = cabecalhoResult.TGTESHKN_URFEMBA;
                        cabecalho.MODPAG = cabecalhoResult.TGTESHKN_MODPAG;
                        cabecalho.BASCOM = cabecalhoResult.TGTESHKN_BASCOM;
                        cabecalho.PRECLCT = cabecalhoResult.TGTESHKN_PRECLCT;
                        cabecalho.DTCOLETA = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTCOLETA);
                        cabecalho.DTCHGARM = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTCHGARM);
                        cabecalho.DTPRESC = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTPRESC);
                        cabecalho.DTAVERB = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTAVERB);
                        cabecalho.DTENTREGA = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTENTREGA);
                        cabecalho.BROKNM = cabecalhoResult.TGTESHKN_BROKNM;
                        cabecalho.NMBOOK = cabecalhoResult.TGTESHKN_NMBOOK;
                        cabecalho.DTBOOK = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTBOOK);
                        cabecalho.TPVEIC = cabecalhoResult.TGTESHKN_TPVEIC;
                        cabecalho.TPCARG = cabecalhoResult.TGTESHKN_TPCARG;
                        cabecalho.UFEMBARQ = cabecalhoResult.TGTESHKN_UFEMBARQ;
                        cabecalho.INSTNEG = cabecalhoResult.TGTESHKN_INSTNEG;
                        cabecalho.TPPRP = cabecalhoResult.TGTESHKN_TPPRP;
                        cabecalho.DTSHIP = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTSHIP);
                        cabecalho.NROCE = cabecalhoResult.TGTESHKN_NROCE;
                        cabecalho.DTCE = ConfigureDate.converDateTimeForDateString(cabecalhoResult.TGTESHKN_DTCE);
                        cabecalho.Type = cabecalhoResult.TGTESHKN_TypeTGTESHKN;
                    }
                }
            }
            return cabecalho;
        }

        /// <summary>
        /// Alimenta em list de objetos os registros da tabela TGTESHPN
        /// </summary>
        /// <param name="itens">ObjectResult<spConsultaDetalheEmbarqueTGTESHPN_Result></param>
        /// <param name="embarque">string</param>
        /// <returns>Um list de objeto TGTESHPN, ou null se não localizar os dados</returns>
        private List<TGTESHPN> GetItem(List<spConsultaDetalheEmbarqueTGTESHPN_Result> itemsResult, string embarque,
            List<spConsultaDetalheEmbarqueMAKTX_TEXT_Result> textosItem)
        {
            List<TGTESHPN> listaItem = null;
            if (itemsResult != null && itemsResult.Count > 0)
            {
                listaItem = new List<TGTESHPN>();
                foreach (spConsultaDetalheEmbarqueTGTESHPN_Result itemR in itemsResult)
                {
                    if (itemR.SBELN.Equals(embarque))
                    {
                        TGTESHPN item = new TGTESHPN();
                        item.SBELN = itemR.SBELN;
                        item.SBELP = (int)itemR.TGTESHPN_SBELP;
                        item.NBELP = (int)itemR.TGTESHPN_NBELP;
                        item.DOCFAT = itemR.TGTESHPN_DOCFAT;
                        item.ITMFAT = (decimal)itemR.TGTESHPN_ITMFAT;
                        item.MATNR = itemR.TGTESHPN_MATNR;
                        item.MAKTX = itemR.TGTESHPN_MAKTX;
                        item.MAKTX_TEXT = GetTextoItem(textosItem, itemR.TGTESHPN_ID, embarque);
                        item.QTDITM = (decimal)itemR.TGTESHPN_QTDITM;
                        item.NETPR = (decimal)itemR.TGTESHPN_NETPR;
                        item.KPEIN = (decimal)itemR.TGTESHPN_KPEIN;
                        item.MEINS = itemR.TGTESHPN_MEINS;
                        item.NETWR = (decimal)itemR.TGTESHPN_NETWR;
                        item.FRTLOC = (decimal)itemR.TGTESHPN_FRTLOC;
                        item.FRTINT = (decimal)itemR.TGTESHPN_FRTINT;
                        item.SEGINT = (decimal)itemR.TGTESHPN_SEGINT;
                        item.PRCFOB = (decimal)itemR.TGTESHPN_PRCFOB;
                        item.PRCEXW = (decimal)itemR.TGTESHPN_PRCEXW;
                        item.PCTCOM = (decimal)itemR.TGTESHPN_PCTCOM;
                        item.VLRCOM = (decimal)itemR.TGTESHPN_VLRCOM;
                        item.RENUM = itemR.TGTESHPN_RENUM;
                        item.ITMRE = (int)itemR.TGTESHPN_ITMRE;
                        item.ENQDM = itemR.TGTESHPN_ENQDM;
                        item.BRGEW = (decimal)itemR.TGTESHPN_BRGEW;
                        item.NTGEW = (decimal)itemR.TGTESHPN_NTGEW;
                        item.GEWEI = itemR.TGTESHPN_GEWEI;
                        item.VOLUM = (decimal)itemR.TGTESHPN_VOLUM;
                        item.VOLEH = itemR.TGTESHPN_VOLEH;
                        item.STEUC = itemR.TGTESHPN_STEUC;
                        item.NALADISH = itemR.TGTESHPN_NALADISH;
                        item.FABITM = itemR.TGTESHPN_FABITM;
                        item.ATOCON = itemR.TGTESHPN_ATOCON;
                        item.AMCCPTC = itemR.TGTESHPN_AMCCPTC;
                        item.BRCCPTC = itemR.TGTESHPN_BRCCPTC;
                        item.CCROM = itemR.TGTESHPN_CCROM;
                        item.FABRILUF = itemR.TGTESHPN_FABRILUF;
                        item.NETPRORI = (decimal)itemR.TGTESHPN_NETPRORI;
                        item.KPEINORI = (decimal)itemR.TGTESHPN_KPEINORI;
                        item.MEINSORI = itemR.TGTESHPN_MEINSORI;
                        item.NETWRORI = (decimal)itemR.TGTESHPN_NETWRORI;
                        item.PROD = itemR.TGTESHPN_PROD;
                        item.FKDAT = ConfigureDate.converDateTimeForDateString(itemR.TGTESHPN_FKDAT);
                        item.Type = itemR.TGTESHPN_TypeTGTESHPN;

                        listaItem.Add(item);
                    }
                }
            }
            return listaItem;
        }

        /// <summary>
        /// Alimenta em list de objetos os registros da tabela MAKTXTEXT
        /// </summary>
        /// <param name="textosItem">ObjectResult<spConsultaDetalheEmbarqueMAKTX_TEXT_Result></param>
        /// <param name="idItem">int</param>
        /// <param name="embarque">string</param>
        /// <returns>Um List de objeto MAKTXTEX, ou null se não localizar os dados</returns>
        private List<MAKTXTEXT> GetTextoItem(List<spConsultaDetalheEmbarqueMAKTX_TEXT_Result> textosItemResult, 
            int idItem, string embarque)
        {
            List<MAKTXTEXT> listaTextoItem = null;
            if (textosItemResult != null && textosItemResult.Count > 0)
            {
                listaTextoItem = new List<MAKTXTEXT>();
                foreach (spConsultaDetalheEmbarqueMAKTX_TEXT_Result textosItemR in textosItemResult)
                {
                    if (textosItemR.SBELN.Equals(embarque) && textosItemR.TGTESHPN_ID == idItem)
                    {
                        MAKTXTEXT textoItem = new MAKTXTEXT();
                        textoItem.Type = textosItemR.MAKTX_TEXT_TypeMaktx;
                        textoItem.TEXT = textosItemR.MAKTX_TEXT_TEXT;

                        listaTextoItem.Add(textoItem);
                    }
                }
            }
            return listaTextoItem;
        }

        /// <summary>
        /// Alimenta em list de objetos os registros da tabela TGTEPRD
        /// </summary>
        /// <param name="parceiros">ObjectResult<spConsultaDetalheEmbarqueTGTEPRD_Result></param>
        /// <param name="embarque">string</param>
        /// <returns>Um List de objeto TGTEPRD, ou null se não localizar os dados</returns>
        private List<TGTEPRD> GetPaceiro(List<spConsultaDetalheEmbarqueTGTEPRD_Result> parceirosResult, 
            string embarque)
        {
            List<TGTEPRD> listaParceiros = null;
            if (parceirosResult != null && parceirosResult.Count > 0)
            {
                listaParceiros = new List<TGTEPRD>();
                foreach (spConsultaDetalheEmbarqueTGTEPRD_Result parceirosR in parceirosResult)
                {
                    if (parceirosR.SBELN.Equals(embarque))
                    {
                        TGTEPRD parceiro = new TGTEPRD();
                        parceiro.PARVW = parceirosR.PartEmb_PARVW;
                        parceiro.PARID = parceirosR.PartEmb_PARID;
                        parceiro.NAME1 = parceirosR.PartEmb_NAME1;
                        parceiro.NAME2 = parceirosR.PartEmb_NAME2;
                        parceiro.STREET = parceirosR.PartEmb_STREET;
                        parceiro.HOUSE_NUM1 = parceirosR.PartEmb_HOUSE_NUM1;
                        parceiro.HOUSE_NUM2 = parceirosR.PartEmb_HOUSE_NUM2;
                        parceiro.POSTE_CODE1 = parceirosR.PartEmb_POST_CODE1;
                        parceiro.CITY1 = parceirosR.PartEmb_CITY1;
                        parceiro.CITY2 = parceirosR.PartEmb_CITY2;
                        parceiro.PSTLZ = parceirosR.PartEmb_PSTLZ;
                        parceiro.REGION = parceirosR.PartEmb_REGION;
                        parceiro.COUNTRY = parceirosR.PartEmb_COUNTRY;
                        parceiro.STCD1 = parceirosR.PartEmb_STCD1;
                        parceiro.STCD3 = parceirosR.PartEmb_STCD3;
                        parceiro.STCD4 = parceirosR.PartEmb_STCD4;
                        parceiro.Type = parceirosR.PartEmb_TypeTGTEPRD;

                        listaParceiros.Add(parceiro);
                    }
                }
            }
            return listaParceiros;
        }

        /// <summary>
        /// Alimenta em list de objetos os registros da tabela SHPTEXT
        /// </summary>
        /// <param name="textosCabecalho">ObjectResult<spConsultaDetalheEmbarqueSHPTEXT_Result></param>
        /// <param name="embarque">string</param>
        /// <returns>Um list de objeto SHPTEXT, ou null se não localizar os dados</returns>
        private List<SHPTEXT> GetTextoCabecalho(List<spConsultaDetalheEmbarqueSHPTEXT_Result> textosCabecalhoResult, 
            string embarque)
        {
            List<SHPTEXT> listaTextoCabecalho = null;
            if (textosCabecalhoResult != null && textosCabecalhoResult.Count > 0)
            {
                listaTextoCabecalho = new List<SHPTEXT>();
                foreach (spConsultaDetalheEmbarqueSHPTEXT_Result txtCabecalhoR in textosCabecalhoResult)
                {
                    if (txtCabecalhoR.SBELN.Equals(embarque))
                    {
                        SHPTEXT textoCab = new SHPTEXT();
                        textoCab.TDID = txtCabecalhoR.SHPTEXT_TDID;
                        textoCab.TDLINE = txtCabecalhoR.SHPTEXT_TDLINE;
                        textoCab.Type = txtCabecalhoR.SHPTEXT_TypeSHPTEX;

                        listaTextoCabecalho.Add(textoCab);
                    }
                }
            }
            return listaTextoCabecalho;

        }

        /// <summary>
        /// Alimenta em list de objetos os registros da tabela TGTERES
        /// </summary>
        /// <param name="res">ObjectResult<spConsultaDetalheEmbarqueTGTERES_Result></param>
        /// <param name="embarque"string></param>
        /// <returns>Um List de objeto TGTERES, ou null se não localizar os dados</returns>
        private List<TGTERES> GetRE(List<spConsultaDetalheEmbarqueTGTERES_Result> resResult, string embarque)
        {
            List<TGTERES> listaRE = null;
            if (resResult != null && resResult.Count > 0)
            {
                listaRE = new List<TGTERES>();
                foreach (spConsultaDetalheEmbarqueTGTERES_Result resR in resResult)
                {
                    if (resR.SBELN.Equals(embarque))
                    {
                        TGTERES re = new TGTERES();
                        re.SBELN = resR.SBELN;
                        re.DSENUM = resR.TGTERES_DSENUM;
                        re.RENUM = resR.TGTERES_RENUM;
                        re.ANDAT = ConfigureDate.converDateTimeForDateString(resR.TGTERES_ANDAT);
                        re.REDAT = ConfigureDate.converDateTimeForDateString(resR.TGTERES_REDAT);
                        re.AVBDT = ConfigureDate.converDateTimeForDateString(resR.TGTERES_AVBDT);
                        re.CANAL = resR.TGTERES_CANAL;
                        re.DDENUM = resR.TGTERES_DDENUM;
                        re.DDEDT = ConfigureDate.converDateTimeForDateString(resR.TGTERES_DDEDT);
                        re.DDESQ = resR.TGTERES_DDESQ;
                        re.REANX = resR.TGTERES_REANX;
                        re.DSESQ = (int)resR.TGTERES_DSESQ;
                        re.DOCFAT = resR.TGTERES_DOCFAT;
                        re.XBLNR = resR.TGTERES_XBLNR;
                        re.INCO1 = resR.TGTERES_INCO1;
                        re.WAERS = resR.TGTERES_WAERS;
                        re.DDEADT = ConfigureDate.converDateTimeForDateString(resR.TGTERES_DDEADT);
                        re.Type = resR.TGTERES_TypeTGTERES;

                        listaRE.Add(re);
                    }
                }
            }
            return listaRE;
        }
    }
}
