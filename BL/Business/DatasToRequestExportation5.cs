using BL.DAO;
using BL.InnerException;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Business
{
    class DatasToRequestExportation5 : IDatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindConsultaPrestacaoContaEnbaleAsNoTracking();

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.ConsultaPrestConta == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == Option.MENSAGEM5 && cab.Cabecalho.Tipo == Option.EXPORTACAO).Cabecalho;
                        ChangeXMLContext.GetInstance().Configuration.ProxyCreationEnabled = false;
                        if (cabecalho.Mensagem == Option.MENSAGEM5 && cabecalho.Tipo == Option.EXPORTACAO)
                        {
                            RequestMessage5Exportation consulta = new RequestMessage5Exportation(new DataHeaderRequest(cabecalho, dadosBroker), embarque);
                            string xml = new SerializeXml<RequestMessage5Exportation>().serializeXmlForGTE(consulta);
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
    }
}
