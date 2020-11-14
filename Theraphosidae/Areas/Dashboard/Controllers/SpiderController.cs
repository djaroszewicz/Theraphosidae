﻿using System;
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
    //[Authorize(Roles = "user")]
    [Authorize]
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class SpiderController : Controller
    {

        private readonly ISpiderService _spiderService;
        private readonly IAnimalTaxonomyService _animalTaxonomyService;
        
        public SpiderController(ISpiderService spiderService, IAnimalTaxonomyService animalTaxonomyService)
        {
            _spiderService = spiderService;
            _animalTaxonomyService = animalTaxonomyService;
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
            var model = await _spiderService.Get(Id);
            return View(SpiderHelpers.ConvertToView(model));
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
            var model = await _spiderService.Get(Id);
            ViewData["AnimalTaxonomy"] = await _animalTaxonomyService.GetAll();

            return View(SpiderHelpers.ConvertToView(model));

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

            await _spiderService.Create(spiderModel, animalTaxonomyId);

            //var spiderModel = SpiderHelpers.ConvertToModel(result);
            //var animalTaxonomyModel = AnimalTaxonomyHelpers.ConvertToModel(resultAnimalTaxonomy);

            //await _animalTaxonomyService.Create(animalTaxonomyModel);
            //var animalTaxonomyId = animalTaxonomyModel.Id;

            //await _spiderService.Create(spiderModel, animalTaxonomyId);
            

            return RedirectToAction("List");
        }

    }
}