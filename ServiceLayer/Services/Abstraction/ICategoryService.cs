using EntityLayer.Dtos.Articles;
using EntityLayer.Dtos.Categories;
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
       
    }
}
