using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TPCKDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();


        public void Save(TPCK item)
        {
            _context.TPCKs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TPCK> itens)
        {
            _context.TPCKs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(TPCK item)
        {
            _context.TPCKs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<TPCK> itens)
        {
            _context.TPCKs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public List<TPCK> FindByIdEmbarque(int idEmbarque)
        {
            return _context.TPCKs.Include("TXPNS").Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TPCK> FindById(int id)
        {
            return _context.TPCKs.Include("TXPNS").Where(t => t.ID == id).ToList();
        }

        public List<TPCK> FindByIdEmbarqueAsNoTracking(int idEmbarque)
        {
            return _context.TPCKs.Include("TXPNS").AsNoTracking().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TPCK> FindByIdAsNoTracking(int id)
        {
            return _context.TPCKs.Include("TXPNS").AsNoTracking().Where(t => t.ID == id).ToList();
        }
    }
}
