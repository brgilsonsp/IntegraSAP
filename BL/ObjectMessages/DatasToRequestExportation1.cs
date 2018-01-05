using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ObjectMessages;
using BL.DAO;
using BL.Business;
using BL.InnerUtil;

namespace BL.ObjectMessages
{
    class DatasToRequestExportation1 : DatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
            IList <DadosBroker> dadosBroker = new DadosBrokerDao().FindAllAsNoTracking();

            foreach(DadosBroker cadaDadosBroker in dadosBroker)
            {
                foreach (CabecalhoDadosBroker cabecalho in cadaDadosBroker.DadosBrokerCabecalho)
                {
                    if (cabecalho.Cabecalho.Mensagem == Option.MENSAGEM1 && cabecalho.Cabecalho.Tipo == Option.EXPORTACAO)
                    {
                        ConsultaGTE consulta = new ConsultaGTE(new DataHeaderRequest(cabecalho.Cabecalho, cadaDadosBroker));
                        string xml = new XmlForGTE<ConsultaGTE>().serializeXmlForGTE(consulta);
                        dictonaryForConsulting.Add(cadaDadosBroker.ID.ToString(), xml);
                    }
                }                

            }

            return dictonaryForConsulting;
        }
    }
}
