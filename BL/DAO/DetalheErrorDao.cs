using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class DetalheErrorDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Save(DetalheError item)
        {
            _context.DetalhesErrors.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<DetalheError> listDetalheError)
        {
            foreach(DetalheError detalheError in listDetalheError)
                Save(detalheError);
        }
    }
}
