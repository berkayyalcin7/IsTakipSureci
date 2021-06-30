using IsTakipSureci.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Interfaces
{
    public interface IService<TEntity> where TEntity:class,ITable,new()
    {
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        List<TEntity> GetAll();
    }
}
