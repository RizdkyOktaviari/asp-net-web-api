using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCRUD.Models
{
    public abstract class BaseEntity
    {
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
