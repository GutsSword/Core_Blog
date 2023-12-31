﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230829175455_SeedCompleted")]
    partial class SeedCompleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("650317a5-5a17-47fc-94bd-7c6c3a0a9e34"),
                            CategoryId = new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(7877),
                            ImageId = new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                            IsDeleted = false,
                            Title = "Asp.net core ile geliştirme.",
                            ViewCount = 15
                        },
                        new
                        {
                            Id = new Guid("1225059f-c356-49c6-8472-be86ba67cd0d"),
                            CategoryId = new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(7884),
                            ImageId = new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                            IsDeleted = false,
                            Title = "2.Asp.net core makale yazısı.",
                            ViewCount = 15
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dd841da1-ec1e-443b-ad5a-898c19ee804c"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8157),
                            IsDeleted = false,
                            Name = "Kategori1"
                        },
                        new
                        {
                            Id = new Guid("3685829a-17f6-4c06-83ca-dd689e2cde8c"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8161),
                            IsDeleted = false,
                            Name = "Kategori2"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("76c98b1a-f03e-4899-93b5-60c572a693a2"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8285),
                            FileName = "Images/TestImage",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("574bba9b-8033-4a4c-a2fa-a7755afbaba0"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2023, 8, 29, 20, 54, 55, 483, DateTimeKind.Local).AddTicks(8289),
                            FileName = "Images/TestImage",
                            FileType = "jpg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Article", b =>
                {
                    b.HasOne("EntityLayer.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("EntityLayer.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("EntityLayer.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
