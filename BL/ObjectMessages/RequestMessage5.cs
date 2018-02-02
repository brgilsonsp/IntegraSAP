using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage5
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestWebservice REQUEST { get; set; }

        public RequestMessage5() { }

        public RequestMessage5(DataHeaderRequest dadosMessage1, Embarque embarque)
        {
            this.EDX = dadosMessage1.Cabecalho.MensagemEDX;
            REQUEST = new RequestWebservice(dadosMessage1, embarque);
        }
    }
}
