using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotifyRepository : EfRepositoryBase<Notify>, INotifyDal
    {
        public List<Notify> GetByStatus(int appUserId)
        {
            using var context = new IsSureciContext();
            return context.Notifys.Where(x => x.AppUserId == appUserId && !x.Status).ToList();
        }
    }
}
