using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipSureci.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
      


        public async Task<IActionResult> Index()
        {
          

            return View();
        }
    }
}