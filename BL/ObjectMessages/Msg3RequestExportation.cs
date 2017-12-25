using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class Msg3RequestExportation
    {
        [XmlAttribute]
        public string EDX;

        public RequesExportationtMsg3 REQUEST;
    }

    public class RequesExportationtMsg3
    {
        [XmlAttribute]
        public string Type;

        public string ACAO;

        public string IDBR;

        public string IDCL;

        public string SHKEY;

        public STR STR;

        public TGTESHK_N TGTESHK_N;

        [XmlElement("TGTESHP_N")]
        public List<TGTESHP_N> TGTESHP_N;

        [XmlElement("TGTERES")]
        public List<TGTERES> TGTERES;

        [XmlElement("TGTEPRD")]
        public List<TGTEPRD> TGTEPRD;

        [XmlElement("SHP_TEXT")]
        public List<SHP_TEXT> SHP_TEXT;

        [XmlElement("TGTEDUEK")]
        public List<TGTEDUEK> TGTEDUEK;

        [XmlElement("TGTEDUEP")]
        public List<TGTEDUEP> TGTEDUEP;
    }
}
