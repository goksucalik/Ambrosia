using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.Entities.Concrete
{
    public class User:IdentityUser<int>
    {
        public string Picture { get; set; }
        public string About { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Basket> Basket { get; set; }
    }
}
