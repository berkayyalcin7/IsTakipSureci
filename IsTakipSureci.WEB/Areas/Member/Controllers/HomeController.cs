using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipSureci.WEB.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IWorkService _workService;
        private readonly INotifyService _notifyService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager, IWorkService workService, INotifyService notifyService)
        {
            _reportService = reportService;
            _userManager = userManager;
            _workService = workService;
            _notifyService = notifyService;
        }

        /* 
         - İlgili kullanıcının yazdığı rapor sayısı
         - İlgili kullanıcının tamamladığı görevler
         - Bildirim sayısı
         - Tamamlanması gereken görev sayısı

         
         
         */
        public async Task<IActionResult> Index()
        {
            //Aktif olan kullanıcıyı getirme
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.ReportCount = _reportService.GetReportCountByUserId(user.Id);
            ViewBag.FinishedWorkCount = _workService.GetFinishWorkCountByUserId(user.Id);
            ViewBag.NotFinishWorkCount = _workService.GetWorkCountNotFinishByUserId(user.Id);
            ViewBag.UnReadNotifyCount = _notifyService.GetUnReadNotifyByUserId(user.Id);
            return View();
        }
    }
}