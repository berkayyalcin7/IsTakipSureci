using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.DataAccess.Interfaces;
using IsTakipSureci.Entities.Concrete;
using IsTakipSureci.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakipSureci.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;

        private readonly ILevelService _levelService;

        public WorkController(IWorkService workService, ILevelService levelService)
        {
            _workService = workService;
            _levelService = levelService;
        }


        public IActionResult Index()
        {
            List<Work> works = _workService.GetLevelsStatusFalse();

            List<WorkListViewModel> workListViewModels = new List<WorkListViewModel>();

            foreach (var item in works)
            {
                WorkListViewModel workListViewModel = new WorkListViewModel()
                {
                    Id=item.Id,
                    WorkName=item.WorkName,
                    Description=item.Description,
                    Status=item.Status,
                    Level=item.Level,
                    LevelId=item.LevelId,
                    CreatedDate=item.CreatedDate
                };

                workListViewModels.Add(workListViewModel);
            }
           

            return View(workListViewModels);
        }

        public IActionResult WorkAdd()
        {
            ViewBag.Aciliyetler = new SelectList(_levelService.GetAll(),"Id","Tanim");

            return View(new WorkAddViewModel());
        }

        [HttpPost]
        public IActionResult WorkAdd(WorkAddViewModel workAddViewModel)
        {
            if (ModelState.IsValid)
            {
                _workService.Save(new Work()
                {
                    WorkName = workAddViewModel.WorkName,
                    Description = workAddViewModel.Description,
                    LevelId = workAddViewModel.LevelId
                });

                return RedirectToAction("Index");
            }

            return View(workAddViewModel);
        }

        public IActionResult WorkEdit(int id)
        {
            var work = _workService.GetById(id);
            WorkEditViewModel workEditViewModel = new WorkEditViewModel()
            {
                Id = work.Id,
                WorkName = work.WorkName,
                Description = work.Description,
                LevelId = work.LevelId
            };

            //Son Parametre seçili olarak gelecek değer
            ViewBag.Aciliyetler = new SelectList(_levelService.GetAll(), "Id", "Tanim",work.LevelId);

            return View(workEditViewModel);
        }

        [HttpPost]
        public IActionResult WorkEdit(WorkEditViewModel workEditViewModel)
        {
            if (ModelState.IsValid)
            {
                _workService.Update(new Work
                {
                    Id=workEditViewModel.Id,
                    WorkName=workEditViewModel.WorkName,
                    Description=workEditViewModel.Description,
                    LevelId=workEditViewModel.LevelId
                });

                return RedirectToAction("Index");
            }

            return View(workEditViewModel);
        }

        public IActionResult WorkRemove(int id)
        {
            _workService.Delete(new Work { Id = id });
            return Json(null);
        }



    }
}