using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm8.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }

        public List<AuthorBook> Books { get; set; }
    }

    public class AuthorBook
    {
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }

}
