using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage2Exportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestWebservice REQUEST { get; set; }

        public RequestMessage2Exportation() { }

        public RequestMessage2Exportation(DataHeaderRequest dadosMessage1, Embarque embarque)
        {
            this.EDX = dadosMessage1.Cabecalho.MensagemEDX;
            REQUEST = new RequestWebservice(dadosMessage1, embarque);
        }
    }
}
