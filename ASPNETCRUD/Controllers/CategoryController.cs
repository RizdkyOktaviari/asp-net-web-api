using ASPNETCRUD.Interfaces;
using ASPNETCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        {
            var categorys = await _categoryService.GetAllCategorys();
            if (!categorys.Success) return BadRequest(categorys.Message);

            return Ok(categorys.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (!category.Success) return BadRequest(category.Message);

            return Ok(category.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
            var newCategory = await _categoryService.CreateCategory(category);

            if (!newCategory.Success) return BadRequest(newCategory.Message);
            return Ok(newCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

            var updateCategory = await _categoryService.UpdateCategory(id, category);

            if (!updateCategory.Success) return BadRequest(updateCategory.Message);
            return Ok(updateCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var deleteCategory = await _categoryService.DeleteCategory(id);

            if (!deleteCategory.Success) return BadRequest(deleteCategory.Message);
            return Ok(deleteCategory);
        }
    }
}
