using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.View.Spider;
using Theraphosidae.Infrastructure.Helpers;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Areas.Dashboard.Controllers
{
    //[Authorize(Roles = "user")]
    [Authorize]
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class SpiderController : Controller
    {

        private readonly ISpiderService _spiderService;
        private readonly IAnimalTaxonomyService _animalTaxonomyService;
        private readonly ICloudinaryService _cloudinaryService;
        
        public SpiderController(ISpiderService spiderService, IAnimalTaxonomyService animalTaxonomyService, ICloudinaryService cloudinaryService)
        {
            _spiderService = spiderService;
            _animalTaxonomyService = animalTaxonomyService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var spiders = await _spiderService.GetAll();
            return View(spiders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var spiderModel = await _spiderService.Get(Id);
            var animalTaxonomyModel = await _animalTaxonomyService.Get(spiderModel.AnimalTaxonomyId);

            return View(SpiderHelpers.ConvertSpiderAndAnimalTaxonomyToView(spiderModel, animalTaxonomyModel));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["AnimalTaxonomy"] = await _animalTaxonomyService.GetAll();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var spiderModel = await _spiderService.Get(Id);
            var animalTaxonomyModel = await _animalTaxonomyService.Get(spiderModel.AnimalTaxonomyId);

            return View(SpiderHelpers.ConvertSpiderAndAnimalTaxonomyToView(spiderModel, animalTaxonomyModel));

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SpiderAnimalTaxonomyView result)
        {

            var spiderModel = await _spiderService.Get(result.Spider.Id);
            var animalTaxonomyModel = await _animalTaxonomyService.Get(spiderModel.AnimalTaxonomyId);

            var spiderUpdateModel = SpiderHelpers.MergeSpiderModelWitthView(spiderModel, result);
            var animalTaxonomyUpdateModel = SpiderHelpers.MergeAnimalTaxonomyModelWithView(animalTaxonomyModel, result);


            await _spiderService.Update(spiderUpdateModel, animalTaxonomyUpdateModel);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpiderAnimalTaxonomyView result)
        {
            if(!ModelState.IsValid)
            {
                ViewData["AnimalTaxonomy"] = await _animalTaxonomyService.GetAll();

                return View(result);
            }

            var spiderModel = SpiderHelpers.ConvertSpiderToModel(result);

            var animalTaxonomyModel = SpiderHelpers.ConvertAnimalTaxonomyToModel(result);

            await _animalTaxonomyService.Create(animalTaxonomyModel);
            var animalTaxonomyId = animalTaxonomyModel.Id;

            //await _cloudinaryService.AddFile

            await _spiderService.Create(spiderModel, animalTaxonomyId);

            await _cloudinaryService.AddSpiderImage(result.Spider.SpiderFileImg, spiderModel.Id);

            //var spiderModel = SpiderHelpers.ConvertToModel(result);
            //var animalTaxonomyModel = AnimalTaxonomyHelpers.ConvertToModel(resultAnimalTaxonomy);

            //await _animalTaxonomyService.Create(animalTaxonomyModel);
            //var animalTaxonomyId = animalTaxonomyModel.Id;

            //await _spiderService.Create(spiderModel, animalTaxonomyId);
            

            return RedirectToAction("List");
        }

    }
}
