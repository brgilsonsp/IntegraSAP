namespace DAL.Entities
{
    public class TGTEPRD
    {
        public int ID { get; set; }

        public string PARVW { get; set; }

        public string PARID { get; set; }

        public string NAME1 { get; set; }

        public string NAME2 { get; set; }

        public string STREET { get; set; }

        public string HOUSE_NUM1 { get; set; }

        public string HOUSE_NUM2 { get; set; }

        public string POST_CODE1 { get; set; }

        public string CITY1 { get; set; }

        public string CITY2 { get; set; }

        public string PSTLZ { get; set; }

        public string REGION { get; set; }

        public string COUNTRY { get; set; }

        public string STCD1 { get; set; }

        public string STCD3 { get; set; }

        public string STCD4 { get; set; }

        public string TypeTGTEPRD { get; set; }

        public int IDEmbarque { get; set; }

        public virtual EmbarqueEntity Embarque { get; set; }
    }
}
