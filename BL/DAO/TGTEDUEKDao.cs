using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TGTEDUEKDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(TGTEDUEK item)
        {
            _context.TGTEDUEKs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TGTEDUEK> itens)
        {
            _context.TGTEDUEKs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(TGTEDUEK item)
        {
            _context.TGTEDUEKs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<TGTEDUEK> itens)
        {
            _context.TGTEDUEKs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public List<TGTEDUEK> FindByIdEmbarque(int idEmbarque)
        {
            return _context.TGTEDUEKs.Include("ADDRESS_TAB").Include("ADDINFO_TAB").Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TGTEDUEK> FindById(int id)
        {
            return _context.TGTEDUEKs.Include("ADDRESS_TAB").Include("ADDINFO_TAB").Where(t => t.ID == id).ToList();
        }

        public List<TGTEDUEK> FindByIdEmbarqueAsNoTracking(int idEmbarque)
        {
            return _context.TGTEDUEKs.Include("ADDRESS_TAB").Include("ADDINFO_TAB").AsNoTracking().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public List<TGTEDUEK> FindByIdAsNoTracking(int id)
        {
            return _context.TGTEDUEKs.Include("ADDRESS_TAB").Include("ADDINFO_TAB").AsNoTracking().Where(t => t.ID == id).ToList();
        }
    }
}
