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

        public List<Work> GetAllWithTablesCompleted(out int pageCount, int userId,int activePage=1)
        {
            using var context = new IsSureciContext();
            // Eager Loading Include ile Level'i dahil ettik
             var returnValue = context.Works
                .Include(x => x.Level)
                .Include(x => x.Reports)
                .Include(x => x.AppUser)
                .Where(x => x.AppUserId == userId && x.Status ==true)
                .OrderByDescending(x => x.CreatedDate);

            pageCount = (int)Math.Ceiling((double)returnValue.Count() / 3);

            // Sayfalama işlemi
            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public int GetFinishWorkCountByUserId(int id)
        {
            using var context = new IsSureciContext();

            return context.Works.Count(x => x.AppUserId == id && x.Status);

        }

        public int GetWorkCountNotFinishByUserId(int id)
        {
            using var context = new IsSureciContext();

            return context.Works.Count(x => x.AppUserId == id && !x.Status);
        }

        public int GetNotAssignWorkCount()
        {
            using var context = new IsSureciContext();

            return context.Works.Count(x => x.AppUserId == null && !x.Status);

        }

        public int GetFinishedWorkCount()
        {
            using var context = new IsSureciContext();
            return context.Works.Count(x=>x.Status);
        }
    }
}
