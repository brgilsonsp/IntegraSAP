using System;
using System.Xml.Serialization;
using BL.InnerUtil;

namespace BL.ObjectMessages
{
    public class Embarque
    {
        [XmlAttribute]
        public string Type;

        public string SBELN;

        public string STCOD;

        public string DESCR;

        public string LASTUP;

        [XmlElement(IsNullable = false)]
        public DateTime? LASTUP_Date
        {
            get
            {
                return ConfigureDate.convertDateStringForDateTime(LASTUP);
            }
        }

        public string LASTHR;

        public string BFMAR;

        public int IDEmbarque;

        [XmlIgnore]
        public int IDDadosBroker;
    }
}
