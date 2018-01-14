namespace BL.Business
{
    /// <summary>
    /// Define as propriedades necessárias para salvar ou validar o processo de salvar um conteúdo XML em arquivo texto no disco
    /// </summary>
    public interface IOriginalText
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
        /// Retorna o nome completo do arquivo
        /// </summary>
        string PathFileSaveFileText { get; }

        /// <summary>
        /// Diretório aonde será salvo o XMl
        /// </summary>
        string DirectoryFileSaveFileText { get; }

        /// <summary>
        /// Retorna se as condições necessárias para salver o arquivo de texto em disco forem satisfatórias
        /// </summary>
        bool IsConditionsAcceptableForSaveText { get; }
    }
}
