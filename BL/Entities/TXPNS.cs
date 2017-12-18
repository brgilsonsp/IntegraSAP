namespace BL.Entities
{
    public class TXPNS
    {
        public int ID { get; set; }

        public string KSCHL { get; set; }

        public decimal? NETWR { get; set; }

        public string TypeTXPNS { get; set; }

        public int IDTPCK { get; set; }

        public virtual TPCK TPCK { get; set; }
    }
}
