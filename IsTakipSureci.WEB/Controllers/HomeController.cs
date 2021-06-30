using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;

namespace IsTakipSureci.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        IWorkService _workService;
        public HomeController(IWorkService workService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _workService = workService;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(AppUserLoginViewModel appUserLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                // UserName kontrolü yapacağız
                var user = await _userManager.FindByNameAsync(appUserLoginViewModel.UserName);

                if (user != null)
                {
                    // Lockout kısmını kapatıyoruz
                    var identityResult = await _signInManager.PasswordSignInAsync(appUserLoginViewModel.UserName, appUserLoginViewModel.Password, appUserLoginViewModel.RememberMe, false);

                    if (identityResult.Succeeded)
                    {
                        // Başarılı ise giriş yapıyoruz Role Göre Yönlendirme yapacağız
                        var roller = await _userManager.GetRolesAsync(user);

                        if (roller.Contains("Admin"))
                        {
                            // Area'yı belirtiyoruz.
                            return RedirectToAction("Index","Home",new { area="Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Giriş Yaptığınız Bilgiler Hatalıdır");
                }
            }
            // Index View'ı arayacak o yüzden gönderiyoruz.
            return View("Index", appUserLoginViewModel);
        }




        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(AppUserViewModel appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserViewModel.Username,
                    Email = appUserViewModel.Email,
                    Name = appUserViewModel.Name,
                    Surname = appUserViewModel.Surname,
                    
                };
                var result = await _userManager.CreateAsync(appUser, appUserViewModel.Password);


                if (result.Succeeded)
                {
                    // İşlem Başarılı ise 
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Member");
                    // Rol başarılımı kontrolü
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("");
                    }
                    foreach (var item in roleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}