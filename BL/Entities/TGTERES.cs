using System;

namespace BL.Entities
{
    public class TGTERES
    {
        public int ID { get; set; }

        public string DSENUM { get; set; }

        public string RENUM { get; set; }

        public DateTime? ANDAT { get; set; }

        public DateTime? REDAT { get; set; }

        public DateTime? AVBDT { get; set; }

        public string CANAL { get; set; }

        public string DDENUM { get; set; }

        public DateTime? DDEDT { get; set; }

        public string DDESQ { get; set; }

        public string REANX { get; set; }

        public int? DSESQ { get; set; }

        public string DOCFAT { get; set; }

        public string XBLNR { get; set; }

        public string INCO1 { get; set; }

        public string WAERS { get; set; }

        public DateTime? DDEADT { get; set; }

        public string TypeTGTERES { get; set; }

        public int IDEmbarque { get; set; }

        public virtual EmbarqueEntity Embarque { get; set; }
    }
}
