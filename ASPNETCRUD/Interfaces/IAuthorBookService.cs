using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;

namespace ASPNETCRUD.Interfaces
{
    public interface IAuthorBookService
    {
        public Task<ResponseDto<List<AuthorBook>>> GetAllAuthorBooks();
        public Task<ResponseDto<AuthorBook>> GetAuthorBookById(int id);
        public Task<ResponseDto<AuthorBook>> CreateAuthorBook(AuthorBook authorBook);
        public Task<ResponseDto<AuthorBook>> UpdateAuthorBook(int id, AuthorBook authorBook);
        public Task<ResponseDto<AuthorBook>> DeleteAuthorBook(int id);
    }
}
