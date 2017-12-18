using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class Msg1RetornoListaEmbarque
    {
        [XmlAttribute]
        public string EDX;

        public ResponseMsg1 RESPONSE;
    }

    public class ResponseMsg1
    {
        [XmlAttribute]
        public string Type;

        public Status STATUS;

        [XmlElement("TSHKS")]
        public ListaEmbarque ListaEmbarque;
    }

    public class ListaEmbarque
    {
        [XmlAttribute]
        public string Type;

        [XmlElement("TSHK")]
        public List<Embarque> Embarques;
    }
}