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
        private byte numberOfMessage = (byte)NumberOfMessage.Three;
        private string kindOfMessage = Option.EXPORTACAO;

        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindAtualizaDetalheEnbaleAsNoTracking(kindOfMessage);

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.AtualizaDetalhe == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == numberOfMessage && cab.Cabecalho.Tipo == kindOfMessage).Cabecalho;
                        if (cabecalho.Mensagem == numberOfMessage && cabecalho.Tipo == kindOfMessage)
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
            TGTESHK_N tgteshkn = new TGTESHK_NDao().FindByIdEmbarqueEager(embarque.ID).FirstOrDefault();
            RequesExportationtMsg3 request = new RequesExportationtMsg3();
            request.Type = cabecalho.RequestType;
            request.ACAO = cabecalho.ACAO;
            request.IDBR = broker.IDBR;
            request.IDCL = broker.IDCL;
            request.SHKEY = broker.SHKEY;
            request.STR = new STR(broker);

            request.TGTESHK_N = tgteshkn;
            if (request.TGTESHK_N != null)
                request.TGTESHK_N.SBELN = embarque.SBELN;
            
            request.TGTESHP_N = tgteshkn.TGTESHP_N;
            if (request.TGTESHP_N != null)
                foreach (var tgteshpn in request.TGTESHP_N)
                    tgteshpn.SBELN = embarque.SBELN;

            request.TGTERES = tgteshkn.TGTERES;
            if (request.TGTERES != null)
                foreach (var tgteres in request.TGTERES)
                    tgteres.SBELN = embarque.SBELN;

            request.TGTEPRD = tgteshkn.TGTEPRD;
            request.SHP_TEXT = tgteshkn.SHP_TEXT;
            request.TGTEDUEK = tgteshkn.TGTEDUEK;
            request.TGTEDUEP = tgteshkn.TGTEDUEP;

            RequestMessage3Exportation requestMessage3 = new RequestMessage3Exportation();
            requestMessage3.EDX = cabecalho.MensagemEDX;
            requestMessage3.REQUEST = request;

            return requestMessage3;
        }
    }
}
