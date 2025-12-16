using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DOMAIN.Enums;

namespace INFRASTRUCTURE.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;

        public Role? Role { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Deleted_At { get; set; }

        public virtual ICollection<TodoModel>? Todos { get; set; }
    }
}
