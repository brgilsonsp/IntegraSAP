using System.Collections.Generic;
using BL.DAO;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using BL.InnerException;
using System.Linq;

namespace BL.Business
{
    class DatasToRequestMessage1 : IDatasOfRequest
    {

        private string _kindOfMessage;

        public DatasToRequestMessage1(string kind)
        {
            _kindOfMessage = kind;
        }

        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<DadosBroker> dadosBroker = new DadosBrokerDao().FindAllAsNoTracking();
                byte numberOfMessage = (byte)NumberOfMessage.One;

                foreach (DadosBroker cadaDadosBroker in dadosBroker)
                {
                    foreach (CabecalhoDadosBroker cabecalho in cadaDadosBroker.DadosBrokerCabecalho)
                    {
                        if (cabecalho.Cabecalho.Mensagem == numberOfMessage && cabecalho.Cabecalho.Tipo == _kindOfMessage)
                        {
                            RequestMessage1 consulta = new RequestMessage1(new DataHeaderRequest(cabecalho.Cabecalho, cadaDadosBroker));
                            string xml = new SerializeXml<RequestMessage1>().serializeXmlForGTE(consulta);
                            dictonaryForConsulting.Add(cadaDadosBroker.ID.ToString(), xml);
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
    }
}
