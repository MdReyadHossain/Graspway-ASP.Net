using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CourseReviewDTO
    {
        [Required]
        public int id { get; set; }

        /*[Required]
        public int CourseID { get; set; }*/

        [Required]
        public string Review { get; set; }
        
        [Required]
        public int Rating { get; set; }
    }
}
