using DataLayer.UnitOfWork;
using EntityLayer.Entities;
using ServiceLayer.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitofWork unitofWork;

        public DashboardService(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var article = await unitofWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted);

            var starDate = DateTime.Now.Date;
            starDate = new DateTime(starDate.Year, 1, 1); // 1.ayın 1.günü

            List<int> datas = new();

            for(int i = 1; i<=12; i++)
            {
                var startedDate = new DateTime(starDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = article.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }
            return datas;
        }
        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await unitofWork.GetRepository<Article>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await unitofWork.GetRepository<Category>().CountAsync();
            return categoryCount;
        }
    }
}
