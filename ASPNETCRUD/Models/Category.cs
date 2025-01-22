using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASPNETCRUD.Models
{
    [Table("category")]
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
