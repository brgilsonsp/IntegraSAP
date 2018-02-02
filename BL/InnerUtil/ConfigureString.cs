using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InnerUtil
{
    public static class ConfigureString
    {
        public static string RemoveAccents(string text)
        {
            byte[] bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
