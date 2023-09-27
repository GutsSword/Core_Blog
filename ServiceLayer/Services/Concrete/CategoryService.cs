using AutoMapper;
using DataLayer.UnitOfWork;
using EntityLayer.Dtos.Categories;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Extensions;
using ServiceLayer.Helper.Images;
using ServiceLayer.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;
        private readonly object httpContextAccessor;
        private ClaimsPrincipal _user;

        public CategoryService(IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;  // Claims Princibal
            _user = httpContextAccessor.HttpContext.User;   //Kullanımı kolaylaştırmak için burada tanımlanır.Claims Princibal

        }
        public async Task<List<CategoryDto>> GettALlCategoriesNonDeleted()
        {
            var categories = await unitofWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map;
        }
        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = _user.GetLoggedInMail();

            Category category = new(categoryAddDto.Name, userEmail);

            await unitofWork.GetRepository<Category>().AddAsync(category);
            await unitofWork.SaveAsync();
        }
        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await unitofWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }
        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInMail();
            var category = await unitofWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);

            category.Name = categoryUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.CreatedDate = DateTime.Now;

            await unitofWork.GetRepository<Category>().UpdateAsync(category);
            await unitofWork.SaveAsync();

            return category.Name;
        }
        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {

            var userEmail = _user.GetLoggedInMail();
            var category = await unitofWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            await unitofWork.GetRepository<Category>().UpdateAsync(category);
            await unitofWork.SaveAsync();

            return category.Name;
        }

        public async Task<List<CategoryDto>> GetALlCategoriesDeleted()
        {
            var categories = await unitofWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
        {
            
            var category = await unitofWork.GetRepository<Category>().GetByGuidAsync(categoryId);

            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;
            await unitofWork.GetRepository<Category>().UpdateAsync(category);
            await unitofWork.SaveAsync();

            return category.Name;
        }
    }
}