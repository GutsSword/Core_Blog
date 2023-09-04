using AutoMapper;
using EntityLayer.Dtos.Articles;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstraction;

namespace Core_Blog_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public ArticleController(IArticleService articleService,ICategoryService categoryService,IMapper mapper)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var value=await articleService.GetAllArticleWithCategoryNonDeleteedAsync();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> AddArticle()
        {
            var values = await categoryService.GettALlCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = values});
        }
        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleAddDto articleAddDto)
        {
            await articleService.CreateArticaleAsync(articleAddDto);
            RedirectToAction("Index", "Article", new { Area = "Admin" });

            var values = await categoryService.GettALlCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = values });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateArticle(Guid articleId)
        {
            var values = await articleService.GetArticleWithCategoryNonDeleteedAsync(articleId);
            var categories=await categoryService.GettALlCategoriesNonDeleted();

            var articleupdatedto = mapper.Map<ArticleUpdateDto>(values);
            articleupdatedto.Categories = categories;

            return View(articleupdatedto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            await articleService.UpdateArticleAsync(articleUpdateDto);
            var categories = await categoryService.GettALlCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteArticle(Guid articleId)
        {
            await articleService.SafeDeleteArticleAsync(articleId);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });

        }
    }
}
