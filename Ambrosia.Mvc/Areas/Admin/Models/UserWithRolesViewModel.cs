﻿using Ambrosia.Entities.Concrete;

namespace Ambrosia.Mvc.Areas.Admin.Models
{
    public class UserWithRolesViewModel
    {
        public User User { get; set; }
        public IList<string> Roles { get; set; }

    }
}
