using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class TGTESHK_NDao : IContextChangeXml<TGTESHK_N>
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

        public void Delete(TGTESHK_N item)
        {
            _context.TGTESHK_Ns.Remove(item);
            _context.SaveChanges();
        }

        public void DeleteAll(IList<TGTESHK_N> itens)
        {
            _context.TGTESHK_Ns.RemoveRange(itens);
            _context.SaveChanges();
        }

        public TGTESHK_N FindByIdEager(int idItem)
        {
            return AllEager().FirstOrDefault(t => t.ID == idItem);
        }

        public TGTESHK_N FindByIdLazy(int idItem)
        {
            return _context.TGTESHK_Ns.FirstOrDefault(t => t.ID == idItem);
        }

        public IList<TGTESHK_N> FindByIdEmbarqueEager(int idEmbarque)
        {
            return AllEager().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public IList<TGTESHK_N> FindByIdEmbarqueLazy(int idEmbarque)
        {
            return _context.TGTESHK_Ns.Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public IList<TGTESHK_N> FindAllEager()
        {
            return AllEager().ToList();
        }

        public IList<TGTESHK_N> FindAllLazy()
        {
            return _context.TGTESHK_Ns.ToList();
        }

        private IQueryable<TGTESHK_N> AllEager()
        {
            return from tgteshkn in _context.TGTESHK_Ns
           .Include("TGTESHP_N")
           .Include("TGTESHP_N.MAKTX_TEXT")
           .Include("TGTERES")
           .Include("TGTEPRD")
           .Include("SHP_TEXT")
           .Include("TGTEDUEK")
           .Include("TGTEDUEK.ADDRESS_TAB")
           .Include("TGTEDUEK.ADDINFO_TAB")
           .Include("TGTEDUEP")
           .Include("TGTEDUEP.ADDINFO_TAB")
           .Include("TGTEDUEP.NFEREF_TAB")
           .Include("TGTEDUEP.ATOCON_TAB")
           .Include("TGTEDUEP.DUEATRIB_TAB")
            select tgteshkn;
        }
    }
}
