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

        [Authorize(Roles = "moderator")]
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
            await _reportService.IncrementReportViews(id);

            return View(ReportHelpers.ConvertToView(report));
        }

        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<IActionResult> Add(ReportView result)
        {
            if (result.SpiderId == 0 || result.ReportCategory == "null")
            {
                return RedirectToAction("List");
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);
                var reportModel = ReportHelpers.ConvertToModel(result, user);
                var report = await _reportService.Create(reportModel);
                if (report == false)
                {
                    return RedirectToAction("Index", "Dashboard");
                }

                await _cloudinaryService.AddReportImage(result.FormFileImg, reportModel.Id);
            }
            return RedirectToAction("List");
        }

        [Authorize(Roles = "moderator")]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var reportModel = await _reportService.Get(Id);

            var reportView = ReportHelpers.ConvertToView(reportModel);
            ViewData["Spider"] = await _spiderService.GetAll();

            return View(reportView);
        }

        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<IActionResult> Edit(ReportView result)
        {
            var report = await _reportService.Get(result.Id);


            if (result.FormFileImg != null)
            {
                if (report.ReportImage != null)
                {
                    _cloudinaryService.DeleteFile(report.ReportImage.Id);
                }
                var photo = await _cloudinaryService.AddReportImage(result.FormFileImg, report.Id);
            }

            await _reportService.Update(ReportHelpers.MergeViewWithModel(report, result));

            return RedirectToAction("List");
        }

        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _reportService.Get(id);

            if (report.ReportImage != null)
            {
                _cloudinaryService.DeleteSpiderImage(report.ReportImage.Id);
            }

            await _reportService.Delete(id);

            return RedirectToAction("List");
        }

    }
}
