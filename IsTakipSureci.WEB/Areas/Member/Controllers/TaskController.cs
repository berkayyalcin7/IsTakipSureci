using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : Controller
    {
        private readonly IWorkService _workService;
        private readonly UserManager<AppUser> _userManager;

        public TaskController(IWorkService workService, UserManager<AppUser> userManager)
        {
            _workService = workService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int activePage=1)
        {
          
            TempData["Active"] = "task";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            int pageSize;

            var tasks = _workService.GetAllWithTablesCompleted(out pageSize,user.Id,activePage);


            ViewBag.AktifSayfa = activePage;

            ViewBag.ToplamSayfa = pageSize;



            List<WorkListAllViewModel> models = new List<WorkListAllViewModel>();
            foreach (var task in tasks)
            {
                WorkListAllViewModel model = new WorkListAllViewModel();
                model.Id = task.Id;
                model.Description = task.Description;
                model.Level = task.Level;
                model.AppUser = task.AppUser;
                model.WorkName = task.WorkName;
                model.CreatedDate = task.CreatedDate;
                model.Reports = task.Reports;

                models.Add(model);
            }

            return View(models);
        }
    }
}
