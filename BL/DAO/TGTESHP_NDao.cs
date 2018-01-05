using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TGTESHP_NDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Save(TGTESHP_N item)
        {
            _context.TGTESHP_Ns.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TGTESHP_N> itens)
        {
            _context.TGTESHP_Ns.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(TGTESHP_N item)
        {
            _context.TGTESHP_Ns.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<TGTESHP_N> itens)
        {
            _context.TGTESHP_Ns.RemoveRange(itens);
            _context.SaveChanges();
        }

        public List<TGTESHP_N> FindByIDEmbarque(int idEmbarque)
        {
            return _context.TGTESHP_Ns.Include("MAKTX_TEXT").Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public TGTESHP_N FindById(int id)
        {
            return _context.TGTESHP_Ns.Include("MAKTX_TEXT").FirstOrDefault(t => t.ID == id);
        }

        public List<TGTESHP_N> FindByIDEmbarqueAsNoTracking(int idEmbarque)
        {
            return _context.TGTESHP_Ns.Include("MAKTX_TEXT").AsNoTracking().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public TGTESHP_N FindByIdAsNoTracking(int id)
        {
            return _context.TGTESHP_Ns.Include("MAKTX_TEXT").AsNoTracking().FirstOrDefault(t => t.ID == id);
        }

        public void Update()
        {
            _context.SaveChanges();
        }
    }
}
