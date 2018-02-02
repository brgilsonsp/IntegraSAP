using BL.DAO;
using BL.InnerException;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Business
{
    public class DatasToRequestImportation3 : IDatasOfRequest
    {
        private byte numberOfMessage = (byte)NumberOfMessage.Three;
        private string kindOfMessage = Option.IMPORTACAO;
        public IDictionary<string, string> GetDatasToRequest()
        {
            try
            {
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindAtualizaDetalheEnbaleAsNoTracking(kindOfMessage);

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.AtualizaDetalhe == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == numberOfMessage && cab.Cabecalho.Tipo == kindOfMessage).Cabecalho;
                        if (cabecalho.Mensagem == numberOfMessage && cabecalho.Tipo == kindOfMessage)
                        {
                            RequestMessage3Importation consulta = GetObject(embarque, cabecalho, dadosBroker);
                            string xml = new SerializeXml<RequestMessage3Importation>().serializeXmlForGTE(consulta);
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

        private RequestMessage3Importation GetObject(Embarque embarque, Cabecalho cabecalho, DadosBroker dadosBroker)
        {
            MAIN main = new MainDAO().FindByIdEmbarqueEager(embarque.ID).FirstOrDefault();

            RequesImportationtMsg3 request = new RequesImportationtMsg3();
            request.Type = cabecalho.RequestType;
            request.ACAO = cabecalho.ACAO;
            request.IDBR = dadosBroker.IDBR;
            request.IDCL = dadosBroker.IDCL;
            request.SHKEY = dadosBroker.SHKEY;
            request.STR = new STR(dadosBroker);
            request.MAIN = main;
            request.BUK = main.BUK;
            request.PAR = main.PAR;
            request.PARS = main.PARS;
            request.DAT = main.DAT;
            request.DI = main.DI;
            request.BL = main.BL;
            request.SHP = main.SHP;
            request.SHP_TEXT_Main = main.SHP_TEXT_Main;

            RequestMessage3Importation requestMessage3 = new RequestMessage3Importation();
            requestMessage3.EDX = cabecalho.MensagemEDX;
            requestMessage3.REQUEST = request;

            return requestMessage3;
        }
    }
}
