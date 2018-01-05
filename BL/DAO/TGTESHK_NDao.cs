using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TGTESHK_NDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(TGTESHK_N item)
        {
            _context.TGTESHK_Ns.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TGTESHK_N> itens)
        {
            _context.TGTESHK_Ns.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(TGTESHK_N item)
        {
            _context.TGTESHK_Ns.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<TGTESHK_N> itens)
        {
            _context.TGTESHK_Ns.RemoveRange(itens);
            _context.SaveChanges();
        }

        public List<TGTESHK_N> FindByIdEmbarque(int indEmbarque)
        {
            return _context.TGTESHK_Ns.Where(t => t.EmbarqueID == indEmbarque).ToList();
        }

        public TGTESHK_N FindByID(int id)
        {
            return _context.TGTESHK_Ns.FirstOrDefault(t => t.ID == id);
        }
        
        public List<TGTESHK_N> FindByIdEmbarqueAsNoTracking(int indEmbarque)
        {
            return _context.TGTESHK_Ns.AsNoTracking().Where(t => t.EmbarqueID == indEmbarque).ToList();
        }

        public TGTESHK_N FindByIDAsNoTracking(int id)
        {
            return _context.TGTESHK_Ns.AsNoTracking().FirstOrDefault(t => t.ID == id);
        }
    }
}
