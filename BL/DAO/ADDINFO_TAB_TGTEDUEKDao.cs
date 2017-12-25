using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class ADDINFO_TAB_TGTEDUEKDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(ADDINFO_TAB_TGTEDUEK item)
        {
            _context.ADDINFO_TAB_TGTEDUEKs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<ADDINFO_TAB_TGTEDUEK> itens)
        {
            _context.ADDINFO_TAB_TGTEDUEKs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(ADDINFO_TAB_TGTEDUEK item)
        {
            _context.ADDINFO_TAB_TGTEDUEKs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<ADDINFO_TAB_TGTEDUEK> itens)
        {
            _context.ADDINFO_TAB_TGTEDUEKs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public IList<ADDINFO_TAB_TGTEDUEK> FindByIdTGTEDUEK(int idTGTEDUEK)
        {
            return _context.ADDINFO_TAB_TGTEDUEKs.Where(a => a.TGTEDUEKID == idTGTEDUEK).ToList();
        }

        public IList<ADDINFO_TAB_TGTEDUEK> FindById(int id)
        {
            return _context.ADDINFO_TAB_TGTEDUEKs.Where(a => a.ID == id).ToList();
        }

        public IList<ADDINFO_TAB_TGTEDUEK> FindByIdTGTEDUEKAsNoTracking(int idTGTEDUEK)
        {
            return _context.ADDINFO_TAB_TGTEDUEKs.AsNoTracking().Where(a => a.TGTEDUEKID == idTGTEDUEK).ToList();
        }

        public IList<ADDINFO_TAB_TGTEDUEK> FindByIdAsNoTracking(int id)
        {
            return _context.ADDINFO_TAB_TGTEDUEKs.AsNoTracking().Where(a => a.ID == id).ToList();
        }
    }
}
