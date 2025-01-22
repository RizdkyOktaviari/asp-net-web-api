using ASPNETCRUD.Interfaces;
using ASPNETCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBookController : ControllerBase
    {
        private readonly IAuthorBookService _authorBookService;

        public AuthorBookController(IAuthorBookService authorBookService)
        {
            _authorBookService = authorBookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorBook>>> GetAuthorBooks()
        {
            var authorBooks = await _authorBookService.GetAllAuthorBooks();
            if (!authorBooks.Success) return BadRequest(authorBooks.Message);

            return Ok(authorBooks.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBook>> GetAuthorBook(int id)
        {
            var authorBook = await _authorBookService.GetAuthorBookById(id);
            if (!authorBook.Success) return BadRequest(authorBook.Message);

            return Ok(authorBook.Data);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorBook>> PostAuthorBook(AuthorBook authorBook)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
            var newAuthorBook = await _authorBookService.CreateAuthorBook(authorBook);

            if (!newAuthorBook.Success) return BadRequest(newAuthorBook.Message);
            return Ok(newAuthorBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorBook(int id, AuthorBook authorBook)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

            var updateAuthorBook = await _authorBookService.UpdateAuthorBook(id, authorBook);

            if (!updateAuthorBook.Success) return BadRequest(updateAuthorBook.Message);
            return Ok(updateAuthorBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorBook>> DeleteAuthorBook(int id)
        {
            var deleteAuthorBook = await _authorBookService.DeleteAuthorBook(id);

            if (!deleteAuthorBook.Success) return BadRequest(deleteAuthorBook.Message);
            return Ok(deleteAuthorBook);
        }
    }
}
