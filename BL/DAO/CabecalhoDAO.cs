using BL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BL.DAO
{
    public class CabecalhoDAO
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public IList<CabecalhoEntity> FindAll()
        {
            return _context.Cabecalhos.Include("CabecalhoDadosBroker").ToList();
        }
    }
}
