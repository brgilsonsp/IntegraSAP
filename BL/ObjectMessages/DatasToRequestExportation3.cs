using BL.DAO;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.InnerUtil;
using BL.Business;

namespace BL.ObjectMessages
{
    class DatasToRequestExportation3 : DatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
            IList<Embarque> listEmbarque = new EmbarqueDao().FindAtualizaDetalheEnbaleAsNoTracking();

            foreach (Embarque embarqueEntity in listEmbarque)
            {
                if (embarqueEntity != null && embarqueEntity.ConsultaDetalhe == true)
                {
                    DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarqueEntity.DadosBrokerID);
                    Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == Option.MENSAGEM2).Cabecalho;
                    if (cabecalho.Mensagem == Option.MENSAGEM2)
                    {
                        ConsultaGTE consulta = new ConsultaGTE(new DataHeaderRequest(cabecalho, dadosBroker), embarqueEntity);
                        string xml = new XmlForGTE<ConsultaGTE>().serializeXmlForGTE(consulta);
                        dictonaryForConsulting.Add(embarqueEntity.SBELN, xml);
                    }
                }
            }

            return dictonaryForConsulting;
        }
    }
}
