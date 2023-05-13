using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CourseStudentDTO
    {
        public int id { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public DateTime PurchaseAt { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
