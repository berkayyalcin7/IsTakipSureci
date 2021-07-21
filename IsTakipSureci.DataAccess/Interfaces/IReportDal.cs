using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DataAccess.Interfaces
{
    public interface IReportDal:IRepositoryDal<Report>
    {
        Report GetByWorkId(int id);
        int GetReportCountByUserId(int id);

        int GetReportCount();
    }
}
