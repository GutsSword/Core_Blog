using EntityLayer.Dtos.Categories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.Articles
{
    public class ArticleAddDto
    {
        public  string Title { get; set; }
        public  string Content { get; set; }
        public Guid CategoryID { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
