using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Posttag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
        
    }
}
