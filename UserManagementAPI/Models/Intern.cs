﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{
    public class Intern
    {
        public Intern()
        {
            Name = string.Empty;
            Gender = "Unknown";
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public User? User { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        [MinLength(3, ErrorMessage = "Name cannot be less than 3 character")]
        public string Name { get; set; }

        [Column(TypeName="date")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender cannot be empty")]
        public string Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
