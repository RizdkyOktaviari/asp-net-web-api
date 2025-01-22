using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCRUD.Models
{
    [Table("book_category")]
    public class BookCategory : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        public Book Book { get; set; }
        public Category Category { get; set; }
    }
}
