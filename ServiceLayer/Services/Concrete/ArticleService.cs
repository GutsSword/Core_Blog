using AutoMapper;
using DataLayer.UnitOfWork;
using EntityLayer.Dtos.Articles;
using EntityLayer.Entities;
using ServiceLayer.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceLayer.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitofWork unitofWork,IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        public async Task CreateArticaleAsync(ArticleAddDto articleAddDto)
        {
            var userId = Guid.Parse("6C7BF599-963F-47F3-B488-0218EA50FBEC");
            var values = new Article
            {
                Title = articleAddDto.Title,
                Content = articleAddDto.Content,
                CategoryId = articleAddDto.CategoryID,
                UserId = userId,
            };
            await unitofWork.GetRepository<Article>().AddAsync(values);
            await unitofWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticleWithCategoryNonDeleteedAsync()
        {
            var articles = await unitofWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted,x=>x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<ArticleDto> GetArticleWithCategoryNonDeleteedAsync(Guid articleId)
        {
            var article = await unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id==articleId , x=>x.Category);
            var map = mapper.Map<ArticleDto>(article);

            return map;
        }
        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);

            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryID;


            mapper.Map<ArticleUpdateDto>(article);
            await unitofWork.GetRepository<Article>().UpdateAsync(article);
            await unitofWork.SaveAsync();
        }
        public async Task SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await unitofWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedDate= DateTime.Now;
            await unitofWork.GetRepository<Article>().UpdateAsync(article);
            await unitofWork.SaveAsync();
        }
    }
}
