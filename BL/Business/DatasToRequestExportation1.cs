using System.Collections.Generic;
using BL.DAO;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using BL.InnerException;

namespace BL.Business
{
    class DatasToRequestExportation1 : IDatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<DadosBroker> dadosBroker = new DadosBrokerDao().FindAllAsNoTracking();

                foreach (DadosBroker cadaDadosBroker in dadosBroker)
                {
                    foreach (CabecalhoDadosBroker cabecalho in cadaDadosBroker.DadosBrokerCabecalho)
                    {
                        if (cabecalho.Cabecalho.Mensagem == Option.MENSAGEM1 && cabecalho.Cabecalho.Tipo == Option.EXPORTACAO)
                        {
                            RequestMessage1Exportation consulta = new RequestMessage1Exportation(new DataHeaderRequest(cabecalho.Cabecalho, cadaDadosBroker));
                            string xml = new SerializeXml<RequestMessage1Exportation>().serializeXmlForGTE(consulta);
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
