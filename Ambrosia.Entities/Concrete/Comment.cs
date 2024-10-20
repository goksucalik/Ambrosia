﻿using Ambrosia.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.Entities.Concrete
{
    public class Comment:EntityBase
    {
        public string Text { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
