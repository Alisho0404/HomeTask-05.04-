using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Postmeta
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string? Key { get; set; }
        public string? Content { get; set; }
         
    }
}
