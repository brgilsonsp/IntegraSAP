﻿using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO
{
    public class ADDINFO_TAB_TGTEDUEPDao
    {
        private ChangeXMLContext _context = ChangeXMLContext.GetInstance();

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Save(ADDINFO_TAB_TGTEDUEP item)
        {
            _context.ADDINFO_TAB_TGTEDUEPs.Add(item);
            _context.SaveChanges();
        }

        public void SaveAll(IList<ADDINFO_TAB_TGTEDUEP> itens)
        {
            _context.ADDINFO_TAB_TGTEDUEPs.AddRange(itens);
            _context.SaveChanges();
        }

        public void Remove(ADDINFO_TAB_TGTEDUEP item)
        {
            _context.ADDINFO_TAB_TGTEDUEPs.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAll(IList<ADDINFO_TAB_TGTEDUEP> itens)
        {
            _context.ADDINFO_TAB_TGTEDUEPs.RemoveRange(itens);
            _context.SaveChanges();
        }

        public IList<ADDINFO_TAB_TGTEDUEP> FindByIdTGTEDUEP(int idTGTEDUEP)
        {
            return _context.ADDINFO_TAB_TGTEDUEPs.Where(a => a.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<ADDINFO_TAB_TGTEDUEP> FindById(int id)
        {
            return _context.ADDINFO_TAB_TGTEDUEPs.Where(a => a.ID == id).ToList();
        }

        public IList<ADDINFO_TAB_TGTEDUEP> FindByIdTGTEDUEPAsNoTracking(int idTGTEDUEP)
        {
            return _context.ADDINFO_TAB_TGTEDUEPs.AsNoTracking().Where(a => a.TGTEDUEPID == idTGTEDUEP).ToList();
        }

        public IList<ADDINFO_TAB_TGTEDUEP> FindByIdAsNoTracking(int id)
        {
            return _context.ADDINFO_TAB_TGTEDUEPs.AsNoTracking().Where(a => a.ID == id).ToList();
        }
    }
}