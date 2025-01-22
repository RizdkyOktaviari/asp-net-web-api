using ASPNETCRUD.Interfaces;
using ASPNETCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            if (!authors.Success) return BadRequest(authors.Message);

            return Ok(authors.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorById(id);
            if (!author.Success) return BadRequest(author.Message);

            return Ok(author.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
            var newAuthor = await _authorService.CreateAuthor(author);

            if (!newAuthor.Success) return BadRequest(newAuthor.Message);
            return Ok(newAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

            var updateAuthor = await _authorService.UpdateAuthor(id, author);

            if (!updateAuthor.Success) return BadRequest(updateAuthor.Message);
            return Ok(updateAuthor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var deleteAuthor = await _authorService.DeleteAuthor(id);

            if (!deleteAuthor.Success) return BadRequest(deleteAuthor.Message);
            return Ok(deleteAuthor);
        }
    }
}
