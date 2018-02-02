using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public interface IContextChangeXml<T>
    {
        /// <summary>
        /// Sava as atualizações do objeto no banco de dados
        /// </summary>
        void Update();

        /// <summary>
        /// Salva o objeto enviado no parâmetro item no banco de dados
        /// </summary>
        /// <param name="item">Objeto que será persistido no banco de dados</param>
        void Save(T item);

        /// <summary>
        /// Salva no banco de dados todos os objetos enviado no lista
        /// </summary>
        /// <param name="itens">Lista de objetos que sera persistido no banco de dados</param>
        void SaveAll(IList<T> itens);

        /// <summary>
        /// Excluido do banco de dados o objeto enviado no paràmetro item
        /// </summary>
        /// <param name="item">Objeto que será excluido do banco de dados</param>
        void Delete(T item);

        /// <summary>
        /// Exclui do banco de dados a lista de objetos enviado no parâmetro
        /// </summary>
        /// <param name="itens">Lista de objetos que serão excluidos do banco de dados</param>
        void DeleteAll(IList<T> itens);

        /// <summary>
        /// Obtem do banco de dados uma lista de objetos que se relacionam com a tabela Embarque, informado no parâmetro.
        /// </summary>
        /// <param name="idEmbarque">ID do Embarque que se relacionam com a entidade desejada</param>
        /// <returns>Uma lista de objetos, sem as entidades relacionadas no banco de dados</returns>
        IList<T> FindByIdEmbarqueEager(int idEmbarque);

        /// <summary>
        /// Obtem do banco de dados uma lista de objetos que se relacionam com a tabela Embarque, informado no parâmetro.
        /// </summary>
        /// <param name="idEmbarque">ID do Embarque que se relacionam com a entidade desejada</param>
        /// <returns>Uma lista de objetos, com todas as entidades relacionadas no banco de dados</returns>
        IList<T> FindByIdEmbarqueLazy(int idEmbarque);

        /// <summary>
        /// Obtem do banco de dados um  objeto que possui o id informado no parâmetro.
        /// </summary>
        /// <param name="idEmbarque">ID da entidade no banco de dados</param>
        /// <returns>Um objeto, sem as entidades relacionadas no banco de dados</returns>
        T FindByIdEager(int idItem);

        /// <summary>
        /// Obtem do banco de dados um  objeto que possui o id informado no parâmetro.
        /// </summary>
        /// <param name="idEmbarque">ID da entidade no banco de dados</param>
        /// <returns>Um objeto, com todas as entidades relacionadas no banco de dados</returns>
        T FindByIdLazy(int idItem);

        /// <summary>
        /// Obtem do banco de dados uma lista da entidade.
        /// </summary>
        /// <returns>Uma lista de objetos, sem as entidades relacionadas no banco de dados</returns>
        IList<T> FindAllEager();

        /// <summary>
        /// Obtem do banco de dados uma lista da entidade.
        /// </summary>
        /// <returns>Uma lista de objetos, com todas as entidades relacionadas no banco de dados</returns>
        IList<T> FindAllLazy();

    }
}
