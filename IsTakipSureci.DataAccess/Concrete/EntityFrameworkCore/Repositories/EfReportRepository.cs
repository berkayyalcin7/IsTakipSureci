using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfRepositoryBase<Report>, IReportDal
    {
        public Report GetByWorkId(int id)
        {
            using var context = new IsSureciContext();
            return context.Reports.Include(x => x.Work).ThenInclude(x=>x.Level).Where(y=>y.Id==id).FirstOrDefault();
        }

        public int GetReportCountByUserId(int id)
        {
            using var context = new IsSureciContext();
            var result = context.Works.Include(x => x.Reports).Where(x => x.AppUserId == id);

            // Raporların sayısı .
            return result.SelectMany(x => x.Reports).Count();
        }
    }
}
