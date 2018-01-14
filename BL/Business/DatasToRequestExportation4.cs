using BL.DAO;
using BL.InnerException;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Business
{
    class DatasToRequestExportation4 : IDatasOfRequest
    {
        public IDictionary<string, string> GetDatasToRequest()
        {
            try { 
                IDictionary<string, string> dictonaryForConsulting = new Dictionary<string, string>();
                IList<Embarque> listEmbarque = new EmbarqueDao().FindEnviaPrestacaoContaEnbaleAsNoTracking();

                foreach (Embarque embarque in listEmbarque)
                {
                    if (embarque != null && embarque.EnviaPrestConta == true)
                    {
                        DadosBroker dadosBroker = new DadosBrokerDao().FindByIdAsNoTracking(embarque.DadosBrokerID);
                        Cabecalho cabecalho = dadosBroker.DadosBrokerCabecalho.FirstOrDefault(cab => cab.Cabecalho.Mensagem == Option.MENSAGEM4 && cab.Cabecalho.Tipo == Option.EXPORTACAO).Cabecalho;
                        //ChangeXMLContext.GetInstance().Configuration.ProxyCreationEnabled = false;
                        if (cabecalho.Mensagem == Option.MENSAGEM4 && cabecalho.Tipo == Option.EXPORTACAO)
                        {
                            RequestMessage4Exportation consulta = GetObject(embarque, cabecalho, dadosBroker);
                            string xml = new SerializeXml<RequestMessage4Exportation>().serializeXmlForGTE(consulta);
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

        private RequestMessage4Exportation GetObject(Embarque embarque, Cabecalho cabecalho, DadosBroker broker)
        {
            RequestMsg4 request = new RequestMsg4();
            request.Type = cabecalho.RequestType;
            request.ACAO = cabecalho.ACAO;
            request.IDBR = broker.IDBR;
            request.IDCL = broker.IDCL;
            request.SHKEY = broker.SHKEY;
            request.STR = new STR(broker);

            request.PCK = new TPCKDao().FindByIdEmbarqueAsNoTracking(embarque.ID);

            RequestMessage4Exportation requestMessage4 = new RequestMessage4Exportation();
            requestMessage4.EDX = cabecalho.MensagemEDX;
            requestMessage4.REQUEST = request;

            return requestMessage4;
        }
    }
}
