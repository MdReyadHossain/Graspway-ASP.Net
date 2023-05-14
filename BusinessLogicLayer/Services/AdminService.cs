using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AdminService
    {
        public static object AdminDashboard()
        {
            var db = new AppDbContext();
            var admin = (from ad in db.Admins
                         select ad).Count();

            var instructor = (from ins in db.Instructors
                              where ins.Status == true
                              select ins).Count();
            var student = (from st in db.Students
                           select st).Count();

            var course = (from c in db.Courses
                          select c).Count();

            var studentReg = (from st in db.Students
                              select st.Registration).ToList();

            return new { admin, student, course };
        }

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

        public static bool Update(AdminDTO student)
        {
            var data = Convert(student);
            return DataAccessFactory.AdminData().Update(data);
        }

        public static bool Delete(int id)
        {
            var student = DataAccessFactory.AdminData();
            return student.Delete(id);
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
