using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class Msg3AtualizaDetalheEmbarque
    {
        [XmlAttribute]
        public string EDX;

        public RequestMsg3 REQUEST;
    }

    public class RequestMsg3
    {
        [XmlAttribute]
        public string Type;

        public string ACAO;

        public string IDBR;

        public string IDCL;

        public string SHKEY;

        public STR STR;

        public TGTESHKN TGTESHK_N;

        [XmlElement("TGTESHP_N")]
        public List<TGTESHPN> TGTESHP_N;

        [XmlElement("TGTERES")]
        public List<TGTERES> TGTERES;

        [XmlElement("TGTEPRD")]
        public List<TGTEPRD> TGTEPRD;

        [XmlElement("SHP_TEXT")]
        public List<SHPTEXT> SHP_TEXT;
    }
}
