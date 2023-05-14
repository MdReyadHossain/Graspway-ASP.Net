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
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var userData = LoginService.Login(login);
                var res = Request.CreateResponse(new { success = true, user = userData, message = "Login Successfull!" });

                if (userData == "admin")
                {
                    return res;
                }

                else if (userData == "instructor")
                {
                    return res;
                }

                else if (userData == "student")
                {
                    return res;
                }

                return Request.CreateResponse(new { success = false, user = userData, message = "Username or Password Invalid!" });
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
