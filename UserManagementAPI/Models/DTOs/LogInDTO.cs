using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementAPI.Models.DTOs
{
    public class LogInDTO
    {
        [Required]
        public int UserId { get; set; }

    }
}
