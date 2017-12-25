using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TGTEDUEPDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(TGTEDUEP item)
        {
            _context.TGTEDUEPs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TGTEDUEP> itens)
        {
            _context.TGTEDUEPs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(TGTEDUEP item)
        {
            _context.TGTEDUEPs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<TGTEDUEP> itens)
        {
            _context.TGTEDUEPs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public IList<TGTEDUEP> FindByIdEmbarque(int idEmbarque)
        {
            return _context.TGTEDUEPs.Include("ADDINFO_TAB").Include("NFEREF_TAB").Include("ATOCON_TAB").Include("DUEATRIB_TAB")
                .Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public IList<TGTEDUEP> FindById(int id)
        {
            return _context.TGTEDUEPs.Where(t => t.ID == id).ToList();
        }

        public IList<TGTEDUEP> FindByIdEmbarqueAsNoTracking(int idEmbarque)
        {
            return _context.TGTEDUEPs.AsNoTracking().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public IList<TGTEDUEP> FindByIdAsNoTracking(int id)
        {
            return _context.TGTEDUEPs.AsNoTracking().Where(t => t.ID == id).ToList();
        }
    }
}
