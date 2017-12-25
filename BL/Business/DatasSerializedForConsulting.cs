using System.Collections.Generic;

namespace BL.Business
{
    /// <summary>
    /// Serializa um objeto T em um objeto R e retorna uma lista do objeto serializado
    /// </summary>
    /// <typeparam name="T"> Tipo do objeto que será serializado</typeparam>
    interface DatasSerializedForConsulting<T>
    {
        /// <summary>
        /// Retorna em um IList de string os objetos enviados no parâmetros serializados
        /// </summary>
        /// <param name="listObjectsToSerialization">IList de objetos do tipo T que serão serializados</param>
        /// <returns></returns>
        IList<string> GetDatasSerialized(IList<T> listObjectsToSerialization);
    }
}
