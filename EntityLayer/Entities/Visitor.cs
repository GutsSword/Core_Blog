using CoreLayer.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Visitor : IEntityBase
    {
     

        public Visitor()
        {
            
        }
        public Visitor(string ipAddress,string userAgent)
        {
            this.IpAddress = ipAddress;
            this.UserAgent = userAgent;
        }
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }

    }
}
