using ASPNETCRUD.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCRUD.ModelDtos
{
    public class BookCategoryDtos
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public BookDtos Book { get; set; }
        public CategoryDtos Category { get; set; }
    }
}
