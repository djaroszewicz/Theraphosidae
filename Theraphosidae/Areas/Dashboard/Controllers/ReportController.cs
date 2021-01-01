using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.View.Report;
using Theraphosidae.Infrastructure.Helpers;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Areas.Dashboard.Controllers
{

    [Authorize]
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class ReportController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IReportService _reportService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ISpiderService _spiderService;

        public ReportController(UserManager<User> userManager, IReportService reportService, ICloudinaryService cloudinaryService, ISpiderService spiderService)
        {
            _userManager = userManager;
            _reportService = reportService;
            _cloudinaryService = cloudinaryService;
            _spiderService = spiderService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["Spider"] = await _spiderService.GetAll();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var reports = await _reportService.GetAll();
            return View(reports);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewData["Spider"] = await _spiderService.GetAll();

            var report = await _reportService.Get(id);


            return View(ReportHelpers.ConvertToView(report));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReportView result)
        {
            var user = await _userManager.GetUserAsync(User);
            var reportModel = ReportHelpers.ConvertToModel(result, user);
            var report = await _reportService.Create(reportModel);
            if(report == false)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            var photo = await _cloudinaryService.AddReportImage(result.FormFileImg, reportModel.Id);

            return RedirectToAction("List");
        }

    }
}
