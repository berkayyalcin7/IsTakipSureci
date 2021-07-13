using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IsTakipSureci.Business.Interfaces
{
    public interface IWorkService:IService<Work>
    {
        List<Work> GetLevelsStatusFalse();

        List<Work> GetAllWithTables();

        List<Work> GetAllWithTables(Expression<Func<Work, bool>> filter);

        List<Work> GetAllWithTablesCompleted(out int pageCount, int userId, int activePage=1);


        Work GetWithLevel(int id);

        List<Work> GetByUserId(int userId);

        Work GetWithReport(int id);
    }
}
