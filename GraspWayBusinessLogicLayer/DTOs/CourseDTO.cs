using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraspWayBusinessLogicLayer.DTOs
{
    public class CourseDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        public int CatagoryId { get; set; }

        [Required]
        public int InstructorId { get; set; }

        [Required]
        public string InstructorName { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
