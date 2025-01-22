using ASPNETCRUD.Data;
using ASPNETCRUD.Interfaces;
using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCRUD.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<ResponseDto<Category>> CreateCategory(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return new ResponseDto<Category>(true, "Category created successfully", category);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Category>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Category>> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return new ResponseDto<Category>(false, "Category not found");
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return new ResponseDto<Category>(true, "Category deleted successfully");
            }
            catch (Exception ex)
            {
                return new ResponseDto<Category>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<List<Category>>> GetAllCategorys()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                return new ResponseDto<List<Category>>(true, "Categorys retrieved successfully", categories);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<Category>>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Category>> GetCategoryById(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return new ResponseDto<Category>(false, "Category not found");
                }
                return new ResponseDto<Category>(true, "Category retrieved successfully", category);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Category>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Category>> UpdateCategory(int id, Category category)
        {
            try
            {
                var existingCategory = await _context.Categories.FindAsync(id);
                if (existingCategory == null)
                {
                    return new ResponseDto<Category>(false, "Category not found");
                }

                existingCategory.Name = category.Name;
                await _context.SaveChangesAsync();
                return new ResponseDto<Category>(true, "Category updated successfully", existingCategory);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Category>(false, ex.Message);
            }
        }
    }
}
