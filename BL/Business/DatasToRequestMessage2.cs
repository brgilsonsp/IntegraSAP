using System.Collections.Generic;
using System.Linq;
using BL.ObjectMessages;
using BL.DAO;
using BL.InnerUtil;
using System;
using BL.InnerException;

namespace BL.Business
{
    public class DatasToRequestMessage2 : IDatasOfRequest
    {
        private string _kindOfMessage;
        public DatasToRequestMessage2(string kindOfMessage)
        {
            _kindOfMessage = kindOfMessage;
        }

        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindConsultaDetalheEnableAsNoTracking(_kindOfMessage);
                byte numberOfMessage = (byte)NumberOfMessage.Two;

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.ConsultaDetalhe == true && embarque.Tipo == _kindOfMessage)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == numberOfMessage && cab.Cabecalho.Tipo == _kindOfMessage).Cabecalho;
                        if (cabecalho.Mensagem == numberOfMessage && cabecalho.Tipo == _kindOfMessage)
                        {
                            RequestMessage2 consulta = new RequestMessage2(new DataHeaderRequest(cabecalho, dadosBroker), embarque);
                            string xml = new SerializeXml<RequestMessage2>().serializeXmlForGTE(consulta);
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
