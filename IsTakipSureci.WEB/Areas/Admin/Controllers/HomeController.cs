using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipSureci.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IWorkService _workService;
        private readonly INotifyService _notifyService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IReportService reportService, IWorkService workService, INotifyService notifyService, UserManager<AppUser> userManager)
        {
            _reportService = reportService;
            _workService = workService;
            _notifyService = notifyService;
            _userManager = userManager;
        }





        /* 
         
         - Atanmayı bekleyen Görev S
         - Tamamlanan Görev S
         - Bildirim S
         - Toplam Rapor Sayısı
         
         
         */

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.NotAssignWorkCount = _workService.GetNotAssignWorkCount();
            ViewBag.FinishedWorkCount = _workService.GetFinishedWorkCount();
            ViewBag.UnReadNotifyCount = _notifyService.GetUnReadNotifyByUserId(user.Id);
            ViewBag.ReportCount = _reportService.GetReportCount();

            return View();
        }
    }
}