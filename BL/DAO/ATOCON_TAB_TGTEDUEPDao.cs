using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class ATOCON_TAB_TGTEDUEPDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(ATOCON_TAB_TGTEDUEP item)
        {
            _context.ATOCON_TAB_TGTEDUEPs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<ATOCON_TAB_TGTEDUEP> itens)
        {
            _context.ATOCON_TAB_TGTEDUEPs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(ATOCON_TAB_TGTEDUEP item)
        {
            _context.ATOCON_TAB_TGTEDUEPs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<ATOCON_TAB_TGTEDUEP> itens)
        {
            _context.ATOCON_TAB_TGTEDUEPs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public IList<ATOCON_TAB_TGTEDUEP> FindByIdTGTEDUEP(int idTGTEDUEP)
        {
            return _context.ATOCON_TAB_TGTEDUEPs.Where(a => a.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<ATOCON_TAB_TGTEDUEP> FindById(int id)
        {
            return _context.ATOCON_TAB_TGTEDUEPs.Where(a => a.ID == id).ToList();
        }

        public IList<ATOCON_TAB_TGTEDUEP> FindByIdTGTEDUEPAsNoTracking(int idTGTEDUEP)
        {
            return _context.ATOCON_TAB_TGTEDUEPs.AsNoTracking().Where(a => a.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<ATOCON_TAB_TGTEDUEP> FindByIdAsNoTracking(int id)
        {
            return _context.ATOCON_TAB_TGTEDUEPs.AsNoTracking().Where(a => a.ID == id).ToList();
        }
    }
}
