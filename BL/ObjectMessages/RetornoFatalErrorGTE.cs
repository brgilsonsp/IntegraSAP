using System;
using System.Xml.Serialization;

namespace BL.ObjectMessages
{
    [XmlRoot(ElementName = "EDX")]
    public class RetornoFatalErrorGTE
    {
        [XmlAttribute]
        public string versao;

        public ResponseError RESPONSE;

        [XmlElement(IsNullable = false)]
        public DateTime DataRetorno;

        [XmlElement(IsNullable = false)]
        public byte Mensagem;

        [XmlElement(IsNullable = false)]
        public Status Status { get { return GetStatus(); } }

        private Status GetStatus()
        {
            Status status = new Status();
            status.CODE = this.RESPONSE.CODE;
            status.DESC = this.RESPONSE.DESC;
            status.DataRetorno = this.DataRetorno;
            status.Mensagem = this.Mensagem;

            return status;
        }
    }

    public class ResponseError
    {
        public string CODE;

        public string DESC;
    }

}
