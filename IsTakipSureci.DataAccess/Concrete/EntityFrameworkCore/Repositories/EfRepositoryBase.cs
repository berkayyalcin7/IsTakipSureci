using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRepositoryBase<TEntity> : IRepositoryDal<TEntity> where TEntity : class, ITable, new()
    {
        public List<TEntity> GetAll()
        {
            using var context = new IsSureciContext();
            return context.Set<TEntity>().ToList();
            
        }

        public TEntity GetById(int id)
        {
            using var context = new IsSureciContext();
            return context.Set<TEntity>().Find(id);
        }

        public void Save(TEntity entity)
        {
            using var context = new IsSureciContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new IsSureciContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            using var context = new IsSureciContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }
}
