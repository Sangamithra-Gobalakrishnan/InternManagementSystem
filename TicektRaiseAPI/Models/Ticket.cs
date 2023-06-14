using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicektRaiseAPI.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [Required]
        public int IssuerID { get; set; }

        [Required]
        [MinLength(10,ErrorMessage ="Must be atleast 10 chars")]
        public string IssueTitle { get; set; }
        
        [Required]
       [MinLength(20, ErrorMessage = "Must be atleast 20 chars")]
        public string IssueDescription { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }

        public string? TicketStatus { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
