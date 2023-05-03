using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseReview> CourseReviews { get; set; }
    }
}
