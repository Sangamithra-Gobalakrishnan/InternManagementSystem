using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models.DTOs
{
    public class PasswordDTO
    {
        [Required]
        public int UserID { get; set; }
       
        [Required]
        public string Password { get; set; }

    }
}
