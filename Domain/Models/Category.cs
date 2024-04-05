using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        
    }
}
