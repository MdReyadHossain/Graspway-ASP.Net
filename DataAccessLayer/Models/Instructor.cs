using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string InstructorImage { get; set; }

        [Required]
        public double TotalIncome { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public DateTime JoinedAt { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public Instructor()
        {
            Courses = new List<Course>();
        }
    }
}
