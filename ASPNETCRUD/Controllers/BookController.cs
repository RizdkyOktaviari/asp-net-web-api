using ASPNETCRUD.Interfaces;
using ASPNETCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();
            if (!books.Success) return BadRequest(books.Message);

            return Ok(books.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (!book.Success) return BadRequest(book.Message);

            return Ok(book.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
            var newBook = await _bookService.CreateBook(book);

            if (!newBook.Success) return BadRequest(newBook.Message);
            return Ok(newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

            var updateBook = await _bookService.UpdateBook(id, book);

            if (!updateBook.Success) return BadRequest(updateBook.Message);
            return Ok(updateBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var deleteBook = await _bookService.DeleteBook(id);

            if (!deleteBook.Success) return BadRequest(deleteBook.Message);
            return Ok(deleteBook);
        }
    }
}
