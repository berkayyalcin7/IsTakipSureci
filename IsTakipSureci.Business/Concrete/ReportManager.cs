using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Concrete
{
    // Bunlar Refactor Edilecek
    public class ReportManager : IReportService
    {
        private IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public void Delete(Report entity)
        {
            _reportDal.Delete(entity);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public Report GetById(int id)
        {
            return _reportDal.GetById(id);
        }

        public void Save(Report entity)
        {
            _reportDal.Save(entity);
        }

        public void Update(Report entity)
        {
            _reportDal.Update(entity);
        }
    }
}
