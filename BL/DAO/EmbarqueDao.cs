using BL.ObjectMessages;
using System.Collections.Generic;
using System.Linq;

namespace BL.DAO
{
    public class EmbarqueDao
    {

        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public IList<Embarque> FindConsultaDetalheEnableAsNoTracking()
        {
            return _context.Embarques.AsNoTracking().Where(e => e.ConsultaDetalhe == true).ToList();
        }

        public IList<Embarque> FindAtualizaDetalheEnbaleAsNoTracking()
        {
            return _context.Embarques.AsNoTracking().Where(e => e.AtualizaDetalhe == true).ToList();
        }

        public IList<Embarque> FindEnviaPrestacaoContaEnbaleAsNoTracking()
        {
            return _context.Embarques.AsNoTracking().Where(e => e.EnviaPrestConta == true).ToList();
        }

        public IList<Embarque> FindConsultaPrestacaoContaEnbaleAsNoTracking()
        {
            return _context.Embarques.AsNoTracking().Where(e => e.ConsultaPrestConta == true).ToList();
        }

        public Embarque FindBySbelnAsNoTracking(string sbeln)
        {
            return _context.Embarques.AsNoTracking().FirstOrDefault(e => e.SBELN == sbeln);
        }

        public Embarque FindByIdAsNoTracking(int id)
        {
            return _context.Embarques.AsNoTracking().FirstOrDefault(e => e.ID == id);
        }

        public Embarque FindBySbeln(string sbeln)
        {
            return _context.Embarques.FirstOrDefault(e => e.SBELN == sbeln);
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

        public List<string> GetListSbeln()
        {
            return _context.Embarques.Select(e => e.SBELN).ToList();
        }
    }
}
