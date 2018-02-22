using BL.DAO;
using BL.InnerException;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Business
{
    public class DatasToRequest4 : IDatasOfRequestMessage4
    {
        private string _kindOfMessage;
        private byte _numberOfMessage;

        public DatasToRequest4(string kindOfMessage)
        {
            _kindOfMessage = kindOfMessage;
            _numberOfMessage = (byte)NumberOfMessage.Four;
        }
                
        public IDictionary<string, List<string>> GetDatasToRequest()
        {
            try { 
                IDictionary<string, List<string>> dictonaryForConsulting = new Dictionary<string, List<string>>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindEnviaPrestacaoContaEnbaleAsNoTracking(_kindOfMessage);

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.EnviaPrestConta == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == _numberOfMessage && cab.Cabecalho.Tipo == _kindOfMessage).Cabecalho;
                        if (cabecalho.Mensagem == _numberOfMessage && cabecalho.Tipo == _kindOfMessage)
                        {
                            List<RequestMessage4> listMessage4 = GetObject(embarque, cabecalho, dadosBroker);
                            List<string> xml = new List<string>();
                            foreach (RequestMessage4 consulta in listMessage4)
                            {
                                string eachXml = new SerializeXml<RequestMessage4>().serializeXmlForGTE(consulta);
                                xml.Add(eachXml);
                            }
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

        private List<RequestMessage4> GetObject(Embarque embarque, Cabecalho cabecalho, DadosBroker broker)
        {
            List<RequestMessage4> listRequestMessage4 = new List<RequestMessage4>();
            List<TPCK> listTpck = new TPCKDao().FindByIdEmbarqueEager(embarque.ID).ToList();
            foreach (TPCK eachTpck in listTpck)
            {

                RequestMsg4 request = new RequestMsg4();
                request.Type = cabecalho.RequestType;
                request.ACAO = cabecalho.ACAO;
                request.IDBR = broker.IDBR;
                request.IDCL = broker.IDCL;
                request.SHKEY = broker.SHKEY;
                request.STR = new STR(broker);
                request.PCK = eachTpck;
                request.PCK.SBELN = embarque.SBELN;
                //Esse campo necessita do valor "S" para o request da Mensagem 4, porém no response da Mensagem 5 esse mesmo campo é
                //recebido com o valor "L", sendo assim o valor que o Webservice é salvo no banco de dados e nessa requisição é alterado
                //esse valor aqui manualmente
                request.PCK.Type = "S";

                RequestMessage4 requestMessage4 = new RequestMessage4();
                requestMessage4.EDX = cabecalho.MensagemEDX;
                requestMessage4.REQUEST = request;

                listRequestMessage4.Add(requestMessage4);
            }
            return listRequestMessage4;
        }
    }
}
