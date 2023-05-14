using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class LoginRepo : Repo, ILogin<Login>
    {
        public string Login(Login obj)
        {
            var adminUser = (from admin in db.Admins
                             where admin.Admin_name == obj.Username && admin.Password == obj.Password
                             select admin).SingleOrDefault();
            
            var instructorUser = (from instructor in db.Instructors
                             where instructor.Name == obj.Username && instructor.Password == obj.Password
                             select instructor).SingleOrDefault();
            
            var studentUser = (from student in db.Students
                             where student.Student_name == obj.Username && student.Password == obj.Password
                             select student).SingleOrDefault();

            if (adminUser != null)
            {
                return "admin";
            }
            
            else if (instructorUser != null)
            {
                return "instructor";
            }
            
            else if (studentUser != null)
            {
                return "student";
            }

            return "false";
        }
    }
}
