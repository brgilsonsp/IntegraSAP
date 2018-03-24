using BL.ObjectMessages;
using System.Configuration;
using System.Data.Entity;

namespace BL.DAO
{
    public class ChangeXMLContext : DbContext
    {

        #region Entidades Mapeadas
        public DbSet<Cabecalho> Cabecalhos { get; set; }

        public DbSet<CabecalhoDadosBroker> CabecalhosDadosBrokers { get; set; }

        public DbSet<DadosBroker> DadosBrokers { get; set; }

        public DbSet<DetalheError> DetalhesErrors { get; set; }

        public DbSet<Embarque> Embarques { get; set; }

        public DbSet<MAKTX_TEXT> MAKTX_TEXTs { get; set; }

        public DbSet<SHP_TEXT> SHPTEXTs { get; set; }

        public DbSet<Status> StatusRetornos { get; set; }

        public DbSet<TGTEPRD> TGTEPRDs { get; set; }

        public DbSet<TGTERES> TGTERESs { get; set; }

        public DbSet<TGTESHK_N> TGTESHK_Ns { get; set; }

        public DbSet<TGTESHP_N> TGTESHP_Ns { get; set; }

        public DbSet<TPCK> TPCKs { get; set; }

        public DbSet<TXPNS> TXPNSs { get; set; }

        public DbSet<TGTEDUEK> TGTEDUEKs { get; set; }

        public DbSet<ADDINFO_TAB_TGTEDUEK> ADDINFO_TAB_TGTEDUEKs { get; set; }

        public DbSet<ADDRESS_TAB_TGTEDUEK> ADDRESS_TAB_TGTEDUEKs { get; set; }

        public DbSet<TGTEDUEP> TGTEDUEPs { get; set; }

        public DbSet<ADDINFO_TAB_TGTEDUEP> ADDINFO_TAB_TGTEDUEPs { get; set; }

        public DbSet<NFEREF_TAB_TGTEDUEP> NFEREF_TAB_TGTEDUEPs { get; set; }

        public DbSet<DUEATRIB_TAB_TGTEDUEP> DUEATRIB_TAB_TGTEDUEPs { get; set; }

        public DbSet<ATOCON_TAB_TGTEDUEP> ATOCON_TAB_TGTEDUEPs { get; set; }

        public DbSet<MAIN> MAINs { get; set; }

        public DbSet<BUK> BUKs { get; set; }

        public DbSet<PAR> PARs { get; set; }

        public DbSet<PARS> PARSs { get; set; }

        public DbSet<DAT> DATs { get; set; }

        public DbSet<DI> DIs { get; set; }

        public DbSet<BLImportation> BLImportations { get; set; }

        public DbSet<SHP> SHPs { get; set; }

        public DbSet<SHP_TEXT_Main> SHP_TEXT_Mains { get; set; }

        public DbSet<XPNS> XPNSs { get; set; }

        public DbSet<KURDIS> KURDISs { get; set; }

        public DbSet<MAKTX_TEXT_SHP> MAKTX_TEXT_SHPs { get; set; }

        public DbSet<NFSK> NFSKs { get; set; }

        public DbSet<TTAX> TTAXs { get; set; }

        public DbSet<INVP> INVPs { get; set; }

        public DbSet<CHARGS> CHARGSs { get; set; }

        public DbSet<SERNR> SERNRs { get; set; }

        public DbSet<II> IIs { get; set; }

        public DbSet<IP> IPs { get; set; }

        public DbSet<PS> PSs { get; set; }

        public DbSet<CF> CFs { get; set; }

        public DbSet<IC> ICs { get; set; }

        public DbSet<ST> STs { get; set; }
        

        #endregion

        #region Factory instance

        /// <summary>
        /// Obtém uma instância de ChangeXMLContext
        /// </summary>
        /// <returns>Uma instância de ChangeXMLContext</returns>
        public static ChangeXMLContext GetInstance()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["BrokerMessageConnectionString"].ConnectionString;

            if(_context == null)
                _context = new ChangeXMLContext(stringConnection);

            _context.Configuration.LazyLoadingEnabled = false;
            _context.Configuration.ProxyCreationEnabled = false;
            return _context;
        }

