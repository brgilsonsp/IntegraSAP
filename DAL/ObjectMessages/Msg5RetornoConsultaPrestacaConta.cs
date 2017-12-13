using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    [XmlRoot("EDX")]
    public class Msg5RetornoConsultaPrestacaConta
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseMsg5 RESPONSE;

    }

    public class ResponseMsg5
    {
        [XmlAttribute]
        public string Type { get; set; }

        public Status STATUS;

        [XmlElement(ElementName = "TPCK")]
        public List<PrestacaoContas> PCK;
    }
}
