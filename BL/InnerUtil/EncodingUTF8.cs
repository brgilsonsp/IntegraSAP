using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InnerUtil
{
    public class EncodingUTF8 : StringWriter
    {
        /// <summary>
        /// Cria um objeto do tipo StringBuilder que terá o seu encoding alterado
        /// </summary>
        /// <param name="stringBuilder">Um objeto do tipo StringBuilder</param>
        public EncodingUTF8(StringBuilder stringBuilder) : base(stringBuilder) { }

        /// <summary>
        /// Altera o Encodingo do objeto do tipo StringBuilder para UTF8
        /// </summary>
        public override Encoding Encoding => Encoding.UTF8;
    }
}
