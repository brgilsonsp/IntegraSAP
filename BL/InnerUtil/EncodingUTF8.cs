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
        public EncodingUTF8(StringBuilder stringBuilder) : base(stringBuilder) { }
        public override Encoding Encoding => Encoding.UTF8;
    }
}
