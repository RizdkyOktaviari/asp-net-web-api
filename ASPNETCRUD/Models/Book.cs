using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASPNETCRUD.Models
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public required string Title { get; set; }
        [JsonIgnore]
        public ICollection<AuthorBook>? AuthorBooks { get; set; }
        [JsonIgnore]
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
