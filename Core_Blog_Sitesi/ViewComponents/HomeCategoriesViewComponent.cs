using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstraction;

namespace Core_Blog_Sitesi.ViewComponents
{
    public class HomeCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GettALlCategoriesNonDeletedTake24();
            return View(categories);
        }

    }
}
