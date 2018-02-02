using BL.InnerUtil;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RequestMessage1
    {
        [XmlAttribute]
        public string EDX { get; set; }

        public RequestWebservice REQUEST { get; set; }

        public RequestMessage1()
        {

        }
        public RequestMessage1(DataHeaderRequest dataRequest)
        {
            this.EDX = dataRequest.Cabecalho.MensagemEDX;
            REQUEST = new RequestWebservice(dataRequest);
        }
    }

   }
