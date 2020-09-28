using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;

namespace Theraphosidae.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class ArticleController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ArticleController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
