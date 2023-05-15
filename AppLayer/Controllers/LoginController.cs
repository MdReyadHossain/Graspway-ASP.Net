using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var db = new AppDbContext();
                var adminUser = (from admin in db.Admins
                                 where admin.Admin_name == login.Username && admin.Password == login.Password
                                 select new {admin.Admin_name, admin.Email, admin.Address, admin.PhoneNo}).SingleOrDefault();

                var instructorUser = (from instructor in db.Instructors
                                      where instructor.Name == login.Username && instructor.Password == login.Password
                                      select new { instructor.Name, instructor.Email, instructor.DOB, instructor.PhoneNumber }).SingleOrDefault();

                var studentUser = (from student in db.Students
                                   where student.Student_name == login.Username && student.Password == login.Password
                                   select new { student.Student_name, student.Email, student.Dob, student.PhoneNo }).SingleOrDefault();
                
                if (adminUser != null)
                {
                    var session = adminUser;
                    return Request.CreateResponse(new { session, success = true, user = "admin", message = "Login Successfull!" });
                }

                else if (instructorUser != null)
                {
                    var session = instructorUser;
                    return Request.CreateResponse(new { session, success = true, user = "instructor", message = "Login Successfull!" });
                }

                else if (studentUser != null)
                {
                    var session = studentUser;
                    return Request.CreateResponse(new { session, success = true, user = "student", message = "Login Successfull!" });
                }

                return Request.CreateResponse(new { success = false, user = "false", message = "Username or Password Invalid!" });
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
