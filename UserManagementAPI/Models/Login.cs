using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementAPI.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime? LogInTime { get; set; }

        public DateTime? LogOutTime { get; set; }
    }
}
