﻿using DAL.ObjectMessages;

namespace BL.Command
{
    /// <summary>
    /// Define as classes para efetuar a troca de Mensagem com o GTE
    /// </summary>
    interface Mensagem
    {
        /// <summary>
        /// Define o compartamento da troca de Mensagem com o GTE e o armazenamento 
        /// da resposta no banco de dados.
        /// O método retornará uma string com as informações do processo da troca
        /// da Mensagem que poderá ser utilizado como log de auditoria.
        /// </summary>
        /// <returns>string com o status da troca da Mensagem</returns>
        /// <exception cref="Util.InnerException.BaseInnerException">Repassa todas as exceções do tipo InnerException</exception>
        string SwapXmlWithGTE();
    }
}
