using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Business
{
    public interface IDatasOfRequestMessage4
    {
        /// <summary>
        /// Obtem em xml, os dados necessário para processar a mensagem 4
        /// Retorna um IDictionary com a chave sendo o identificador, o SBELN, e o valor é um list de XML para a requisição
        /// </summary>
        /// <returns>Um dicionario com um identificador, o SBELN, e o valor é um list com o conteúdo para a requisição serializado em XML</returns>
        /// <exception cref="ChangeXmlException">Lança a exceção do tipo ChangeXmlException com uma mensagem e internamente as exeções que ocorreram</exception>
        IDictionary<string, List<string>> GetDatasToRequest();
    }
}
