using BL.ObjectMessages;
using System.Collections.Generic;

namespace BL.ObjectMessages
{
    public interface DatasOfRequest
    {
        /// <summary>
        /// Obtem em xml, os dados necessário para processar a mensagem
        /// Retorna um IDictionary com a chave sendo um identificador, sendo o IdDadosBroker para a 
        /// primeira mensagem e para as demais mensagens o SBELN, e o valor é o XML para a requisição
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> GetDatasToRequest();
    }
}
