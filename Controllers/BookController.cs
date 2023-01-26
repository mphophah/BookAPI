using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    // API Controller
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BooksDbContext _context;
        public BookController(BooksDbContext context)
        {
            _context = context;
        }

        // GET all books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Books.ToList());
        }

        // GET a specific book by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST a new book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        // PUT (update) a specific book by id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            var existingBook = _context.Books.Find(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Pages = book.Pages;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE a specific book by id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
