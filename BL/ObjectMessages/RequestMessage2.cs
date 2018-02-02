using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage2
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestWebservice REQUEST { get; set; }

        public RequestMessage2() { }

        public RequestMessage2(DataHeaderRequest dataRequest, Embarque embarque)
        {
            this.EDX = dataRequest.Cabecalho.MensagemEDX;
            REQUEST = new RequestWebservice(dataRequest, embarque);
        }
    }
}