        private static ChangeXMLContext _context;

        private ChangeXMLContext(string nameConnectionString):base(nameConnectionString) { }

        /// <summary>
        /// Recarrega o contexto, forçando uma nova instancia do banco de dados
        /// </summary>
        public static void ReloadContext()
        {
            _context = null;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabecalho>().ToTable("Cabecalho");
            modelBuilder.Entity<CabecalhoDadosBroker>().ToTable("CabecalhoDadosBroker");
            modelBuilder.Entity<DadosBroker>().ToTable("DadosBroker");
            modelBuilder.Entity<DetalheError>().ToTable("DetalheError");
            modelBuilder.Entity<ObjectMessages.Embarque>().ToTable("Embarque");
            modelBuilder.Entity<MAKTX_TEXT>().ToTable("MAKTX_TEXT");
            modelBuilder.Entity<SHP_TEXT>().ToTable("SHPTEXT");
            modelBuilder.Entity<Status>().ToTable("StatusRetorno");
            modelBuilder.Entity<TGTEPRD>().ToTable("TGTEPRD");
            modelBuilder.Entity<TGTERES>().ToTable("TGTERES");
            modelBuilder.Entity<TGTESHK_N>().ToTable("TGTESHKN");
            modelBuilder.Entity<TGTESHP_N>().ToTable("TGTESHPN");
            modelBuilder.Entity<TPCK>().ToTable("TPCK");
            modelBuilder.Entity<TXPNS>().ToTable("TXPNS");
            modelBuilder.Entity<TGTEDUEK>().ToTable("TGTEDUEK");
            modelBuilder.Entity<ADDINFO_TAB_TGTEDUEK>().ToTable("ADDINFO_TAB_TGTEDUEK");
            modelBuilder.Entity<ADDRESS_TAB_TGTEDUEK>().ToTable("ADDRESS_TAB_TGTEDUEK");
            modelBuilder.Entity<TGTEDUEP>().ToTable("TGTEDUEP");
            modelBuilder.Entity<ADDINFO_TAB_TGTEDUEP>().ToTable("ADDINFO_TAB_TGTEDUEP");
            modelBuilder.Entity<NFEREF_TAB_TGTEDUEP>().ToTable("NFEREF_TAB_TGTEDUEP");
            modelBuilder.Entity<DUEATRIB_TAB_TGTEDUEP>().ToTable("DUEATRIB_TAB_TGTEDUEP");
            modelBuilder.Entity<ATOCON_TAB_TGTEDUEP>().ToTable("ATOCON_TAB_TGTEDUEP");
            modelBuilder.Entity<SHP>().ToTable("SHP");
            modelBuilder.Entity<SHP_TEXT_Main>().ToTable("SHP_TEXT_Main");
            modelBuilder.Entity<MAIN>().ToTable("Main");
            modelBuilder.Entity<IC>().ToTable("IC");
            modelBuilder.Entity<ST>().ToTable("ST");
            modelBuilder.Entity<BUK>().ToTable("BUK");
            modelBuilder.Entity<PAR>().ToTable("PAR");
            modelBuilder.Entity<PARS>().ToTable("PARS");
            modelBuilder.Entity<DAT>().ToTable("DAT");
            modelBuilder.Entity<DI>().ToTable("DI");
            modelBuilder.Entity<BLImportation>().ToTable("BL");
            modelBuilder.Entity<XPNS>().ToTable("XPNS");
            modelBuilder.Entity<KURDIS>().ToTable("KURDIS");
            modelBuilder.Entity<MAKTX_TEXT_SHP>().ToTable("MAKTX_TEXT_SHP");
            modelBuilder.Entity<NFSK>().ToTable("NFSK");
            modelBuilder.Entity<TTAX>().ToTable("TTAX");
            modelBuilder.Entity<INVP>().ToTable("INVP");
            modelBuilder.Entity<CHARGS>().ToTable("CHARGS");
            modelBuilder.Entity<II>().ToTable("II");
            modelBuilder.Entity<IP>().ToTable("IP");
            modelBuilder.Entity<PS>().ToTable("PS");
            modelBuilder.Entity<CF>().ToTable("CF");
            modelBuilder.Entity<SERNR>().ToTable("SERNR");

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}