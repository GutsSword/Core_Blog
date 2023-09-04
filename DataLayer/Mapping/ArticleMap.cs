using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    //IEntityTypeCOnfiguration'dan miras almalı.Ardından İmplement edilir.
    //Tools -> CreateGuide ' dan Şifre oluştur.
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(
                new Article
                {
                    Id = Guid.NewGuid(),
                    Title = "Asp.net core ile geliştirme.",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    ViewCount = 15,
                    CategoryId = Guid.Parse("DD841DA1-EC1E-443B-AD5A-898C19EE804C"),
                    ImageId = Guid.Parse("76C98B1A-F03E-4899-93B5-60C572A693A2"),
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    UserId = Guid.Parse("6C7BF599-963F-47F3-B488-0218EA50FBEC"),
                },
                new Article
                {
                    Id = Guid.NewGuid(),
                    Title = "2.Asp.net core makale yazısı.",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    ViewCount = 15,
                    CategoryId = Guid.Parse("3685829A-17F6-4C06-83CA-DD689E2CDE8C"),
                    ImageId = Guid.Parse("574BBA9B-8033-4A4C-A2FA-A7755AFBABA0"),
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    UserId= Guid.Parse("71829B03-40EE-42D5-A62E-2827D34A02FA"),
                }
            );
        }
    }

}
