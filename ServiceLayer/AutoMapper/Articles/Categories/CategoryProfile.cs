using AutoMapper;
using EntityLayer.Dtos.Categories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapper.Articles.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto,Category>().ReverseMap();
        }
    }
}
