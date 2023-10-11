using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Role { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Gender { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        [Column()]
        public bool Status { get; set; }

        [MaxLength(255)]
        public string? Avatar { get; set; }


        public Account? Account { get; set; }
        public ICollection<Order>? Orders { get; set;}

    }
}
