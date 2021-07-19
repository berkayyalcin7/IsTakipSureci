using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace IsTakipSureci.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class WorkOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IWorkService _workService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly INotifyService _notifyService;
        public WorkOrderController(IAppUserService appUserService, IWorkService workService, UserManager<AppUser> userManager, IFileService fileService,INotifyService notifyService)
        {
            _appUserService = appUserService;
            _workService = workService;
            _userManager = userManager;
            _fileService = fileService;
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            List<Work> works = _workService.GetAllWithTables();

            List<WorkListAllViewModel> workModels = new List<WorkListAllViewModel>();

            foreach (var item in works)
            {
                WorkListAllViewModel workListAllViewModel = new WorkListAllViewModel();
                workListAllViewModel.Id = item.Id;
                workListAllViewModel.Description = item.Description;
                workListAllViewModel.WorkName = item.WorkName;
                workListAllViewModel.Level = item.Level;
                workListAllViewModel.Reports = item.Reports;
                workListAllViewModel.CreatedDate = item.CreatedDate;
                workListAllViewModel.AppUser = item.AppUser;

                workModels.Add(workListAllViewModel);
            }

            return View(workModels);

        }

        //id görev ID
        public IActionResult PersonalAssign(int id,string search,int sayfa=1)
        {

            ViewBag.AktifSayfa = sayfa;

            ViewBag.ArananDeger = search;

            int toplamSayfa;
           

            var model = _workService.GetWithLevel(id);

            var personeller = _appUserService.GetAllMemberUser(out toplamSayfa,search,sayfa);

            ViewBag.ToplamSayfa = toplamSayfa;

            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();

            foreach (var item in personeller)
            {
                AppUserListViewModel appUser = new AppUserListViewModel();
                appUser.Id = item.Id;
                appUser.Name = item.Name;
                appUser.Surname = item.Surname;
                appUser.Picture = item.Picture;
                appUser.Email = item.Email;
                appUserListModel.Add(appUser);
            }

            ViewBag.Personeller = appUserListModel;


            WorkListViewModel workListViewModel = new WorkListViewModel();
            workListViewModel.Id = model.Id;
            workListViewModel.WorkName = model.WorkName;
            workListViewModel.Description = model.Description;
            workListViewModel.CreatedDate = model.CreatedDate;
            workListViewModel.Level = model.Level;
            

            return View(workListViewModel);
        }

        [HttpPost]
        public IActionResult PersonalAssign(PersonalAssignViewModel personalAssignViewModel)
        {
            var updatedWork = _workService.GetById(personalAssignViewModel.WorkId);
            updatedWork.AppUserId = personalAssignViewModel.AppUserId;

            _notifyService.Save(new Notify
            {
                AppUserId=personalAssignViewModel.AppUserId,
                Description=$" '{updatedWork.WorkName}'  adlı iş için görevlendirildiniz."
            });


            _workService.Update(updatedWork);

            return RedirectToAction("Index");
        }


        //Görevleri ve personelleri listelediğimiz alan
        public IActionResult WorkPersonalAssign(PersonalAssignViewModel personalAssignViewModel)
        {

            var user = _userManager.Users.FirstOrDefault(x => x.Id == personalAssignViewModel.AppUserId);

            var work = _workService.GetWithLevel(personalAssignViewModel.WorkId);

            AppUserListViewModel appUserListViewModel = new AppUserListViewModel();
            appUserListViewModel.Id = user.Id;
            appUserListViewModel.Name = user.Name;
            appUserListViewModel.Surname = user.Surname;
            appUserListViewModel.Picture = user.Picture;
            appUserListViewModel.Email = user.Email;

            WorkListViewModel workListViewModel = new WorkListViewModel();
            workListViewModel.Id = work.Id;
            workListViewModel.WorkName = work.WorkName;
            workListViewModel.Description = work.Description;
            workListViewModel.Level = work.Level;

            PersonalAssignListViewModel pvm = new PersonalAssignListViewModel();
            pvm.AppUser = appUserListViewModel;
            pvm.Work = workListViewModel;

            return View(pvm);
        }

        // İlgili Görev id'si
        public IActionResult Detail(int id)
        {
            var work = _workService.GetWithReport(id);

            WorkListAllViewModel workListAllViewModel = new WorkListAllViewModel();

            workListAllViewModel.Id = work.Id;
            workListAllViewModel.WorkName = work.WorkName;
            workListAllViewModel.Description = work.Description;
            workListAllViewModel.Reports = work.Reports;
            workListAllViewModel.AppUser = work.AppUser;

            return View(workListAllViewModel);
        }

        public IActionResult GetExcel(int id)
        {
            var file = _fileService.ExcelConvert(_workService.GetWithReport(id).Reports);

            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",Guid.NewGuid()+".xlsx");
        }

        public IActionResult GetPdf(int id)
        {
            var path = _fileService.PdfConvert(_workService.GetWithReport(id).Reports);

            return File(path,"application/pdf",Guid.NewGuid()+".pdf");
        }
    }
}