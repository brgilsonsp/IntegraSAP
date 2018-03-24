using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InnerUtil
{
    public static class ConfigureString
    {
        /// <summary>
        /// Remove os acentos da string informada no parâmetro e a retorna
        /// </summary>
        /// <param name="text">String com acentos que serão removidos</param>
        /// <returns>A string enviada no parâmetro, porém sem a acentuação</returns>
        public static string RemoveAccents(string text)
        {
            byte[] bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
