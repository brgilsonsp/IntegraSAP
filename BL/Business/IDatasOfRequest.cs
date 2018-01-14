using System.Collections.Generic;

namespace BL.Business
{
    public interface IDatasOfRequest
    {
        /// <summary>
        /// Obtem em xml, os dados necessário para processar a mensagem
        /// Retorna um IDictionary com a chave sendo um identificador, sendo o IdDadosBroker para a 
        /// primeira mensagem e para as demais mensagens o SBELN, e o valor é o XML para a requisição
        /// </summary>
        /// <returns>Um dicionario com um identificador, sendo o IdBroker ou o SBELN, e o valor é o conteúdo serializado em XML</returns>
        /// <exception cref="ChangeXmlException">Lança a exceção do tipo ChangeXmlException com uma mensagem e internamente as exeções que ocorreram</exception>
        IDictionary<string, string> GetDatasToRequest();
    }
}
