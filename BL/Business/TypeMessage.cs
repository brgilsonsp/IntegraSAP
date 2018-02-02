namespace BL.Business
{
    interface TypeMessage
    {
        /// <summary>
        /// Define o compartamento da troca de Mensagem com o WebService e o armazenamento 
        /// da resposta no banco de dados e em arquivo XML.
        /// O método retornará uma string com as informações do processo da troca
        /// da Mensagem que poderá ser utilizado como log de auditoria.
        /// </summary>
        /// <returns>string com a mensagem do status da troca da Mensagem</returns>
        string ProcessMessage();
    }
}
