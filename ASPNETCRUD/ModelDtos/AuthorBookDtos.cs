using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCRUD.ModelDtos
{
    public class AuthorBookDtos
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public AuthorDtos? Author { get; set; }
        public BookDtos? Book { get; set; }
    }
}
