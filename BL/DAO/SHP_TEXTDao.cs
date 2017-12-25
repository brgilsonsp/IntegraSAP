using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class SHP_TEXTDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(SHP_TEXT item)
        {
            _context.SHPTEXTs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<SHP_TEXT> itens)
        {
            _context.SHPTEXTs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(SHP_TEXT item)
        {
            _context.SHPTEXTs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<SHP_TEXT> itens)
        {
            _context.SHPTEXTs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public IList<SHP_TEXT> FindByIdEmbarque(int idEmbarque)
        {
            return _context.SHPTEXTs.Where(s => s.EmbarqueID == idEmbarque).ToList();
        }

        public IList<SHP_TEXT> FindById(int id)
        {
            return _context.SHPTEXTs.Where(s => s.ID == id).ToList();
        }

        public IList<SHP_TEXT> FindByIdEmbarqueAsNoTracking(int idEmbarque)
        {
            return _context.SHPTEXTs.AsNoTracking().Where(s => s.EmbarqueID == idEmbarque).ToList();
        }

        public IList<SHP_TEXT> FindByIdAsNoTracking(int id)
        {
            return _context.SHPTEXTs.AsNoTracking().Where(s => s.ID == id).ToList();
        }
    }
}
