using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ObjectMessages;
using BL.DAO;
using BL.InnerUtil;
using BL.Business;

namespace BL.ObjectMessages
{
    public class DatasToRequestExportation2 : DatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
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
                        ConsultaGTE consulta = new ConsultaGTE(new DataHeaderRequest(cabecalho, dadosBroker), embarque);
                        string xml = new XmlForGTE<ConsultaGTE>().serializeXmlForGTE(consulta);
                        dictonaryForConsulting.Add(embarque.SBELN, xml);
                    }
                }
            }

            return dictonaryForConsulting;
        }
    }
}
