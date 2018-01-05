using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TGTERESDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(TGTERES item)
        {
            _context.TGTERESs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TGTERES> itens)
        {
            _context.TGTERESs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(TGTERES item)
        {
            _context.TGTERESs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<TGTERES> itens)
        {
            _context.TGTERESs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public List<TGTERES> FindByIdEmbarque(int idEmbarque)
        {
            return _context.TGTERESs.Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TGTERES> FindById(int id)
        {
            return _context.TGTERESs.Where(t => t.ID == id).ToList();
        }

        public List<TGTERES> FindByIdEmbarqueAsNoTracking(int idEmbarque)
        {
            return _context.TGTERESs.AsNoTracking().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TGTERES> FindByIdAsNoTracking(int id)
        {
            return _context.TGTERESs.AsNoTracking().Where(t => t.ID == id).ToList();
        }
    }
}
