using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;
using Theraphosidae.Areas.Dashboard.Models.View.Spider;
using Theraphosidae.Infrastructure.Helpers;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class SpiderController : Controller
    {

        private readonly ISpiderService _spiderService;
        private readonly IAnimalTaxonomyService _animalTaxonomyService;
        private readonly ICloudinaryService _cloudinaryService;
        
        public SpiderController(ISpiderService spiderService, IAnimalTaxonomyService animalTaxonomyService,
            ICloudinaryService cloudinaryService)
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
        [Authorize(Roles = "moderator")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["AnimalTaxonomy"] = await _animalTaxonomyService.GetAll();

            return View();
        }

        [Authorize(Roles = "moderator")]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var spiderModel = await _spiderService.Get(Id);
            var animalTaxonomyModel = await _animalTaxonomyService.Get(spiderModel.AnimalTaxonomyId);

            return View(SpiderHelpers.ConvertSpiderAndAnimalTaxonomyToView(spiderModel, animalTaxonomyModel));

        }

        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<IActionResult> Edit(SpiderAnimalTaxonomyView result)
        {

            var spiderModel = await _spiderService.Get(result.Spider.Id);
            var animalTaxonomyModel = await _animalTaxonomyService.Get(spiderModel.AnimalTaxonomyId);

            var spiderUpdateModel = SpiderHelpers.MergeSpiderModelWitthView(spiderModel, result);
            var animalTaxonomyUpdateModel = SpiderHelpers.MergeAnimalTaxonomyModelWithView(animalTaxonomyModel, result);

            if(result.Spider.SpiderFileImg != null)
            {
                if (spiderModel.Image != null)
                {
                    _cloudinaryService.DeleteSpiderImage(spiderModel.Image.Id);
                }
                await _cloudinaryService.AddSpiderImage(result.Spider.SpiderFileImg, spiderModel.Id);

            }

            await _spiderService.Update(spiderUpdateModel, animalTaxonomyUpdateModel);

            return RedirectToAction("List");
        }

        [Authorize(Roles = "moderator")]
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

            await _spiderService.Create(spiderModel, animalTaxonomyId);

            await _cloudinaryService.AddSpiderImage(result.Spider.SpiderFileImg, spiderModel.Id);
   

            return RedirectToAction("List");
        }

        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var spider = await _spiderService.Get(id);

            if (spider.Image != null)
            {
                _cloudinaryService.DeleteSpiderImage(spider.Image.Id);
            }

            if(spider.AnimalTaxonomy != null)
            {
               await _animalTaxonomyService.Delete(spider.AnimalTaxonomyId);
            }

            await _spiderService.Delete(id);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> RandomSpider(string experience)
        {

            var spiders = await _spiderService.GetAll();
            List<SpiderModel> newSpiderList = new List<SpiderModel>();

            foreach(var spider in spiders)
            {
                if(spider.Experience == experience)
                {
                    newSpiderList.Add(spider);
                }
            }

            if(newSpiderList.Count == 0)
            {
                return RedirectToAction("List", "Spider");
            }

            Random rnd = new Random();
            int randomSpider = rnd.Next(newSpiderList.Count);


            return RedirectToAction("Details", "Spider", new { Id = newSpiderList[randomSpider].Id });
        }

    }
}
