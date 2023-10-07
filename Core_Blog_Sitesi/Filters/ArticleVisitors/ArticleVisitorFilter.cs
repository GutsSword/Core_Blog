using DataLayer.UnitOfWork;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core_Blog_Sitesi.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IUnitofWork unitofWork;

        public ArticleVisitorFilter(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        //public  bool Disable { get; set; }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //if(Disable)
            //{
            //    return next();
            //}

            List<Visitor> visitors = unitofWork.GetRepository<Visitor>().GetAllAsync().Result;

            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

            Visitor visitor = new ( getIp, getUserAgent );

            if(visitors.Any(x=>x.IpAddress == visitor.IpAddress ))  //varsa nextle
            {
                return next();   
            }
            else
            {
                unitofWork.GetRepository<Visitor>().AddAsync(visitor);
                unitofWork.Save();
            }
            return next();

        }
    }
}
