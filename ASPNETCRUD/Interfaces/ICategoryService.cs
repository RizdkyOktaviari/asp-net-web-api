using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;

namespace ASPNETCRUD.Interfaces
{
    public interface ICategoryService
    {
        public Task<ResponseDto<List<Category>>> GetAllCategorys();
        public Task<ResponseDto<Category>> GetCategoryById(int id);
        public Task<ResponseDto<Category>> CreateCategory(Category category);
        public Task<ResponseDto<Category>> UpdateCategory(int id, Category category);
        public Task<ResponseDto<Category>> DeleteCategory(int id);
    }
}
