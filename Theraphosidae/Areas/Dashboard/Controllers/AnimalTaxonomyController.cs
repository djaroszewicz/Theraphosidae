using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.View.Spider;
using Theraphosidae.Infrastructure.Helpers;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class AnimalTaxonomyController : Controller
    {
        private readonly IAnimalTaxonomyService _animalTaxonomyService;
        
        public AnimalTaxonomyController(IAnimalTaxonomyService animalTaxonomyService)
        {
            _animalTaxonomyService = animalTaxonomyService;
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var animalTaxonomy = await _animalTaxonomyService.GetAll();
            return View(animalTaxonomy);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var model = await _animalTaxonomyService.Get(Id);
            return View(AnimalTaxonomyHelpers.ConvertToView(model));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnimalTaxonomyView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            await _animalTaxonomyService.Create(AnimalTaxonomyHelpers.ConvertToModel(result));
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var model = await _animalTaxonomyService.Get(Id);
            return View(AnimalTaxonomyHelpers.ConvertToView(model));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AnimalTaxonomyView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var model = await _animalTaxonomyService.Get(result.Id);
            var newModel = AnimalTaxonomyHelpers.MergeViewWithModel(model, result);

            await _animalTaxonomyService.Update(newModel);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            await _animalTaxonomyService.Delete(Id);
            return RedirectToAction("List");
        }

    }
}
