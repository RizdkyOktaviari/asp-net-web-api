using ASPNETCRUD.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASPNETCRUD.ModelDtos
{
    public class AuthorDtos
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<AuthorBookDtos>? AuthorBooks { get; set; }
    }
}
