using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;

namespace ASPNETCRUD.Interfaces
{
    public interface IBookService
    {
        public Task<ResponseDto<List<BookDtos>>> GetAllBooks();
        public Task<ResponseDto<Book>> GetBookById(int id);
        public Task<ResponseDto<Book>> CreateBook(Book book);
        public Task<ResponseDto<Book>> UpdateBook(int id, Book book);
        public Task<ResponseDto<Book>> DeleteBook(int id);
    }
}
