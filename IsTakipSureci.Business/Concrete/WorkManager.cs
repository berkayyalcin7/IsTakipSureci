using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IsTakipSureci.Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private IWorkDal _workDal;

        public WorkManager(IWorkDal workDal)
        {
            _workDal = workDal;
        }

        public List<Work> GetAll()
        {
            return _workDal.GetAll();
        }

        public Work GetById(int id)
        {
            return _workDal.GetById(id);
        }

        public void Save(Work entity)
        {
            _workDal.Save(entity);
        }

        public void Update(Work entity)
        {
            _workDal.Update(entity);
        }

        public void Delete(Work entity)
        {
            _workDal.Delete(entity);
        }

        public List<Work> GetLevelsStatusFalse()
        {
            return _workDal.GetLevelsStatusFalse();
        }

        public List<Work> GetAllWithTables()
        {
            return _workDal.GetAllWithTables();
        }

        public Work GetWithLevel(int id)
        {
            return _workDal.GetWithLevel(id);
        }

        public List<Work> GetByUserId(int userId)
        {
            return _workDal.GetByUserId(userId);
        }

        public Work GetWithReport(int id)
        {
            return _workDal.GetWithReport(id);
        }

        public List<Work> GetAllWithTables(Expression<Func<Work, bool>> filter)
        {
            return _workDal.GetAllWithTables(filter);
        }

        public List<Work> GetAllWithTablesCompleted(out int pageCount, int userId, int activePage)
        {
            return _workDal.GetAllWithTablesCompleted(out pageCount, userId, activePage);
        }
    }
}
