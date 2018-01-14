using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage5Exportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestWebservice REQUEST { get; set; }

        public RequestMessage5Exportation() { }

        public RequestMessage5Exportation(DataHeaderRequest dadosMessage1, Embarque embarque)
        {
            this.EDX = dadosMessage1.Cabecalho.MensagemEDX;
            REQUEST = new RequestWebservice(dadosMessage1, embarque);
        }
    }
}
