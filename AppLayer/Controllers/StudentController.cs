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
        // --------Student profile route START-------- \\
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

        [HttpPatch]
        [Route("api/student/editprofile")]
        public IHttpActionResult Patch([FromBody] StudentDTO std)
        {
            try
            {
                var isUpdated = StudentService.Update(std);
                return ResponseMessage(isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpGet]
        [Route("api/student/delete/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var res = StudentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        // --------Student profile route END-------- \\

        // --------Course Review route START-------- \\

        [HttpPost]
        [Route("api/coursereview/add")]
        public HttpResponseMessage AddReview(CourseReviewDTO review)
        {
            try
            {
                var res = CourseReviewService.Create(review);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // --------Course Review route END-------- \\

        // --------Cart route START-------- \\

        [HttpPost]
        [Route("api/cart/add")]
        public HttpResponseMessage AddCart(CartDTO cart)
        {
            try
            {
                var res = CartService.Create(cart);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/cart/{id}")]
        public HttpResponseMessage Cart(int id)
        {
            try
            {
                var res = CartService.GetCart(id);
                return Request.CreateResponse(new { cart=res });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/cart/checkout/{studentId}")]
        public HttpResponseMessage Checkout(int studentId)
        {
            try
            {
                var data = CartService.Checkout(studentId);
                return Request.CreateResponse(new { data = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/cart/delete/{id}")]
        public HttpResponseMessage DeleteCart(int id)
        {
            try
            {
                var res = CartService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // --------Cart route END-------- \\

    }
}
