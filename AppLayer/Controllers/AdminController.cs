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
    public class AdminController : ApiController
    {
        // --------Admin profile route START-------- \\
        [HttpGet]
        [Route("api/admin/dashboard")]
        public HttpResponseMessage GetDashboard()
        {
            try
            {
                var admin = AdminService.AdminDashboard();
                return Request.CreateResponse(new { admin });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpPost]
        [Route("api/admin/add")]
        public HttpResponseMessage Add(AdminDTO admin)
        {
            try
            {
                var res = AdminService.Create(admin);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/admin")]
        public HttpResponseMessage GetAdmins()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/admin/{id}")]
        public HttpResponseMessage GetAdmin(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/admin/editprofile")]
        public IHttpActionResult Update([FromBody] AdminDTO admin)
        {
            try
            {
                var isUpdated = AdminService.Update(admin);
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

        [HttpDelete]
        [Route("api/admin/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = AdminService.Delete(id);
                return ResponseMessage(isDeleted
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        // --------Admin profile route END-------- \\



        // --------Catagory route START-------- \\

        [HttpPost]
        [Route("api/catagory/add")]
        public HttpResponseMessage AddCatagory(CatagoryDTO cat)
        {
            try
            {
                var res = CatagoryService.Create(cat);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/catagory")]
        public HttpResponseMessage GetCatagory()
        {
            try
            {
                var data = CatagoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/catagory/edit")]
        public IHttpActionResult UodateCatagory([FromBody] CatagoryDTO cat)
        {
            try
            {
                var isUpdated = CatagoryService.Update(cat);
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

        [HttpDelete]
        [Route("api/catagory/delete/{id}")]
        public IHttpActionResult DeleteCatagory(int id)
        {
            try
            {
                var isDeleted = CatagoryService.Delete(id);
                return ResponseMessage(isDeleted
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        // --------Catagory route END-------- \\


        //-----Instructor Notice Board Part-----//
        //-----Get All Notice Board-----//
        [HttpGet]
        [Route("api/admin/notices")]
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
        [Route("api/admin/notices/{id}")]
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
        [Route("api/admin/notices/add")]
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
        [Route("api/admin/notices/editnotice")]
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
        [Route("api/admin/notices/delete/{id}")]
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


        //-----Get All Course-----//
        [HttpGet]
        [Route("api/course")]
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
        [Route("api/course/{id}")]
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
    }
}
