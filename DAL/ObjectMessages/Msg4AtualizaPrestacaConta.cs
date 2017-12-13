using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class Msg4AtualizaPrestacaoConta
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestMsg4 REQUEST;
    }

    public class RequestMsg4
    {
        [XmlAttribute]
        public string Type;

        public string ACAO;

        public string IDBR;

        public string IDCL;

        public string SHKEY;

        public STR STR;

        [XmlElement("PCK")]
        public List<PrestacaoContas> PCK;
    }
}
