using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.Interfaces
{
    public interface IReportService : IService<Report>
    {
        Report GetByWorkId(int id);

    }
}
