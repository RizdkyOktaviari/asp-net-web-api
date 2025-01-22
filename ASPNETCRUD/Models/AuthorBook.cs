using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCRUD.Models
{
    [Table("author_book")]
    public class AuthorBook : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        public Author? Author { get; set; }
        public Book? Book { get; set; }
    }
}
