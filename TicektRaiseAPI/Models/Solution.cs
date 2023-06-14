using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicektRaiseAPI.Models
{
    public class Solution
    {
        [Key]
        public int SolutionID { get; set; }

        [ForeignKey("TicketID")]
        [Required]
        public int TicketID { get; set; }
        public Ticket? Ticket { get; set; }

        [Required]
        //[MinLength(20, ErrorMessage = "Must be atleast 20 chars")]
        public string IssueSolution { get; set; }

        [Required]
        public string AdminName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ResolvedDate { get; set; }   
       
    }
}
