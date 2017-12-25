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

            foreach (Embarque embarque in listEmbarque)
            {
                if (embarque != null && embarque.ConsultaDetalhe == true)
                {
                    DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                    Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == Option.MENSAGEM3).Cabecalho;
                    if (cabecalho.Mensagem == Option.MENSAGEM3)
                    {
                        //ConsultaGTE consulta = new ConsultaGTE(new DataHeaderRequest(cabecalho, dadosBroker), embarque);
                        Msg3RequestExportation consulta = GetObject(embarque, cabecalho, dadosBroker);
                        string xml = new XmlForGTE<Msg3RequestExportation>().serializeXmlForGTE(consulta);
                        dictonaryForConsulting.Add(embarque.SBELN, xml);
                    }
                }
            }

            return dictonaryForConsulting;
        }

        private Msg3RequestExportation GetObject(Embarque embarque, Cabecalho cabecalho, DadosBroker broker)
        {
            Msg3RequestExportation request3 = new Msg3RequestExportation();
            request3.EDX = cabecalho.MensagemEDX;
            request3.REQUEST = new RequesExportationtMsg3();

            return request3;
        }
    }
}
