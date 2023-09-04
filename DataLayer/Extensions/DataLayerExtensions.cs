using DataLayer.Context;
using DataLayer.Repositories.Abstractions;
using DataLayer.Repositories.Concretes;
using DataLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>)); // IRespository'e bir istekte bulunduğumda bana Repository döndürsün.
            //Interfacelerin Scope edilmesi gerekiyor.

            //Aşşağıdaki Kod Bloğu Koleksiyon içine Context sınıfını alır(AppDbContext) ve Parametre olarak DefaultConnection olarak appsetting.json'da
            //tanımlanan yapıyı alır.
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitofWork, UnitofWork>();


            return services;

        }
    }
}
