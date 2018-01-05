using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TGTEPRDDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(TGTEPRD item)
        {
            _context.TGTEPRDs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TGTEPRD> itens)
        {
            _context.TGTEPRDs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(TGTEPRD item)
        {
            _context.TGTEPRDs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<TGTEPRD> itens)
        {
            _context.TGTEPRDs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public List<TGTEPRD> FindByIdEmbarque(int idEmbarque)
        {
            return _context.TGTEPRDs.Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TGTEPRD> FindById(int id)
        {
            return _context.TGTEPRDs.Where(t => t.ID == id).ToList();
        }

        public List<TGTEPRD> FindByIdEmbarqueAsNoTracking(int idEmbarque)
        {
            return _context.TGTEPRDs.AsNoTracking().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TGTEPRD> FindByIdAsNoTracking(int id)
        {
            return _context.TGTEPRDs.AsNoTracking().Where(t => t.ID == id).ToList();
        }
    }
}
