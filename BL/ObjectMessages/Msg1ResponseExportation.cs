using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class Msg1ResponseExportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public ResponseMsg1 RESPONSE { get; set; }
    }

    public class ResponseMsg1
    {
        [XmlAttribute]
        public string Type { get; set; }

        public Status STATUS { get; set; }

        [XmlElement("TSHKS")]
        public ListaEmbarque ListaEmbarque { get; set; }
    }

    public class ListaEmbarque
    {
        [XmlAttribute]
        public string Type { get; set; }

        [XmlElement("TSHK")]
        public List<Embarque> Embarques { get; set; }
    }
}