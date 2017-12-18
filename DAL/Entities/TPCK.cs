using System;

namespace DAL.Entities
{
    public class TPCK
    {
        public int ID { get; set; }

        public string DOCNR { get; set; }

        public string PCTYP { get; set; }

        public string PARID { get; set; }

        public DateTime? BLDAT { get; set; }

        public string XBLNR { get; set; }

        public string ZUONR { get; set; }

        public string BKTXT { get; set; }

        public string SGTXT { get; set; }

        public DateTime? ZFBDT { get; set; }

        public DateTime? ABLFD { get; set; }

        public string STATU { get; set; }

        public string TypePCK { get; set; }

        public int IDEmbarque { get; set; }

        public virtual EmbarqueEntity Embarque { get; set; }
    }
}
