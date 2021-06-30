using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Member.Controllers
{
    [Area("Member")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
  
        private readonly IReportService _reportService;

        private readonly UserManager<AppUser> _userManager;

        public WorkController(IWorkService workService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _workService = workService;
            _userManager = userManager;
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
 
            var works = _workService.GetAllWithTables(x => x.AppUserId==user.Id && x.Status == false);
            
            List<WorkListAllViewModel> models = new List<WorkListAllViewModel>();


            foreach (var item in works)
            {
                WorkListAllViewModel vm = new WorkListAllViewModel();

                vm.Id = item.Id;
                vm.Description = item.Description;
                vm.Level = item.Level;
                vm.WorkName = item.WorkName;
                vm.AppUser = item.AppUser;
                vm.Reports = item.Reports;
                vm.CreatedDate = item.CreatedDate;

                models.Add(vm);

            }

            return View(models);
        }


        public IActionResult AddReport(int id)
        {
            var work =  _workService.GetWithLevel(id);

            ReportAddViewModel model = new ReportAddViewModel();

            model.WorkId = id;
            model.Work = work;
            return View(model);
        }
    }
}
