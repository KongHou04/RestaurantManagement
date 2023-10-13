using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [MaxLength(50)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }

        public Employee? Employee { get; set; }
    
    }
}
