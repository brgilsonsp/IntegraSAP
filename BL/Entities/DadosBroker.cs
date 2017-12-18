using System.Collections.Generic;

namespace BL.Entities
{
    public class DadosBroker
    {
        public int ID { get; set; }
        public string IDBR { get; set; }
        public string IDCL { get; set; }
        public string SHKEY { get; set; }
        public string STRType { get; set; }
        public string XMLVR { get; set; }
        public string ENVRM { get; set; }
        public string INTNR { get; set; }
        public virtual IList<CabecalhoDadosBrokerEntity> Cabecalhos { get; set; }
    }
}
