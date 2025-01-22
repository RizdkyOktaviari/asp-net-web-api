using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;

namespace ASPNETCRUD.Interfaces
{
    public interface IAuthorService
    {
        public Task<ResponseDto<List<Author>>> GetAllAuthors();
        public Task<ResponseDto<Author>> GetAuthorById(int id);
        public Task<ResponseDto<Author>> CreateAuthor(Author author);
        public Task<ResponseDto<Author>> UpdateAuthor(int id, Author author);
        public Task<ResponseDto<Author>> DeleteAuthor(int id);
    }
}
