using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASPNETCRUD.Models
{
    [Table("author")]
    public class Author : BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<AuthorBook>? AuthorBooks { get; set; }
    }
}
