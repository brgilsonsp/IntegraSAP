using BL.ObjectMessages;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BL.DAO
{
    public class TPCKDao : IContextChangeXml<TPCK>
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();


        public void Save(TPCK item)
        {
            _context.TPCKs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<TPCK> itens)
        {
            _context.TPCKs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Update()
        {
            _context.SaveChanges();
        }
        
        public void Delete(TPCK item)
        {
            _context.TPCKs.Remove(item);
            _context.SaveChanges();
        }

        public void DeleteAll(IList<TPCK> itens)
        {
            _context.TPCKs.RemoveRange(itens);
            _context.SaveChanges();
        }
        
        public IList<TPCK> FindByIdEmbarqueEager(int idEmbarque)
        {
            return AllEager().Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public IList<TPCK> FindByIdEmbarqueLazy(int idEmbarque)
        {
            return _context.TPCKs.Where(t => t.EmbarqueID == idEmbarque).ToList();
        }

        public TPCK FindByIdEager(int idItem)
        {
            return AllEager().FirstOrDefault(t => t.ID == idItem);
        }

        public TPCK FindByIdLazy(int idItem)
        {
            return _context.TPCKs.FirstOrDefault(t => t.ID == idItem);
        }

        public IList<TPCK> FindAllEager()
        {
            return AllEager().ToList();
        }

        public IList<TPCK> FindAllLazy()
        {
            return _context.TPCKs.ToList();
        }

        private IQueryable<TPCK> AllEager()
        {
            return from tpck in _context.TPCKs.Include("TXPNS")
                   select tpck;
        }
    }
}
