using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entitites
{
    public abstract class EntityBase : IEntityBase
    {
        //public EntityBase()                  Constructor şeklinde de kullanılabilir.        
        //{
        //    Id = Guid.NewGuid();
        //    CreatedDate = DateTime.Now;
        //    IsDeleted = false;
        //}
               
        public virtual Guid Id { get; set; } = Guid.NewGuid(); // Her oluşturulduğunda yeni bir hashlenmiş ID değeri oluşturur.
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual string? ModifiedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;  //Default değer ataması
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false; //Default değer ataması
    }
}
