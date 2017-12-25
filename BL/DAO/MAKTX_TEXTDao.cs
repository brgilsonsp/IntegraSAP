using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class MAKTX_TEXTDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(MAKTX_TEXT item)
        {
            _context.MAKTX_TEXTs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<MAKTX_TEXT> itens)
        {
            _context.MAKTX_TEXTs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(MAKTX_TEXT item)
        {
            _context.MAKTX_TEXTs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<MAKTX_TEXT> itens)
        {
            _context.MAKTX_TEXTs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public MAKTX_TEXT FindById(int id)
        {
            return _context.MAKTX_TEXTs.FirstOrDefault(m => m.ID == id);
        }

        public IList<MAKTX_TEXT> FindByIdTGTESHPN(int idTGTESHPN)
        {
            return _context.MAKTX_TEXTs.Where(m => m.TGTESHPNID == idTGTESHPN).ToList();
        }

        public MAKTX_TEXT FindByIdAsNoTracking(int id)
        {
            return _context.MAKTX_TEXTs.AsNoTracking().FirstOrDefault(m => m.ID == id);
        }

        public IList<MAKTX_TEXT> FindByIdTGTESHPNAsNoTracking(int idTGTESHPN)
        {
            return _context.MAKTX_TEXTs.AsNoTracking().Where(m => m.TGTESHPNID == idTGTESHPN).ToList();
        }


    }
}
