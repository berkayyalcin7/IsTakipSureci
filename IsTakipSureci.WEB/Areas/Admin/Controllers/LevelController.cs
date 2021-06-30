using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipSureci.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class LevelController : Controller
    {

        private readonly ILevelService _levelService;
        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }


        public IActionResult Index()
        {
            List<Level> levels = _levelService.GetAll();

            List<LevelViewModel> model = new List<LevelViewModel>();

            foreach (var item in levels)
            {
                LevelViewModel levelVm = new LevelViewModel();
                levelVm.Id = item.Id;
                levelVm.Tanim = item.Tanim;

                model.Add(levelVm);

            }
            return View(model);
        }

        public IActionResult LevelAdd()
        {
            return View(new LevelAddViewModel());
        }

        [HttpPost]
        public IActionResult LevelAdd(LevelAddViewModel levelAddViewModel)
        {
            if (ModelState.IsValid)
            {
                _levelService.Save(new Level()
                {
                    Tanim = levelAddViewModel.Tanim

                });

                return RedirectToAction("Index");
            }

            return View();
            
        }
        public IActionResult LevelEdit(int id)
        {
            var level = _levelService.GetById(id);

            LevelEditViewModel levelEditViewModel = new LevelEditViewModel
            {
                Id = level.Id,
                Tanim = level.Tanim
            };

            return View(levelEditViewModel);


        }

        [HttpPost]
        public IActionResult LevelEdit(LevelEditViewModel levelEditViewModel)
        {
            if (ModelState.IsValid)
            {
                _levelService.Update(new Level
                {

                    Id = levelEditViewModel.Id,
                    Tanim = levelEditViewModel.Tanim


                });
                return RedirectToAction("Index");
            }
            return View(levelEditViewModel);
            
        }

    }
}