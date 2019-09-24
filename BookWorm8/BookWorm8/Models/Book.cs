using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm8.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public DateTime? PublishDate { get; set; }
        public List<Chapter> Chapters { get; set; }

        public List<AuthorBook> Authors { get; set; }
    }
}
