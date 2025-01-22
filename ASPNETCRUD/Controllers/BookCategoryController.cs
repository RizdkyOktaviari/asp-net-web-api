using ASPNETCRUD.Interfaces;
using ASPNETCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategory>>> GetBookCategorys()
        {
            var bookCategorys = await _bookCategoryService.GetAllBookCategorys();
            if (!bookCategorys.Success) return BadRequest(bookCategorys.Message);

            return Ok(bookCategorys.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookCategory>> GetBookCategory(int id)
        {
            var bookCategory = await _bookCategoryService.GetBookCategoryById(id);
            if (!bookCategory.Success) return BadRequest(bookCategory.Message);

            return Ok(bookCategory.Data);
        }

        [HttpPost]
        public async Task<ActionResult<BookCategory>> PostBookCategory(BookCategory bookCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
            var newBookCategory = await _bookCategoryService.CreateBookCategory(bookCategory);

            if (!newBookCategory.Success) return BadRequest(newBookCategory.Message);
            return Ok(newBookCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookCategory(int id, BookCategory bookCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

            var updateBookCategory = await _bookCategoryService.UpdateBookCategory(id, bookCategory);

            if (!updateBookCategory.Success) return BadRequest(updateBookCategory.Message);
            return Ok(updateBookCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookCategory>> DeleteBookCategory(int id)
        {
            var deleteBookCategory = await _bookCategoryService.DeleteBookCategory(id);

            if (!deleteBookCategory.Success) return BadRequest(deleteBookCategory.Message);
            return Ok(deleteBookCategory);
        }
    }
}
