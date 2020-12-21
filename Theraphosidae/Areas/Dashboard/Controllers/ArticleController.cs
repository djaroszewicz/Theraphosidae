using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.View.Article;
using Theraphosidae.Infrastructure.Helpers;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("dashboard")]
    [Route("dashboard/{controller}/{action=List}/{id?}")]
    public class ArticleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ICommentService _commentService;



        //private readonly ITagService _tagService;
        //private readonly ITaxonomyService _taxonomyService;
        //private readonly ICategoryService _categoryService;

        public ArticleController(UserManager<User> userManager, IArticleService articleService, ICloudinaryService cloudinaryService, ICommentService commentService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _cloudinaryService = cloudinaryService;
            _commentService = commentService;

            //_categoryService = categoryService;
            //_tagService = tagService;    
            //_taxonomyService = taxonomyService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var articleModel = await _articleService.Get(Id);
            await _articleService.IncrementArticleViews(Id);

            ViewData["Comment"] = await _commentService.GetAll();

            return View(ArticleHelpers.ConvertToDetailsView(articleModel));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var articles = await _articleService.GetAll();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //ViewBag.Categories = await _categoryService.GetAll();
            //ViewBag.Tags = await _tagService.GetAll();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleView result)
        {
            //if (await _articleService.CheckIfSlugExist(result.Slug))
            //{
            //    ModelState.AddModelError("", "Artykuł z tym linkiem już istnieje!");
            //}

            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Categories = await _categoryService.GetAll();
            //    ViewBag.Tags = await _tagService.GetAll();

            //    return View(result);
            //}

            var user = await _userManager.GetUserAsync(User);

            var articleModel = ArticleHelpers.ConvertToModel(result, user, "https://theraphosidae.pl");
            var article = await _articleService.Create(articleModel);
            if(article == false)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            var photo = await _cloudinaryService.AddFile(result.FeaturedImg, articleModel);

            //await _taxonomyService.SaveCategories(await _categoryService.GetCategoriesByName(result.Categories), articleModel);
            //await _taxonomyService.SaveTags(await _tagService.GetCategoriesByNames(result.Tags), articleModel);

            return RedirectToAction("List");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var article = await _articleService.Get(Id);

            if(article.Image != null)
            {
                _cloudinaryService.DeleteFile(article.Image.Id);
            }

            //if(article.Taxonomies.Count != 0)
            //{
            //    await _taxonomyService.Delete(Id);
            //}

            await _articleService.Delete(Id);


            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            //ViewBag.Categories = await _categoryService.GetAll();
            //ViewBag.Tags = await _tagService.GetAll();

            var articleModel = await _articleService.Get(Id);

            if(articleModel.User.UserName != User.Identity.Name)
            {
                return RedirectToAction("List", "Article");
            }

            var articleView = ArticleHelpers.ConvertToView(articleModel);

            return View(articleView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleView result)
        {
            var article = await _articleService.Get(result.Id);

            if(result.Slug != article.Slug)
            {
                //if(await _articleService.CheckIfSlugExist(result.Slug))
                //{
                //    ModelState.AddModelError("", "Artykuł o podanym linku nie istnieje");
                //}
            }

            //if(!ModelState.IsValid)
            //{
            //    ViewBag.Categories = await _categoryService.GetAll();
            //    ViewBag.Tags = await _tagService.GetAll();

            //    return View(result);
            //}

            if(result.FeaturedImg != null)
            {
                if(article.Image != null)
                {
                    _cloudinaryService.DeleteFile(article.Image.Id);
                }
                    var photo = await _cloudinaryService.AddFile(result.FeaturedImg);
                    article.Image = photo;
            }

            await _articleService.Update(ArticleHelpers.MergeViewWithModel(article, result, "https://theraphosidae.pl"));

            //await _taxonomyService.Delete(result.Id);

            //await _taxonomyService.SaveCategories(await _categoryService.GetCategoriesByName(result.Categories), article);

            //await _taxonomyService.SaveTags(await _tagService.GetCategoriesByNames(result.Tags), article);

            return RedirectToAction("List");
        }
    }
}
