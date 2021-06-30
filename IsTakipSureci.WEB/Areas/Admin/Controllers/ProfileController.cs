using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipSureci.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profil";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            AppUserListViewModel appUserListViewModel = new AppUserListViewModel();

            appUserListViewModel.Id = user.Id;
            appUserListViewModel.Name = user.Name;
            appUserListViewModel.Surname = user.Surname;
            appUserListViewModel.Picture = user.Picture;
            appUserListViewModel.Email = user.Email;


            return View(appUserListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile Resim)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekUser = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (Resim != null)
                {
                    string uzantı = Path.GetExtension(Resim.FileName);
                    string resimAd = Guid.NewGuid() + uzantı;

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + resimAd);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Resim.CopyToAsync(stream);
                    }
                    guncellenecekUser.Picture = resimAd;

                }
                guncellenecekUser.Name = model.Name;
                guncellenecekUser.Surname = model.Surname;
                guncellenecekUser.Email = model.Email;

                var result =await _userManager.UpdateAsync(guncellenecekUser);

                if (result.Succeeded)
                {
                    TempData["Mesaj"] = "Güncelleme İşlemi Başarılı";

                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
    }
}