using System.Collections.Generic;

namespace DAL.Entities
{
    public class TGTESHPN
    {
        public int ID { get; set; }

        public string TypeTGTESHPN { get; set; }

        public int? SBELP { get; set; }

        public int? NBELP { get; set; }

        public string DOCFAT { get; set; }

        public decimal? ITMFAT { get; set; }

        public string MATNR { get; set; }

        public string MAKTX { get; set; }

        public decimal? QTDITM { get; set; }

        public decimal? NETPR { get; set; }

        public decimal? KPEIN { get; set; }

        public string MEINS { get; set; }

        public decimal? NETWR { get; set; }

        public decimal? FRTLOC { get; set; }

        public decimal? FRTINT { get; set; }

        public decimal? SEGINT { get; set; }

        public decimal? PRCFOB { get; set; }

        public decimal? PRCEXW { get; set; }

        public decimal? PCTCOM { get; set; }

        public decimal? VLRCOM { get; set; }

        public string RENUM { get; set; }

        public int? ITMRE { get; set; }

        public string ENQDM { get; set; }

        public decimal? BRGEW { get; set; }

        public decimal? NTGEW { get; set; }

        public string GEWEI { get; set; }

        public decimal? VOLUM { get; set; }

        public string VOLEH { get; set; }

        public string STEUC { get; set; }

        public string NALADISH { get; set; }

        public string FABITM { get; set; }

        public string ATOCON { get; set; }

        public string AMCCPTC { get; set; }

        public string BRCCPTC { get; set; }

        public string CCROM { get; set; }

        public string FABRILUF { get; set; }

        public decimal? NETPRORI { get; set; }

        public decimal? KPEINORI { get; set; }

        public string MEINSORI { get; set; }

        public decimal? NETWRORI { get; set; }

        public string PROD { get; set; }

        public string FKDAT { get; set; }

        public int IdMAKTX_TEXT { get; set; }
        public virtual IList<MAKTX_TEXT> MAKTX_TEXT { get; set; }
    }
}
