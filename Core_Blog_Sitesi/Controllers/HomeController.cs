using Core_Blog_Sitesi.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstraction;
using System.Diagnostics;

namespace Core_Blog_Sitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            this.articleService = articleService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage=1, int pageSize=3, bool isAscending=false)
        {
            var articles = await articleService.GetAllByPageingAsync(categoryId,currentPage,pageSize, isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeleteedAsync(articleId);

            return View(article);
        }
    }
}