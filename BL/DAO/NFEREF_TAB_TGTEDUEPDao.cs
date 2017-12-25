using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class NFEREF_TAB_TGTEDUEPDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(NFEREF_TAB_TGTEDUEP item)
        {
            _context.NFEREF_TAB_TGTEDUEPs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<NFEREF_TAB_TGTEDUEP> itens)
        {
            _context.NFEREF_TAB_TGTEDUEPs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(NFEREF_TAB_TGTEDUEP item)
        {
            _context.NFEREF_TAB_TGTEDUEPs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<NFEREF_TAB_TGTEDUEP> itens)
        {
            _context.NFEREF_TAB_TGTEDUEPs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public IList<NFEREF_TAB_TGTEDUEP> FindByIdTGTEDUEP(int idTGTEDUEP)
        {
            return _context.NFEREF_TAB_TGTEDUEPs.Where(n => n.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<NFEREF_TAB_TGTEDUEP> FindById(int id)
        {
            return _context.NFEREF_TAB_TGTEDUEPs.Where(n => n.ID == id).ToList();
        }

        public IList<NFEREF_TAB_TGTEDUEP> FindByIdTGTEDUEPAsNoTracking(int idTGTEDUEP)
        {
            return _context.NFEREF_TAB_TGTEDUEPs.AsNoTracking().Where(n => n.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<NFEREF_TAB_TGTEDUEP> FindByIdAsNoTracking(int id)
        {
            return _context.NFEREF_TAB_TGTEDUEPs.AsNoTracking().Where(n => n.ID == id).ToList();
        }
    }
}
