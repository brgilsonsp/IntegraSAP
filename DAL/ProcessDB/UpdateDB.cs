using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ProcessDB
{
    public interface UpdateDB<T>
    {
        /// <summary>
        /// Atualiza o objeto enviado no parâmetro no banco de dados.
        /// </summary>
        /// <param name="registro">Um objeto do tipo T</param>
        /// <param name="embarque">string</param>
        /// <exception cref="Util.InnerException.UpdateDBException">Lança a exceção se ocorrer algum erro ao atualizar 
        /// o registro no banco de dados</exception>
        int atualizaRegistro(T registro, string embarque);
    }
}
