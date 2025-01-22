using ASPNETCRUD.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASPNETCRUD.ModelDtos
{
    public class BookDtos
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public List<AuthorBookDtos>? AuthorBooks { get; set; }
        public List<BookCategoryDtos>? BookCategories { get; set; }
    }
}
