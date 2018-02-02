using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class MainDAO : IContextChangeXml<MAIN>
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(MAIN item)
        {
            _context.MAINs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<MAIN> itens)
        {
            _context.MAINs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Delete(MAIN item)
        {
            _context.MAINs.Remove(item);
            _context.SaveChanges();
        }

        public void DeleteAll(IList<MAIN> itens)
        {
            _context.MAINs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public MAIN FindByIdEager(int id)
        {
            return AllEager().FirstOrDefault(m => m.ID == id);
        }

        public MAIN FindByIdLazy(int idItem)
        {
            return _context.MAINs.FirstOrDefault(m => m.ID == idItem);
        }
        public IList<MAIN> FindByIdEmbarqueEager(int idEmbarque)
        {
            return AllEager().Where(m => m.EmbarqueID == idEmbarque).ToList();
        }

        public IList<MAIN> FindByIdEmbarqueLazy(int idEmbarque)
        {
            return _context.MAINs.Where(m => m.EmbarqueID == idEmbarque).ToList();
        }

        public IList<MAIN> FindAllEager()
        {
            return AllEager().ToList();
        }

        public IList<MAIN> FindAllLazy()
        {
            return _context.MAINs.ToList();            
        }

        private IQueryable<MAIN> AllEager()
        {
            return from main in _context.MAINs.Include("BUK")
                    .Include("PAR")
                    .Include("PARs")
                    .Include("DAT")
                    .Include("DI")
                    .Include("DI.XPNS")
                    .Include("DI.KURDIS")
                    .Include("BL")
                    .Include("SHP.MAKTX_TEXT")
                    .Include("SHP.NFSK")
                    .Include("SHP.TTAX")
                    .Include("SHP.TTAX.ST")
                    .Include("SHP.TTAX.II")
                    .Include("SHP.TTAX.IP")
                    .Include("SHP.TTAX.PS")
                    .Include("SHP.TTAX.CF")
                    .Include("SHP.TTAX.IC")
                    .Include("SHP.INVP")
                    .Include("SHP.CHARGS")
                    .Include("SHP.CHARGS.SERNR")
                    .Include("SHP_TEXT_Main")
                    select main;
        }        
    }
}
