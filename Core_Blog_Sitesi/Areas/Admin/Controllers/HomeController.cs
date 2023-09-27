using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstraction;

namespace Core_Blog_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]  //Route Belirtilmesi Gerekiyor.
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
            
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticleWithCategoryNonDeleteedAsync();
           

            return View(articles);
        }
    }
}
