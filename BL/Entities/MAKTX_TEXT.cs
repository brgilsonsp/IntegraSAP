namespace BL.Entities
{
    public class MAKTX_TEXT
    {
        public int ID { get; set; }

        public string TEXT { get; set; }

        public string TypeMaktx { get; set; }

        public int IdTGTESHPN { get; set; }

        public virtual TGTESHPN TGTESHPN { get; set; }
    }
}
