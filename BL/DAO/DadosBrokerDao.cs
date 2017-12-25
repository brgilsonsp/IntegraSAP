using BL.ObjectMessages;
using System.Collections.Generic;
using System.Linq;

namespace BL.DAO
{
    public class DadosBrokerDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public IList<DadosBroker> FindAllAsNoTracking()
        {
            return _context.DadosBrokers.AsNoTracking().Include("DadosBrokerCabecalho").ToList();
        }

        public DadosBroker FindByIdAsNoTracking(int id)
        {
            return _context.DadosBrokers.AsNoTracking().Include("DadosBrokerCabecalho").FirstOrDefault(db => db.ID == id);
        }
    }
}
