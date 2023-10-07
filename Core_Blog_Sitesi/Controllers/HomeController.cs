using Core_Blog_Sitesi.Models;
using DataLayer.UnitOfWork;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstraction;
using System.Diagnostics;

namespace Core_Blog_Sitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService articleService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitofWork unitofWork;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IHttpContextAccessor httpContextAccessor,IUnitofWork unitofWork)
        {
            _logger = logger;
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
           
            var articles = await articleService.GetAllByPageingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return RedirectToAction("Index"); // Örneğin, "Index" sayfasına yönlendirebilirsiniz. // Keyword değeri null veya boşsa, arama yapma ve önceki sayfaya yönlendirme veya istediğiniz işlemi yapma.

            }
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
        
        public async Task<IActionResult> Detail(Guid articleId)
        {
            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var articleVisitors = await unitofWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);
            var article = await unitofWork.GetRepository<Article>().GetAsync(x => x.Id == articleId);


            var result = await articleService.GetArticleWithCategoryNonDeleteedAsync(articleId);

            var visitor = await unitofWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            var addArticleVisitor = new ArticleVisitor(article.Id, visitor.Id);
            if (articleVisitors.Any(x => x.VisitorId == addArticleVisitor.VisitorId && x.ArticleId == addArticleVisitor.ArticleId))
                return View(result);
            else
            {
                await unitofWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitor);
                article.ViewCount += 1;
                await unitofWork.GetRepository<Article>().UpdateAsync(article);
                await unitofWork.SaveAsync();
            }

            return View(result);
        }
    }
}