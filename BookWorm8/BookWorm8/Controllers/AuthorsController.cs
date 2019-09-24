using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext db;

        public AuthorsController(BookStoreDbContext db)
        {
            this.db = db;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var author = db.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post(Author author)
        {
            if (author.Id == default(Guid))
            {
                author.Id = Guid.NewGuid();
            }

            db.Authors.Add(author);
            db.SaveChanges();

            return NoContent();

        }
    }
}