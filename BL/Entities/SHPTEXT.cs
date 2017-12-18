namespace BL.Entities
{
    public class SHPTEXT
    {
        public int ID { get; set; }

        public string TDID { get; set; }

        public string TDLINE { get; set; }

        public string TypeSHPTEX { get; set; }

        public int IDEmbarque { get; set; }

        public virtual EmbarqueEntity Embarque { get; set; }
    }
}
