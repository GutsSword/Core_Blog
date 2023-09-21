using EntityLayer.Dtos.Articles;
using EntityLayer.Dtos.Categories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Abstraction
{
    public interface ICategoryService
    {
       Task<List<CategoryDto>> GettALlCategoriesNonDeleted();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);

    }
}
