using BL.ObjectMessages;
using System.Collections.Generic;
using System.Linq;

namespace BL.DAO
{
    public class EmbarqueDao
    {

        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public IList<Embarque> FindConsultaDetalheEnableAsNoTracking(string kindfOeMessge)
        {
            return _context.Embarques.AsNoTracking().Where(e => e.ConsultaDetalhe == true && e.Tipo == kindfOeMessge).ToList();
        }

        public IList<Embarque> FindAtualizaDetalheEnbaleAsNoTracking(string kindfOeMessge)
        {
            return _context.Embarques.AsNoTracking().Where(e => e.AtualizaDetalhe == true && e.Tipo == kindfOeMessge).ToList();
        }

        public IList<Embarque> FindEnviaPrestacaoContaEnbaleAsNoTracking(string kindfOeMessge)
        {
            return _context.Embarques.AsNoTracking().Where(e => e.EnviaPrestConta == true && e.Tipo == kindfOeMessge).ToList();
        }

        public IList<Embarque> FindConsultaPrestacaoContaEnbaleAsNoTracking(string kindfOeMessge)
        {
            return _context.Embarques.AsNoTracking().Where(e => e.ConsultaPrestConta == true && e.Tipo == kindfOeMessge).ToList();
        }

        public Embarque FindBySbelnAsNoTracking(string sbeln, string kinfOeMessge)
        {
            return _context.Embarques.AsNoTracking().FirstOrDefault(e => e.SBELN == sbeln && e.Tipo == kinfOeMessge);
        }

        public Embarque FindByIdAsNoTracking(int id)
        {
            return _context.Embarques.AsNoTracking().FirstOrDefault(e => e.ID == id);
        }

        public Embarque FindBySbeln(string sbeln, string kinfOeMessge)
        {
            return _context.Embarques.FirstOrDefault(e => e.SBELN == sbeln && e.Tipo == kinfOeMessge);
        }

        public Embarque FindById(int id)
        {
            return _context.Embarques.FirstOrDefault(e => e.ID == id);
        }


        public void Save(Embarque item)
        {
            _context.Embarques.Add(item);
            _context.SaveChanges();
        }
        
        public void Update()
        {
            _context.SaveChanges();
        }

        public List<string> GetListSbeln(string kindOfMessage)
        {
            return _context.Embarques.Where(e => e.Tipo == kindOfMessage).Select(e => e.SBELN).ToList();
        }
    }
}
