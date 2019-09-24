using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm8.Models
{
    public class Chapter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        [JsonIgnore]
        public Book Book { get; set; }
    }
}
