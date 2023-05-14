using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Catagory
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public Catagory()
        {
            Courses = new List<Course>();
        }
    }
}
