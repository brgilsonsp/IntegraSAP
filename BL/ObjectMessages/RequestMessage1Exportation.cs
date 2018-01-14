using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage1Exportation
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestWebservice REQUEST { get; set; }

        public RequestMessage1Exportation()
        {

        }
        public RequestMessage1Exportation(DataHeaderRequest dadosMessage1)
        {
            this.EDX = dadosMessage1.Cabecalho.MensagemEDX;
            REQUEST = new RequestWebservice(dadosMessage1);
        }
    }

   }
