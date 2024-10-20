using Ambrosia.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ambrosia.Entities.Concrete
{
    public class Product:EntityBase
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public int CommentCount { get; set; } = 0;
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Basket> Basket { get; set; }
    }
}
