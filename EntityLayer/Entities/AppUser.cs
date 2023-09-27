using CoreLayer.Entitites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AppUser : IdentityUser<Guid> , IEntityBase //Guid olduğunu belirtmek için key değeri atandı.
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("d2929c7b-b265-4f59-b3f0-6cc6e96cfc85");
        public Image Image { get; set; } 
        public ICollection<Article> Articles { get; set; }
    }
}
