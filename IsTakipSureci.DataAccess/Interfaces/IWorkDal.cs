using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IsTakipSureci.DataAccess.Interfaces
{
    //Concrete içerisindeki metotlar burada olacak
    public interface IWorkDal:IRepositoryDal<Work>
    {
        List<Work> GetLevelsStatusFalse();

        List<Work> GetAllWithTables();

        List<Work> GetAllWithTables(Expression<Func<Work,bool>> filter);

        Work GetWithLevel(int id);

        List<Work> GetByUserId(int userId);

        Work GetWithReport(int id);
      
    }
}
