using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Business
{
    /// <summary>
    /// Define as propriedades necessárias para salvar ou validar o processo de salvar um conteúdo XML em arquivo texto no disco
    /// </summary>
    public interface OriginalText
    {
        /// <summary>
        /// Retorna de qual Mensagem que o conteúdo de texto se refere
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Conteúdo de texto que será salvo em arquivo
        /// </summary>
        string ContentText { get; }

        /// <summary>
        /// Retorna o caminho relativo a essa Mensagem mais o nome do arquivo que o conteúdo da propriedade ContentText será salva
        /// </summary>
        string PathSaveFileText { get; }

        /// <summary>
        /// Retorna se as condições necessárias para salver o arquivo de texto em disco foram satisfeitas
        /// </summary>
        bool IsConditionsAcceptableForSaveText();
    }
}
