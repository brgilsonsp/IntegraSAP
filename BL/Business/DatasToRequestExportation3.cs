using BL.DAO;
using System.Collections.Generic;
using System.Linq;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using BL.InnerException;

namespace BL.Business
{
    class DatasToRequestExportation3 : IDatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindAtualizaDetalheEnbaleAsNoTracking();

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.AtualizaDetalhe == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == Option.MENSAGEM3 && cab.Cabecalho.Tipo == Option.EXPORTACAO).Cabecalho;
                        if (cabecalho.Mensagem == Option.MENSAGEM3 && cabecalho.Tipo == Option.EXPORTACAO)
                        {
                            RequestMessage3Exportation consulta = GetObject(embarque, cabecalho, dadosBroker);
                            string xml = new SerializeXml<RequestMessage3Exportation>().serializeXmlForGTE(consulta);
                            dictonaryForConsulting.Add(embarque.SBELN, xml);
                        }
                    }
                }
                return dictonaryForConsulting;
            }
            catch (Exception ex)
            {
                throw new ChangeXmlException(MessagesOfReturn.ExceptionGetDatasToRequest, ex);
            }
        }

        private RequestMessage3Exportation GetObject(Embarque embarque, Cabecalho cabecalho, DadosBroker broker)
        {
            RequesExportationtMsg3 request = new RequesExportationtMsg3();
            request.Type = cabecalho.RequestType;
            request.ACAO = cabecalho.ACAO;
            request.IDBR = broker.IDBR;
            request.IDCL = broker.IDCL;
            request.SHKEY = broker.SHKEY;
            request.STR = new STR(broker);
            request.TGTESHK_N = new TGTESHK_NDao().FindByIdEmbarque(embarque.ID).FirstOrDefault();
            if(request.TGTESHK_N != null)
                request.TGTESHK_N.SBELN = embarque.SBELN;

            request.TGTESHP_N = new TGTESHP_NDao().FindByIDEmbarqueAsNoTracking(embarque.ID);
            if(request.TGTESHP_N != null)
                foreach (var tgteshpn in request.TGTESHP_N)
                    tgteshpn.SBELN = embarque.SBELN;

            request.TGTERES = new TGTERESDao().FindByIdEmbarqueAsNoTracking(embarque.ID);
            if(request.TGTERES != null)
                foreach (var tgteres in request.TGTERES)
                    tgteres.SBELN = embarque.SBELN;

            request.TGTEPRD = new TGTEPRDDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            request.SHP_TEXT = new SHP_TEXTDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            request.TGTEDUEK = new TGTEDUEKDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            request.TGTEDUEP = new TGTEDUEPDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            RequestMessage3Exportation requestMessage3 = new RequestMessage3Exportation();
            requestMessage3.EDX = cabecalho.MensagemEDX;
            requestMessage3.REQUEST = request;

            return requestMessage3;
        }
    }
}
