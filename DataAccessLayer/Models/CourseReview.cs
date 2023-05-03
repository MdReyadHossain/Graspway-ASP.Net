using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CourseReview
    {
        [Key]
        public int id { get; set; }

        /*[Required]
        public int CourseID { get; set; }*/

        [Required]
        public string Review { get; set; }
        
        [Required]
        public int Rating { get; set; }
    }
}
