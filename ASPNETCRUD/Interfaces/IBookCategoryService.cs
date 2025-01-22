using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;

namespace ASPNETCRUD.Interfaces
{
    public interface IBookCategoryService
    {
        public Task<ResponseDto<List<BookCategory>>> GetAllBookCategorys();
        public Task<ResponseDto<BookCategory>> GetBookCategoryById(int id);
        public Task<ResponseDto<BookCategory>> CreateBookCategory(BookCategory bookCategory);
        public Task<ResponseDto<BookCategory>> UpdateBookCategory(int id, BookCategory bookCategory);
        public Task<ResponseDto<BookCategory>> DeleteBookCategory(int id);
    }
}
