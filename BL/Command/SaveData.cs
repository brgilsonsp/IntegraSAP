using BL.Business;
using BL.DAO;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Command
{
    interface SaveData<R, E>
    {
        /// <summary>
        /// Sava o response do Web Service no banco de dados.
        /// O Response é passado no parâmetro retornoWebService.
        /// </summary>
        /// <param name="retornoConsultaGTE">R</param>
        /// <returns>A mensagem que será salva no arquivo de log</returns>
        string SaveResponseSuccess(R retornoWebService);

        /// <summary>
        /// Salva o Status que o conteúdo da subtag Status da resposta do Web Service.
        /// Parâmetro status, contém o conteúdo do status que o Web Service respondeu.
        /// </summary>
        /// <param name="status">Objeto com o conteúdo do status da response do Web Service</param>
        /// <returns>A mensagem que será salva no arquivo de log</returns>
        string SaveResponseAlerta(Status status);

        /// <summary>
        /// Salva o response com mensagem de erro que o Web Service respondeu.
        /// Parâmetro xmlResponse, contém o detalhe do erro.
        /// Parâmetro embarque, para gravar no banco de dados o error do seu respectivo Embarque.
        /// </summary>
        /// <param name="xmlResponse">string com o conteúdo do error da response do Web Service</param>
        /// <param name="embarque">O parâmetro xmlResponse pertence a esse embarque</param>
        /// <returns>A mensagem que será salva no arquivo de log</returns>
        string SaveResponseError(string xmlResponse, string embarque);
    }
}
