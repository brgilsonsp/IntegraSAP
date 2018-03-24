using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class StatusDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Save(Status status)
        {
            _context.StatusRetornos.Add(status);
            _context.SaveChanges();
        }
    }
}
