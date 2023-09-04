using AutoMapper;
using DataLayer.UnitOfWork;
using EntityLayer.Dtos.Categories;
using EntityLayer.Entities;
using ServiceLayer.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitofWork unitofWork,IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public async Task<List<CategoryDto>> GettALlCategoriesNonDeleted()
        {
            var categories = await unitofWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
    }
}
