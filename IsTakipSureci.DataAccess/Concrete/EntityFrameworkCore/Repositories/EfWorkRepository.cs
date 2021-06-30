using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : EfRepositoryBase<Work>, IWorkDal
    {
        public List<Work> GetAllWithTables()
        {
            using var context = new IsSureciContext();
            // Eager Loading Include ile Level'i dahil ettik
            return context.Works
                .Include(x => x.Level)
                .Include(x => x.Reports)
                .Include(x => x.AppUser)
                .Where(x => x.Status == false)
                .OrderByDescending(x => x.CreatedDate).ToList();
        }

        //Aciliyete göre görev getirme
        public Work GetWithLevel(int id)
        {

            using var context = new IsSureciContext();
            // Eager Loading Include ile Level'i dahil ettik
            return context.Works.Include(x => x.Level).Where(x => x.Status == false && x.Id == id).FirstOrDefault();

        }

        public List<Work> GetByUserId(int userId)
        {
            using var context = new IsSureciContext();

            return context.Works.Where(x => x.AppUserId == userId).ToList();

        }

        public List<Work> GetLevelsStatusFalse()
        {
            using var context = new IsSureciContext();
            // Eager Loading Include ile Level'i dahil ettik
            return context.Works.Include(x => x.Level).Where(x => x.Status == false).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public Work GetWithReport(int id)
        {
            using var context = new IsSureciContext();
            return context.Works.Include(x => x.Reports).Include(x=>x.AppUser).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Work> GetAllWithTables(Expression<Func<Work, bool>> filter)
        {
            using var context = new IsSureciContext();
            // Eager Loading Include ile Level'i dahil ettik
            return context.Works
                .Include(x => x.Level)
                .Include(x => x.Reports)
                .Include(x => x.AppUser)
                .Where(filter)
                .OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
