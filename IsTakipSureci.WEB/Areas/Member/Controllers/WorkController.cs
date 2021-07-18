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
    [Authorize(Roles ="Member")]
    [Area("Member")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;

        private readonly IReportService _reportService;

        private readonly UserManager<AppUser> _userManager;

        private readonly INotifyService _notifyService;

        public WorkController(IWorkService workService, UserManager<AppUser> userManager, IReportService reportService,INotifyService notifyService)
        {
            _workService = workService;
            _userManager = userManager;
            _reportService = reportService;
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var works = _workService.GetAllWithTables(x => x.AppUserId == user.Id && x.Status == false);

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
            var work = _workService.GetWithLevel(id);

            ReportAddViewModel model = new ReportAddViewModel();

            model.WorkId = id;
            model.Work = work;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    WorkId = model.WorkId,
                    ReportTitle = model.ReportTitle,
                    ReportDescription = model.ReportDescription
                });

                //Rolü admin olan kullanıcıları getir
                var adminList = await _userManager.GetUsersInRoleAsync("Admin");
                //İlgili kullanıcı
                var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (var admin in adminList)
                {
                    _notifyService.Save(new Notify
                    {
                        Description = $"{activeUser.Name} {activeUser.Surname} yeni bir rapor yazdı.. Rapor yazılma saati :{DateTime.Now.ToString("dddd, dd MMMM yyyy")}",
                        AppUserId=admin.Id,
                    });
                }


                return RedirectToAction("Index");
            }
            return View(model);
        }

        // İlgili raporu görevi ile birlikte getirmek gerekiyor
        public IActionResult UpdateReport(int id)
        {
            var report = _reportService.GetByWorkId(id);

            ReportUpdateViewModel model = new ReportUpdateViewModel();
            model.Id = report.Id;
            model.ReportTitle = report.ReportTitle;
            model.ReportDescription = report.ReportDescription;
            model.Work = report.Work;
            model.WorkId = report.WorkId;

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updatingReport = _reportService.GetById(model.Id);
                updatingReport.ReportTitle = model.ReportTitle;
                updatingReport.ReportDescription = model.ReportDescription;
                _reportService.Update(updatingReport);

                return RedirectToAction("Index");

            }


            return View(model);
        }

        // Görev Tamamlama Modali
        public async  Task<IActionResult> CompleteWork(int workId)
        {
            var updatingWork = _workService.GetById(workId);
            updatingWork.Status = true;
            _workService.Update(updatingWork);

            //Rolü admin olan kullanıcıları getir
            var adminList = await _userManager.GetUsersInRoleAsync("Admin");
            //İlgili kullanıcı
            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var admin in adminList)
            {
                _notifyService.Save(new Notify
                {
                    Description = $"{activeUser.Name} {activeUser.Surname} verilen görevi tamamladı. Tamamlama Saati : {DateTime.Now.ToString("dddd, dd MMMM yyyy")}",
                    AppUserId = admin.Id,
                });
            }

            // Content dönmeyeceğiz.
            return Json(null);
        }





    }
}
