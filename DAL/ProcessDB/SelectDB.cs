using DAL.ObjectMessages;

namespace DAL.ProcessDB
{
    /// <summary>
    /// Realiza a opção de Consulta e Atualização de registros no banco de dados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface SelectDB<T>
    {
        /// <summary>
        /// Efetua a consulta de um registro no banco de dados filtrando os registros
        /// com o valor enviado no parâmetro.
        /// </summary>
        /// <param name="embarque">Embarque</param>
        /// <returns>Retorna o registro consultado em um objeto do tipo T. Se o registro não for localizado retorna nulo</returns>
        /// <exception cref="BL.Excecao.ConsultDBException">Lança a exceção se ocorreu algum erro ao efetuar a consulta no banco de dados</exception>
        T consultaRegistro(Embarque embarque);
    }
}
