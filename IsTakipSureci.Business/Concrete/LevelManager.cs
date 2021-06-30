using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Concrete
{
    public class LevelManager : ILevelService
    {
        private readonly ILevelDal _levelDal;

        public LevelManager(ILevelDal levelDal)
        {
            _levelDal = levelDal;
        }

        public void Delete(Level entity)
        {
            _levelDal.Delete(entity);
        }

        public List<Level> GetAll()
        {
            return _levelDal.GetAll();
        }

        public Level GetById(int id)
        {
            return _levelDal.GetById(id);
        }

        public void Save(Level entity)
        {
            _levelDal.Save(entity);
        }

        public void Update(Level entity)
        {
            _levelDal.Update(entity);
        }
    }
}
