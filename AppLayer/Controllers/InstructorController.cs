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
    public class InstructorController : ApiController
    {
        //-----Instructor Profile-----//

        //-----Instructor Get All Profile-----//
        [HttpGet]
        [Route("api/instructor")]
        public HttpResponseMessage GetInstructor()
        {
            try
            {
                var data = InstructorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Instructor Get Profile By ID-----//
        [HttpGet]
        [Route("api/instructor/{id}")]
        public HttpResponseMessage GetInstructor(int id)
        {
            try
            {
                var data = InstructorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Instructor Registration Route-----//
        [HttpPost]
        [Route("api/instructor/add")]
        public HttpResponseMessage AddProfile(InstructorDTO instructor)
        {
            try
            {
                var registration = InstructorService.Create(instructor);
                return Request.CreateResponse(HttpStatusCode.OK, registration);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Instructor Profile Update-----//
        [HttpPatch]
        [Route("api/instructor/editprofile")]
        public IHttpActionResult UpdateProfile([FromBody] InstructorDTO instructor)
        {
            try
            {
                var isUpdate = InstructorService.Update(instructor);
                return ResponseMessage(isUpdate ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
                }
            }
        }

        //-----Instructor Profile Delete-----//
        [HttpDelete]
        [Route("api/instructor/delete/{id}")]
        public IHttpActionResult DeleteProfile(int id)
        {
            try
            {
                var isDelete = InstructorService.Delete(id);
                return ResponseMessage(isDelete ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        //-----Instructor Course Part-----//

        //-----Instructor Dashboard-----//
        [HttpGet]
        [Route("api/instructor/dashboard")]
        public HttpResponseMessage Dashboard()
        {
            try
            {
                var data = InstructorService.Dashboard();
                return Request.CreateResponse(new { instructor = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Get All Course-----//
        [HttpGet]
        [Route("api/instructor/course")]
        public HttpResponseMessage GetCourse()
        {
            try
            {
                var data = CourseService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Get Course By ID-----//
        [HttpGet]
        [Route("api/instructor/course/{id}")]
        public HttpResponseMessage GetCourse(int id)
        {
            try
            {
                var data = CourseService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Course Registration-----//
        [HttpPost]
        [Route("api/instructor/course/add")]
        public HttpResponseMessage AddCourse(CourseDTO course)
        {
            try
            {
                var registration = CourseService.Create(course);
                return Request.CreateResponse(HttpStatusCode.OK, registration);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Course Update-----//
        [HttpPatch]
        [Route("api/instructor/course/editcourse")]
        public IHttpActionResult UpdateCourse([FromBody] CourseDTO course)
        {
            try
            {
                var isUpdate = CourseService.Update(course);
                return ResponseMessage(isUpdate ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
                }
            }
        }

        //-----Course Delete-----//
        [HttpDelete]
        [Route("api/instructor/course/delete/{id}")]
        public IHttpActionResult DeleteCourse(int id)
        {
            try
            {
                var isDelete = CourseService.Delete(id);
                return ResponseMessage(isDelete ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        //-----Instructor Course Content Part-----//
        //-----Get All Course Content-----//
        [HttpGet]
        [Route("api/instructor/course/content")]
        public HttpResponseMessage GetCourseContent()
        {
            try
            {
                var data = CourseContentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Get Course Content By ID-----//
        [HttpGet]
        [Route("api/instructor/course/content/{id}")]
        public HttpResponseMessage GetCourseContent(int id)
        {
            try
            {
                var data = CourseContentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Course Content Registration-----//
        [HttpPost]
        [Route("api/instructor/course/content/add")]
        public HttpResponseMessage AddCourseContent(CourseContentDTO coursecontent)
        {
            try
            {
                var registration = CourseContentService.Create(coursecontent);
                return Request.CreateResponse(HttpStatusCode.OK, registration);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Course Content Update-----//
        [HttpPatch]
        [Route("api/instructor/course/editcoursecontent")]
        public IHttpActionResult UpdateCourseContent([FromBody] CourseContentDTO coursecontent)
        {
            try
            {
                var isUpdate = CourseContentService.Update(coursecontent);
                return ResponseMessage(isUpdate ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
                }
            }
        }

        //-----Course Content Delete-----//
        [HttpDelete]
        [Route("api/instructor/course/content/delete/{id}")]
        public IHttpActionResult DeleteCourseContent(int id)
        {
            try
            {
                var isDelete = CourseContentService.Delete(id);
                return ResponseMessage(isDelete ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        //-----Instructor Notice Board Part-----//
        //-----Get All Notice Board-----//
        [HttpGet]
        [Route("api/instructor/notices")]
        public HttpResponseMessage GetNotice()
        {
            try
            {
                var data = NoticeBoardService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Get Notice Board By ID-----//
        [HttpGet]
        [Route("api/instructor/notices/{id}")]
        public HttpResponseMessage GetNotice(int id)
        {
            try
            {
                var data = NoticeBoardService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Post on Notice Board-----//
        [HttpPost]
        [Route("api/instructor/notices/add")]
        public HttpResponseMessage AddNotice(NoticeBoardDTO noticeBoard)
        {
            try
            {
                var registration = NoticeBoardService.Create(noticeBoard);
                return Request.CreateResponse(HttpStatusCode.OK, registration);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //-----Notice Board Update-----//
        [HttpPatch]
        [Route("api/instructor/notices/editnotice")]
        public IHttpActionResult UpdateNotice([FromBody] NoticeBoardDTO noticeBoard)
        {
            try
            {
                var isUpdate = NoticeBoardService.Update(noticeBoard);
                return ResponseMessage(isUpdate ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
                }
            }
        }

        //-----Notice Board Delete-----//
        [HttpDelete]
        [Route("api/instructor/notices/delete/{id}")]
        public IHttpActionResult DeleteNotice(int id)
        {
            try
            {
                var isDelete = NoticeBoardService.Delete(id);
                return ResponseMessage(isDelete ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        //-----Total Income Show-----//
        [HttpGet]
        [Route("api/instructor/totalincome/{instructorId}")]
        public HttpResponseMessage InstructorIncome(int instructorId)
        {
            try
            {
                var data = InstructorService.InstructorIncome(instructorId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
