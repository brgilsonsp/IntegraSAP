using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class DUEATRIB_TAB_TGTEDUEPDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(DUEATRIB_TAB_TGTEDUEP item)
        {
            _context.DUEATRIB_TAB_TGTEDUEPs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<DUEATRIB_TAB_TGTEDUEP> itens)
        {
            _context.DUEATRIB_TAB_TGTEDUEPs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(DUEATRIB_TAB_TGTEDUEP item)
        {
            _context.DUEATRIB_TAB_TGTEDUEPs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<DUEATRIB_TAB_TGTEDUEP> itens)
        {
            _context.DUEATRIB_TAB_TGTEDUEPs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public IList<DUEATRIB_TAB_TGTEDUEP> FindByIdTGTEDUEP(int idTGTEDUEP)
        {
            return _context.DUEATRIB_TAB_TGTEDUEPs.Where(d => d.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<DUEATRIB_TAB_TGTEDUEP> FindById(int id)
        {
            return _context.DUEATRIB_TAB_TGTEDUEPs.Where(d => d.ID == id).ToList();
        }

        public IList<DUEATRIB_TAB_TGTEDUEP> FindByIdTGTEDUEPAsNoTracking(int idTGTEDUEP)
        {
            return _context.DUEATRIB_TAB_TGTEDUEPs.AsNoTracking().Where(d => d.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<DUEATRIB_TAB_TGTEDUEP> FindByIdAsNoTracking(int id)
        {
            return _context.DUEATRIB_TAB_TGTEDUEPs.AsNoTracking().Where(d => d.ID == id).ToList();
        }
    }
}
