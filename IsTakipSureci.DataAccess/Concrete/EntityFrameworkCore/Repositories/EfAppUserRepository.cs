using IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IsTakipSureci.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetAllMemberUser()
        {
            using var context = new IsSureciContext();

            // Rol ismi Member Olan üyelerin Join  sorgusu ile çekilmesi
            return context.Users.Join(context.UserRoles, x => x.Id, x => x.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles, y => y.userRole.RoleId, y => y.Id, (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole

                }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
                {
                    Id = x.user.Id,
                    Name = x.user.Name,
                    Surname = x.user.Surname,
                    Picture = x.user.Picture,
                    Email = x.user.Email,
                    UserName = x.user.UserName
                }).ToList();
        }

        public List<AppUser> GetAllMemberUser(out int toplamSayfa, string aranacakKelime, int aktifSayfa = 1)
        {
            using var context = new IsSureciContext();

            // Rol ismi Member Olan üyelerin Join  sorgusu ile çekilmesi
            var result = context.Users.Join(context.UserRoles, x => x.Id, x => x.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles, y => y.userRole.RoleId, y => y.Id, (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole

                }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
                {
                    Id = x.user.Id,
                    Name = x.user.Name,
                    Surname = x.user.Surname,
                    Picture = x.user.Picture,
                    Email = x.user.Email,
                    UserName = x.user.UserName
                });

            //Toplam kullanıcı sayısını aldık
            toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(aranacakKelime))
            {
                result = result.Where(x => x.Name.ToLower().Contains(aranacakKelime.ToLower()) || x.Surname.ToLower().Contains(aranacakKelime.ToLower()));
                // Aranacak kelime üzerinden Toplam Sayfa sayısını da alacağız
                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);
            }

            //Pagination kısmı 3 tanesini alacak
            result = result.Skip((aktifSayfa - 1) * 3).Take(3);


            return result.ToList();
        }

        /* 
         
           select AspNetUsers.UserName , COUNT(Works.Id) from AspNetUsers inner join Works on AspNetUsers.Id = Works.AppUserId
  where Works.Status = 1 group by AspNetUsers.UserName 
         
         */

        public List<DualHelper> GetMostFinishedWorkUser()
        {
            using var context = new IsSureciContext();

            return context.Works.Include(x => x.AppUser)
                .Where(x => x.Status == true)
                .GroupBy(x => x.AppUser.UserName)
                .OrderByDescending(x=>x.Count())
                .Take(5)
                .Select(x=>new
                DualHelper
                { 
                    Name=x.Key,
                    WorkCount=x.Count()
                }).ToList();
        }

        // En çok görevde çalıaşn
        public List<DualHelper> GetMostTaskedUser()
        {
            using var context = new IsSureciContext();

            return context.Works.Include(x => x.AppUser)
                .Where(x => !x.Status && x.AppUserId !=null)
                .GroupBy(x => x.AppUser.UserName)
                .OrderByDescending(x => x.Count())
                .Take(5)
                .Select(x => new
                DualHelper
                {
                    Name = x.Key,
                    WorkCount = x.Count()
                }).ToList();
        }

    }
}
