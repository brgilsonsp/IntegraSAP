using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BL.DAO
{
    public class DadosBrokerDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public IList<DadosBroker> FindAllAsNoTracking()
        {
            return _context.DadosBrokers.AsNoTracking().Include("DadosBrokerCabecalho.Cabecalho").ToList();
        }

        public DadosBroker FindByIdAsNoTracking(int id)
        {
            return _context.DadosBrokers.AsNoTracking().Include("DadosBrokerCabecalho.Cabecalho").FirstOrDefault(db => db.ID == id);
        }
    }
}
