using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.View.Article;
using Theraphosidae.Infrastructure.Helpers;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class CommentController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICommentService _commentService;
        private readonly IArticleService _articleService;
        //private Task _articleService;

        public CommentController(UserManager<User> userManager, ICommentService commentService, IArticleService articleService)
        {
            _userManager = userManager;
            _commentService = commentService;
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var comment = await _commentService.Get(Id);
            await _commentService.Delete(Id);
            return RedirectToAction("Details", "Article", new { id = comment.ArticleId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleCommentView result)
        {

            var user = await _userManager.GetUserAsync(User);
            var articleId = result.Article.Id;
            var commentModel = ArticleHelpers.ConvertCommentToModel(result, user);
            var comment = await _commentService.Create(commentModel, articleId);
            return RedirectToAction("Details", "Article", new { id = articleId });
        }
    }
}
