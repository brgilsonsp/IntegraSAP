using BL.DAO;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.InnerUtil;
using BL.Business;

namespace BL.ObjectMessages
{
    class DatasToRequestExportation3 : DatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
            IList<Embarque> listEmbarque = new EmbarqueDao().FindAtualizaDetalheEnbaleAsNoTracking();

            foreach (Embarque embarque in listEmbarque)
            {
                if (embarque != null && embarque.AtualizaDetalhe == true)
                {
                    DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                    Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == Option.MENSAGEM3 && cab.Cabecalho.Tipo == Option.EXPORTACAO).Cabecalho;
                    ChangeXMLContext.GetInstance().Configuration.ProxyCreationEnabled = false;
                    if (cabecalho.Mensagem == Option.MENSAGEM3 && cabecalho.Tipo == Option.EXPORTACAO)
                    {
                        Msg3RequestExportation consulta = GetObject(embarque, cabecalho, dadosBroker);
                        string xml = new XmlForGTE<Msg3RequestExportation>().serializeXmlForGTE(consulta);
                        dictonaryForConsulting.Add(embarque.SBELN, xml);
                    }
                }
            }
            ChangeXMLContext.GetInstance().Configuration.ProxyCreationEnabled = true;
            return dictonaryForConsulting;
        }

        private Msg3RequestExportation GetObject(Embarque embarque, Cabecalho cabecalho, DadosBroker broker)
        {
            RequesExportationtMsg3 request = new RequesExportationtMsg3();
            request.Type = cabecalho.RequestType;
            request.ACAO = cabecalho.ACAO;
            request.IDBR = broker.IDBR;
            request.IDCL = broker.IDCL;
            request.SHKEY = broker.SHKEY;
            request.STR = new STR(broker);
            request.TGTESHK_N = new TGTESHK_NDao().FindByIdEmbarque(embarque.ID).FirstOrDefault();
            request.TGTESHK_N.SBELN = embarque.SBELN;

            request.TGTESHP_N = new TGTESHP_NDao().FindByIDEmbarqueAsNoTracking(embarque.ID);
            foreach (var tgteshpn in request.TGTESHP_N)
                tgteshpn.SBELN = embarque.SBELN;

            request.TGTERES = new TGTERESDao().FindByIdEmbarqueAsNoTracking(embarque.ID);
            foreach (var tgteres in request.TGTERES)
                tgteres.SBELN = embarque.SBELN;

            request.TGTEPRD = new TGTEPRDDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            request.SHP_TEXT = new SHP_TEXTDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            request.TGTEDUEK = new TGTEDUEKDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            request.TGTEDUEP = new TGTEDUEPDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            Msg3RequestExportation requestMessage3 = new Msg3RequestExportation();
            requestMessage3.EDX = cabecalho.MensagemEDX;
            requestMessage3.REQUEST = request;

            return requestMessage3;
        }
    }
}
