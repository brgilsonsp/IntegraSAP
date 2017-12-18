using BL.ObjectMessages;
using System.Collections.Generic;

namespace BL.Business
{
    /// <summary>
    /// Serializa um objeto T em um objeto R e retorna uma lista do objeto serializado
    /// </summary>
    /// <typeparam name="T"> Objeto que será serializado</typeparam>
    /// <typeparam name="R">Tipo que o objeto T será serializado</typeparam>
    interface DatasSerializedForConsulting<T, R>
    {
        IList<R> GetDatasSerialized(DatasOfRequest<T> t);
    }
}
