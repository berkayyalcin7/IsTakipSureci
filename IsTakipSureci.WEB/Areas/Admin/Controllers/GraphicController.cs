using IsTakipSureci.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _userService;

        public GraphicController(IAppUserService userService)
        {
            _userService = userService;
        }

        // En çok görev tamamlamış 5 personel 

        // En çok görev almış 5 personel

        /* 
          
        Group By ile sorgu
         
         */


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetMostTaskedData()
        {
            var jsonString = JsonConvert.SerializeObject(_userService.GetMostTaskedUser());

            return Json(jsonString);
        }

        public IActionResult GetMostFinishedWorkData()
        {
            var jsonString = JsonConvert.SerializeObject(_userService.GetMostFinishedWorkUser());

            return Json(jsonString);
        }
    }
}
