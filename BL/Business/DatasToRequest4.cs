using BL.DAO;
using BL.InnerException;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Business
{
    class DatasToRequest4 : IDatasOfRequest
    {
        private string _kindOfMessage;
        private byte _numberOfMessage;

        public DatasToRequest4(string kindOfMessage)
        {
            _kindOfMessage = kindOfMessage;
            _numberOfMessage = (byte)NumberOfMessage.Four;
        }
                
        public IDictionary<string, string> GetDatasToRequest()
        {
            try { 
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindEnviaPrestacaoContaEnbaleAsNoTracking(_kindOfMessage);

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.EnviaPrestConta == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == _numberOfMessage && cab.Cabecalho.Tipo == _kindOfMessage).Cabecalho;
                        if (cabecalho.Mensagem == _numberOfMessage && cabecalho.Tipo == _kindOfMessage)
                        {
                            RequestMessage4 consulta = GetObject(embarque, cabecalho, dadosBroker);
                            string xml = new SerializeXml<RequestMessage4>().serializeXmlForGTE(consulta);
                            dictonaryForConsulting.Add(embarque.SBELN, xml);
                        }
                    }
                }
                ChangeXMLContext.GetInstance().Configuration.ProxyCreationEnabled = true;
                return dictonaryForConsulting;
            }
            catch (Exception ex)
            {
                throw new ChangeXmlException(MessagesOfReturn.ExceptionGetDatasToRequest, ex);
            }
        }

        private RequestMessage4 GetObject(Embarque embarque, Cabecalho cabecalho, DadosBroker broker)
        {
            RequestMsg4 request = new RequestMsg4();
            request.Type = cabecalho.RequestType;
            request.ACAO = cabecalho.ACAO;
            request.IDBR = broker.IDBR;
            request.IDCL = broker.IDCL;
            request.SHKEY = broker.SHKEY;
            request.STR = new STR(broker);

            request.PCK = new TPCKDao().FindByIdEmbarqueEager(embarque.ID).ToList();
            if (request.PCK != null)
                request.PCK.ForEach(t => t.SBELN = embarque.SBELN);

            RequestMessage4 requestMessage4 = new RequestMessage4();
            requestMessage4.EDX = cabecalho.MensagemEDX;
            requestMessage4.REQUEST = request;

            return requestMessage4;
        }
    }
}
