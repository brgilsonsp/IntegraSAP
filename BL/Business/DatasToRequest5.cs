using BL.DAO;
using BL.InnerException;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Business
{
    class DatasToRequest5 : IDatasOfRequest
    {
        private string _kindfOeMessge;
        private byte _numberOfMessage;

        public DatasToRequest5(string kindfOeMessge)
        {
            _kindfOeMessge = kindfOeMessge;
            _numberOfMessage = (byte)NumberOfMessage.Five;
        }
        public IDictionary<string, string> GetDatasToRequest()
        {   
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindConsultaPrestacaoContaEnbaleAsNoTracking(_kindfOeMessge);

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.ConsultaPrestConta == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == _numberOfMessage && cab.Cabecalho.Tipo == _kindfOeMessge).Cabecalho;
                        ChangeXMLContext.GetInstance().Configuration.ProxyCreationEnabled = false;
                        if (cabecalho.Mensagem == _numberOfMessage && cabecalho.Tipo == _kindfOeMessge)
                        {
                            RequestMessage5 consulta = new RequestMessage5(new DataHeaderRequest(cabecalho, dadosBroker), embarque);
                            string xml = new SerializeXml<RequestMessage5>().serializeXmlForGTE(consulta);
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
