using AutoMapper;
using Core_Blog_Sitesi.Conts;
using Core_Blog_Sitesi.ResultMessages;
using EntityLayer.Dtos.Articles;
using EntityLayer.Dtos.Categories;
using EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceLayer.Services.Abstraction;

namespace Core_Blog_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toast;

        public ArticleController(IArticleService articleService,ICategoryService categoryService,IMapper mapper,IValidator<Article> validator,IToastNotification toast)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}, {RoleConsts.User}  ")]
        public async Task<IActionResult> Index()
        {
            var value=await articleService.GetAllArticleWithCategoryNonDeleteedAsync();
            return View(value);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedArticles()
        {
            var value = await articleService.GetAllArticlesWithCategoryDeletedAsync();
            return View(value);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> AddArticle( )
        {          
            var values = await categoryService.GettALlCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = values});
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> AddArticle(ArticleAddDto articleAddDto)
        {
            var map = mapper.Map<Article>(articleAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                toast.AddSuccessToastMessage(Messages.Add(articleAddDto.Title), new ToastrOptions { Title = "Başarılı!" });
                await articleService.CreateArticaleAsync(articleAddDto);
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {             
                result.AddToModelState(this.ModelState);
            }
            var values = await categoryService.GettALlCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = values });
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UpdateArticle(Guid articleId)
        {
            var values = await articleService.GetArticleWithCategoryNonDeleteedAsync(articleId);
            var categories=await categoryService.GettALlCategoriesNonDeleted();

            var articleupdatedto = mapper.Map<ArticleUpdateDto>(values);
            articleupdatedto.Categories = categories;

            return View(articleupdatedto);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            var map = mapper.Map<Article>(articleUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await articleService.UpdateArticleAsync(articleUpdateDto);
                toast.AddSuccessToastMessage(Messages.Update(articleUpdateDto.Title),new ToastrOptions {Title="Başarılı!" });
                await articleService.UpdateArticleAsync(articleUpdateDto);
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {               
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GettALlCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeleteArticle(Guid articleId)
        {
            var title = await articleService.SafeDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.Delete(title), new ToastrOptions { Title = "Başarılı!" });
            await articleService.SafeDeleteArticleAsync(articleId);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articleService.UndoDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage(Messages.UndoDelete(title), new ToastrOptions { Title = "Başarılı!" });

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }


    


    }
}
