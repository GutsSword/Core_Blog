using AutoMapper;
using DataLayer.UnitOfWork;
using EntityLayer.Dtos.Articles;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
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
    public class ArticleService : IArticleService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;
        public ArticleService(IUnitofWork unitofWork,IMapper mapper,IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;  // Claims Princibal
            this.imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;   //Kullanımı kolaylaştırmak için burada tanımlanır.Claims Princibal
        }

        public async Task CreateArticaleAsync(ArticleAddDto articleAddDto)
        {

            var userId = _user.GetLoggedInUserId();  // Claims Princibal
            var userMail = _user.GetLoggedInMail();   // Claims Princibal

            //var imageId = Guid.Parse("76c98b1a-f03e-4899-93b5-60c572a693a2");

            var imageUpload = await imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post); //Image Helper
            Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userMail);//Image Helper
            await unitofWork.GetRepository<Image>().AddAsync(image);

            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, userMail, articleAddDto.CategoryID, image.Id);
            await unitofWork.GetRepository<Article>().AddAsync(article);
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
            var article = await unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id==articleId , x=>x.Category, i=>i.Image,u=>u.User);
            var map = mapper.Map<ArticleDto>(article);

            return map;
        }
        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {

            var userEmail = _user.GetLoggedInMail(); // Claims Princibal
            var article = await unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category,i=>i.Image);

            if(articleUpdateDto.Photo!=null)
            {
                imageHelper.Delete(article.Image.FileName);

                var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                Image image = new Image(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
                await unitofWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;
            }

            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryID;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;


            mapper.Map<ArticleUpdateDto>(article);
            await unitofWork.GetRepository<Article>().UpdateAsync(article);
            await unitofWork.SaveAsync();

            return article.Title; //KRİTİK MEVZU BURAYA DÖN.
        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail=_user.GetLoggedInMail();
            var article = await unitofWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedDate= DateTime.Now;
            article.DeletedBy = userEmail;
            await unitofWork.GetRepository<Article>().UpdateAsync(article);
            await unitofWork.SaveAsync();

            return article.Title; //KRİTİK MEVZU BURAYA DÖN.
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var articles = await unitofWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInMail();
            var article = await unitofWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await unitofWork.GetRepository<Article>().UpdateAsync(article);
            await unitofWork.SaveAsync();

            return article.Title; //KRİTİK MEVZU BURAYA DÖN.
        }

        public async Task<ArticleListDto> GetAllByPageingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == null
                ? await unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category, i => i.Image, u=> u.User)
                : await unitofWork.GetRepository<Article>().GetAllAsync(x => x.CategoryId == categoryId && !x.IsDeleted, a=>a.Category, i=> i.Image , u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() //Eskiden Yeniye
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = await unitofWork.GetRepository<Article>().GetAllAsync
                (x => !x.IsDeleted && (x.Title.Contains(keyword) || x.Category.Name.Contains(keyword)),
                x => x.Category, i => i.Image, u => u.User);
                
            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() //Eskiden Yeniye
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }
    }
}
