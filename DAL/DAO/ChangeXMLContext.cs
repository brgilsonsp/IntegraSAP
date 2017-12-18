using DAL.Entities;
using System.Configuration;
using System.Data.Entity;

namespace DAL.DAO
{
    public class ChangeXMLContext : DbContext
    {
        #region Entidades Mapeadas
        public DbSet<CabecalhoEntity> Cabecalhos { get; set; }

        public DbSet<CabecalhoDadosBrokerEntity> CabecalhosDadosBrokers { get; set; }

        public DbSet<DadosBroker> DadosBrokers { get; set; }

        public DbSet<DetalheError> DetalhesErrors { get; set; }

        public DbSet<EmbarqueEntity> Embarques { get; set; }

        public DbSet<MAKTX_TEXT> MAKTX_TEXTs { get; set; }

        public DbSet<SHPTEXT> SHPTEXTs { get; set; }

        public DbSet<StatusRetorno> StatusRetornos { get; set; }

        public DbSet<TGTEPRD> TGTEPRDs { get; set; }

        public DbSet<TGTERES> TGTERESs { get; set; }

        public DbSet<TGTESHKN> TGTESHKNs { get; set; }

        public DbSet<TGTESHPN> TGTESHPNs { get; set; }

        public DbSet<TPCK> TPCKs { get; set; }

        public DbSet<TXPNS> TXPNSs { get; set; }

        #endregion


        #region Factory instance

        /// <summary>
        /// Cria uma instância de ChangeXMLContext e retorna
        /// </summary>
        /// <returns>Instância de ChangeXMLContext</returns>
        public static ChangeXMLContext GetInstance() {
            string stringConnection = ConfigurationManager.ConnectionStrings["BrokerMessageConnectionString"].ConnectionString;
            if(_context == null)
                _context = new ChangeXMLContext(stringConnection);

            return _context;
        }
        private ChangeXMLContext(string nameConnectionString):base(nameConnectionString) { }

        private static ChangeXMLContext _context;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CabecalhoEntity>().ToTable("Cabecalho");
            modelBuilder.Entity<CabecalhoDadosBrokerEntity>().ToTable("CabecalhoDadosBroker");
            modelBuilder.Entity<EmbarqueEntity>().ToTable("Embarque");
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}