﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PostCategory
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        
    }
}
