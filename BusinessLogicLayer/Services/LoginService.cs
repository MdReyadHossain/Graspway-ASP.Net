using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LoginService
    {
        public static string Login(LoginDTO obj)
        {
            Login login = new Login();
            login.Username = obj.Username;
            login.Password = obj.Password;

            return DataAccessFactory.LoginData().Login(login);
        }
    }
}
