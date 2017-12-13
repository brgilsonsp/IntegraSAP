using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DAL.ObjectMessages
{
    public class Status
    {
        [XmlAttribute]
        public string Type;

        public string CODE;

        public string DESC;

        [XmlElement(IsNullable = false)]
        public DateTime DataRetorno { get; set; }

        [XmlElement(IsNullable = false)]
        public byte Mensagem { get; set; }

        [XmlElement("ERRORS")]
        public List<DescErrors> ERRORS;
    }

    public class DescErrors
    {
        [XmlAttribute]
        public string Type;

        public string CODE;

        public string DESC;
    }
}
