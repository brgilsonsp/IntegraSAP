using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage3Importation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequesImportationtMsg3 REQUEST { get; set; }
    }

    public class RequesImportationtMsg3
    {
        [XmlAttribute]
        public string Type { get; set; }

        public string ACAO { get; set; }

        public string IDBR { get; set; }

        public string IDCL { get; set; }

        public string SHKEY { get; set; }

        public STR STR { get; set; }

        [XmlElement("MAIN")]
        public MAIN MAIN { get; set; }

        [XmlElement("BUK")]
        public List<BUK> BUK { get; set; }

        [XmlElement("PAR")]
        public List<PAR> PAR { get; set; }

        [XmlElement("PARS")]
        public List<PARS> PARS { get; set; }

        [XmlElement("DAT")]
        public List<DAT> DAT { get; set; }

        [XmlElement("DI")]
        public List<DI> DI { get; set; }

        [XmlElement("BL")]
        public List<BLImportation> BL { get; set; }

        [XmlElement("SHP")]
        public List<SHP> SHP { get; set; }

        [XmlElement("SHP_TEXT")]
        public List<SHP_TEXT_Main> SHP_TEXT_Main { get; set; }
    }
}
