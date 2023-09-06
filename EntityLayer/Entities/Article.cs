using CoreLayer.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Article : EntityBase 
    {
        public Article()
        {
            //Boş 
        }
        public Article(string title, string content, Guid userId,string createdBy,Guid categoryId,Guid imageId)  //Parametre olarak createdBy ClaimsPrincible'da eklendi.
        {
            Title = title;
            Content = content;
            UserId= userId;
            CategoryId= categoryId; 
            ImageId= imageId;
            CreatedBy = createdBy;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

       public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
