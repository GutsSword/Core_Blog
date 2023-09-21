using AutoMapper;
using Core_Blog_Sitesi.ResultMessages;
using EntityLayer.Dtos.Categories;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceLayer.Extensions;
using ServiceLayer.Services.Abstraction;
using ServiceLayer.Services.Concrete;

namespace Core_Blog_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        public CategoryController(ICategoryService categoryService,IValidator<Category> validator,IMapper mapper,IToastNotification toastNotification)
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GettALlCategoriesNonDeleted();
            return View(categories);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);

            if(result.IsValid)
            {
               await categoryService.CreateCategoryAsync(categoryAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Categories.Add(categoryAddDto.Name), new ToastrOptions { Title="İşlem Başarılı"});
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
                result.AddToModelState(this.ModelState);

                return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);


            if (result.IsValid)
            {
                toastNotification.AddSuccessToastMessage(Messages.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarılı!" });
                await categoryService.CreateCategoryAsync(categoryAddDto);

                return Json(Messages.Categories.Add(categoryAddDto.Name));
            }
            else
            {
                toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "Başarısız!" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId);
            var map = mapper.Map<Category, CategoryUpdateDto>(category);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            var map = mapper.Map<Category>(categoryUpdateDto);
            var result = await validator.ValidateAsync(map);

            if(result.IsValid)
            {
                var name = await categoryService.UpdateCategoryAsync(categoryUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Categories.Add(categoryUpdateDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index","Category", new {Area="Admin"});
            }
            result.AddToModelState(this.ModelState);
            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var name = await categoryService.SafeDeleteCategoryAsync(categoryId);
            toastNotification.AddSuccessToastMessage(Messages.Delete(name), new ToastrOptions { Title = "Başarılı!" });
            await categoryService.SafeDeleteCategoryAsync(categoryId);

            return RedirectToAction("Index", "Category", new { Area = "Admin" });

        }
    }
}
