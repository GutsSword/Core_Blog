using EntityLayer.Dtos.Articles;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Abstraction
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticleWithCategoryNonDeleteedAsync();
        Task<ArticleDto> GetArticleWithCategoryNonDeleteedAsync(Guid articleId);
        Task CreateArticaleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
    }
}
