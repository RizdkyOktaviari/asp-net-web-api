using ASPNETCRUD.Models;
using System.Text.Json.Serialization;

namespace ASPNETCRUD.ModelDtos
{
    public class CategoryDtos
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<BookCategoryDtos>? BookCategories { get; set; }
    }
}
