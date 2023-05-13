using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }
        public virtual ICollection<CourseReview> CourseReviews { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        public Course()
        {
            Carts = new List<Cart>();
            CourseContents = new List<CourseContent>();
            CourseReviews = new List<CourseReview>();
            CourseStudents = new List<CourseStudent>();
        }
    }
}
