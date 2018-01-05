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
        

        #endregion

        #region Factory instance

        /// <summary>
        /// Cria uma instância de ChangeXMLContext e retorna
        /// </summary>
        /// <returns>Instância de ChangeXMLContext</returns>
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
        /// Recarrega o contexto, forçando uma nova consulta no banco de dados
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


            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}