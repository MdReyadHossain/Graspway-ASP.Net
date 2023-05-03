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
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminData().Get();
            return Convert(data);
        }

        public static bool Create(AdminDTO prj)
        {
            var data = Convert(prj);
            return DataAccessFactory.AdminData().Create(data);
        }

        public static AdminDTO Get(int id)
        {
            return Convert(DataAccessFactory.AdminData().Get(id));
        }

        public static AdminDTO Get(string name)
        {
            return Convert(DataAccessFactory.AdminData().Get(name));
        }

        static List<AdminDTO> Convert(List<Admin> prj)
        {
            var data = new List<AdminDTO>();
            foreach (Admin i in prj)
            {
                data.Add(Convert(i));
            }
            return data;
        }
        static AdminDTO Convert(Admin prj)
        {
            return new AdminDTO()
            {
                id = prj.id,
                Admin_name = prj.Admin_name,
                Password = prj.Password,
                Address = prj.Address,
                Email = prj.Email,
                PhoneNo = prj.PhoneNo,
                AdminImage = prj.AdminImage
            };
        }
        static Admin Convert(AdminDTO prj)
        {
            return new Admin()
            {
                id = prj.id,
                Admin_name = prj.Admin_name,
                Password = prj.Password,
                Address = prj.Address,
                Email = prj.Email,
                PhoneNo = prj.PhoneNo,
                AdminImage = prj.AdminImage
            };
        }
    }
}
