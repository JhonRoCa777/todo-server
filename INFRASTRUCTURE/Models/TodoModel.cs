using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DOMAIN.Enums;

namespace INFRASTRUCTURE.Models
{
    [Table("Todos")]
    public class TodoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public Estado? Estado { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Deleted_At { get; set; }

        public long UserId { get; set; }

        public virtual UserModel? User { get; set; }
    }
}
