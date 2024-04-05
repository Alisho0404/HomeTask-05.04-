using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public required string Title { get; set; }
        public DateTime Published { get; set; }

    }
}
