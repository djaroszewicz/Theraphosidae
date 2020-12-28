using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.View.Report;
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

        public ReportController(UserManager<User> userManager, IReportService reportService, ICloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _reportService = reportService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReportView result)
        {
            var user = await _userManager.GetUserAsync(User);
            //var reportModel = 

            return RedirectToAction("List");
        }

    }
}
