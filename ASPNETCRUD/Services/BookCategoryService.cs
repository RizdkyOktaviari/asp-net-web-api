using ASPNETCRUD.Data;
using ASPNETCRUD.Interfaces;
using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCRUD.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly AppDbContext _context;
        public BookCategoryService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<ResponseDto<BookCategory>> CreateBookCategory(BookCategory bookCategory)
        {
            try
            {
                await _context.BookCategories.AddAsync(bookCategory);
                await _context.SaveChangesAsync();
                return new ResponseDto<BookCategory>(true, "BookCategory created successfully", bookCategory);
            }
            catch (Exception ex)
            {
                return new ResponseDto<BookCategory>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<BookCategory>> DeleteBookCategory(int id)
        {
            try
            {
                var bookCategory = await _context.BookCategories.FindAsync(id);
                if (bookCategory == null)
                {
                    return new ResponseDto<BookCategory>(false, "BookCategory not found");
                }
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
                return new ResponseDto<BookCategory>(true, "BookCategory deleted successfully");
            }
            catch (Exception ex)
            {
                return new ResponseDto<BookCategory>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<List<BookCategory>>> GetAllBookCategorys()
        {
            try
            {
                var bookCategories = await _context.BookCategories
                    .Include(bc => bc.Book)
                    .Include(bc => bc.Category)
                    .ToListAsync();

                if (bookCategories.Count == 0) return new ResponseDto<List<BookCategory>>(false, "No BookCategories found");

                return new ResponseDto<List<BookCategory>>(true, "BookCategories retrieved successfully", bookCategories);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<BookCategory>>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<BookCategory>> GetBookCategoryById(int id)
        {
            try
            {
                var bookCategory = await _context.BookCategories
                    .Include(bc => bc.Book)
                    .Include(bc => bc.Category)
                    .FirstOrDefaultAsync(bc => bc.Id == id);

                if (bookCategory == null) return new ResponseDto<BookCategory>(false, "BookCategory not found");

                return new ResponseDto<BookCategory>(true, "BookCategory retrieved successfully", bookCategory);
            }
            catch (Exception ex)
            {
                return new ResponseDto<BookCategory>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<BookCategory>> UpdateBookCategory(int id, BookCategory bookCategory)
        {
            throw new NotImplementedException();
        }
    }
}
