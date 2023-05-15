﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class StudentDTO
    {
        public int id { get; set; }

        [Required]
        public string Student_name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        [RegularExpression(@"^(\+)?(\d{2})?0?(\d{10})$", ErrorMessage = "Enter a valid 11-digit phone number")]
        public string PhoneNo { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime Registration { get; set; }

        public double fund { get; set; }

        public bool action { get; set; }
    }
}
