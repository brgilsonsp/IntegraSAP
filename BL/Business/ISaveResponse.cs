namespace BL.Business
{
    /// <summary>
    /// Save no banco de dados o retorno do WebService
    /// </summary>
    public interface ISaveResponse
    {
        /// <summary>
        /// Verifica se o objeto possui os dados necessários para executar o processo de salvar a resposta no banco de dados
        /// </summary>
        bool IsDatasComplete { get; }

        /// <summary>
        /// Save o retorno no WebService e devolve uma string com o conteúdo que será gravado no log de auditoria
        /// </summary>
        /// <returns>Conteúdo para o log de auditoria</returns>
        string SaveDataBase(string identifier, string message, string kindOfMessage);

        /// <summary>
        /// Altera a flag de solicitação da requisição da Mensagem
        /// </summary>
        /// <param name="sbeln"></param>
        /// <param name="kindOfMessage"></param>
        void AlterFlagChangeMessage(string sbeln, string kindOfMessage);
    }
}
