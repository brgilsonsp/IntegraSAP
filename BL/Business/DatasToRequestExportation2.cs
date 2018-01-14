using System.Collections.Generic;
using System.Linq;
using BL.ObjectMessages;
using BL.DAO;
using BL.InnerUtil;
using System;
using BL.InnerException;

namespace BL.Business
{
    public class DatasToRequestExportation2 : IDatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindConsultaDetalheEnableAsNoTracking();

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.ConsultaDetalhe == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == Option.MENSAGEM2).Cabecalho;
                        if (cabecalho.Mensagem == Option.MENSAGEM2)
                        {
                            RequestMessage2Exportation consulta = new RequestMessage2Exportation(new DataHeaderRequest(cabecalho, dadosBroker), embarque);
                            string xml = new SerializeXml<RequestMessage2Exportation>().serializeXmlForGTE(consulta);
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
    }
}
