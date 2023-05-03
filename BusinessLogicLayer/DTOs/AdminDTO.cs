using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class AdminDTO
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string Admin_name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^(\+)?(\d{2})?0?(\d{10})$", ErrorMessage = "Enter a valid 11-digit phone number")]
        public string PhoneNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string AdminImage { get; set; }
    }
}
