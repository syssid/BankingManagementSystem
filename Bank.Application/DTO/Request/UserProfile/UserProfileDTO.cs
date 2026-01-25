using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.DTO.Request.UserProfile
{
    public class UserProfileDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Mobile { get; set; }

        public string? Address { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
