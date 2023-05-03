using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class StudentController : ApiController
    {
        [HttpPost]
        [Route("api/student/add")]
        public HttpResponseMessage Add(StudentDTO student)
        {
            try
            {
                var res = StudentService.Create(student);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Student")]
        public HttpResponseMessage GetStudents()
        {
            try
            {
                var data = StudentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage GetStudent(int id)
        {
            try
            {
                var data = StudentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/student/delete/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var res = StudentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
