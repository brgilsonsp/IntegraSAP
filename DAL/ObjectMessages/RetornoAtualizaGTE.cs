using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RetornoAtualizaGTE
    {
        [XmlAttribute]
        public string EDX;

        public ResponseAtualizaGTE RESPONSE;
    }

    public class ResponseAtualizaGTE
    {
        [XmlAttribute]
        public string Type;

        public Status STATUS;
    }
}
