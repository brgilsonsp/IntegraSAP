namespace BL.Command
{
    /// <summary>
    /// Define as classes para efetuar a troca de Mensagem com o Webservice
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Executa o processo da troca de mensagem com o Webservice
        /// </summary>
        /// <returns>Uma mensagem com o log do processo executado</returns>
        string Execute();

    }
}
