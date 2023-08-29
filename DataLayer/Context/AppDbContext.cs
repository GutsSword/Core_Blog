using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext() //Boş Constructor
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  //Constructor boş ve options metodu eklenir ve <AppDbContext> Sonradan Eklenir.
        {
        }
        //Tablo tanımlamaları.
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        //Mapping işlemlerini tek seferde tanımlamak için kullanılır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
