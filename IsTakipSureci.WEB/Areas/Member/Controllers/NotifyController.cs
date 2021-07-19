using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class NotifyController : Controller
    {
        private readonly INotifyService _notifyService;
        private readonly UserManager<AppUser> _userManager;

        public NotifyController(INotifyService notifyService, UserManager<AppUser> userManager)
        {
            _notifyService = notifyService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var notify = _notifyService.GetByStatus(user.Id);

            List<NotifyListViewModel> models = new List<NotifyListViewModel>();

            foreach (var item in notify)
            {
                NotifyListViewModel model = new NotifyListViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                models.Add(model);
            }
            return View(models);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var updatedNotify = _notifyService.GetById(id);
            updatedNotify.Status = true;
            _notifyService.Update(updatedNotify);

            return RedirectToAction("Index"); 
        }
    }
}
