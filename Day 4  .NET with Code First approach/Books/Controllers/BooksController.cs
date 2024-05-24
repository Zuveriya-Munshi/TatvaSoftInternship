using Books.Data;
using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Books.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _booksContext;

        public BooksController(BookDbContext booksContext)
        {
            _booksContext = booksContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _booksContext.Books.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BookById(int id)
        {
            var book = await _booksContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

       

        [HttpPost]

        public async Task<ActionResult<Book>> AddBook(Book addBook)
        {
            if (string.IsNullOrEmpty(addBook.Title) || string.IsNullOrEmpty(addBook.Author))
            {
                return BadRequest("Name and description are required.");
            }


            await _booksContext.Books.AddAsync(addBook);
            await _booksContext.SaveChangesAsync();

            return Ok(addBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Enter correct Id");
            }
            _booksContext.Entry(book).State = EntityState.Modified;
            await _booksContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _booksContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _booksContext.Books.Remove(book);
            await _booksContext.SaveChangesAsync();
            return Ok(book);
        }
        
    }
}
