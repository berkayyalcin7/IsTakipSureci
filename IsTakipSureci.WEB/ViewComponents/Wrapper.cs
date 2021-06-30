using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        // Giriş Yapmış kullanıcıyı alacağız

        private readonly UserManager<AppUser> _userManager;

        //DI aracılığıyla örnek
        public Wrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            // Await kullanamayız
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            AppUserListViewModel model = new AppUserListViewModel();

            model.Id = user.Id;
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Picture = user.Picture;
            model.Email = user.Email;
            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Admin"))
            {
                return View(model);
            }
       
            return View("Member",model);
        }
    }
}
