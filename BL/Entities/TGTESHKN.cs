using System;

namespace BL.Entities
{
    public class TGTESHKN
    {
        public int ID { get; set; }

        public string LOCSE { get; set; }

        public string TIPSE { get; set; }

        public string TSETMP { get; set; }

        public DateTime? SEDAT { get; set; }

        public DateTime? ETADT { get; set; }

        public DateTime? ENVDT { get; set; }

        public DateTime? PREVDT { get; set; }

        public string TRANS { get; set; }

        public string ZOLLAO { get; set; }

        public string ZLANDO { get; set; }

        public string ZOLLAD { get; set; }

        public string ZLANDD { get; set; }

        public decimal? NETWR { get; set; }

        public string WAERSRF { get; set; }

        public string INCO1 { get; set; }

        public string ZTERM { get; set; }

        public string SESTAT { get; set; }

        public string WAERS { get; set; }

        public string BFMAR { get; set; }

        public string SHPTRIP { get; set; }

        public DateTime? ETDDT { get; set; }

        public string BLNMB { get; set; }

        public DateTime? BLDTA { get; set; }

        public string HSAWB { get; set; }

        public string SHPNAM { get; set; }

        public string INVNR { get; set; }

        public DateTime? DT_INVNR { get; set; }

        public decimal? VOLUM { get; set; }

        public decimal? NTGEW { get; set; }

        public decimal? BRGEW { get; set; }

        public decimal? VLFRETE { get; set; }

        public string MOEDAFRT { get; set; }

        public decimal? VLSEGURO { get; set; }

        public string MOEDASGR { get; set; }

        public decimal? VLCOAGT { get; set; }

        public string MOEDACOAGT { get; set; }

        public decimal? PCCOAGT { get; set; }

        public string TPCOAGT { get; set; }

        public DateTime? DTCLTC { get; set; }

        public DateTime? DTEARM { get; set; }

        public DateTime? DTENTC { get; set; }

        public string URFDESP { get; set; }

        public string URFEMBA { get; set; }

        public string MODPAG { get; set; }

        public string BASCOM { get; set; }

        public string PRECLCT { get; set; }

        public DateTime? DTCOLETA { get; set; }

        public DateTime? DTCHGARM { get; set; }

        public DateTime? DTPRESC { get; set; }

        public DateTime? DTAVERB { get; set; }

        public DateTime? DTENTREGA { get; set; }

        public string BROKNM { get; set; }

        public string NMBOOK { get; set; }

        public DateTime? DTBOOK { get; set; }

        public string TPVEIC { get; set; }

        public string TPCARG { get; set; }

        public string UFEMBARQ { get; set; }

        public string INSTNEG { get; set; }

        public string TPPRP { get; set; }

        public DateTime? DTSHIP { get; set; }

        public string NROCE { get; set; }

        public DateTime? DTCE { get; set; }

        public string TypeTGTESHKN { get; set; }

        public int IDEmbarque { get; set; }

        public virtual EmbarqueEntity Embarque { get; set; }
    }
}
