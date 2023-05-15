using AutoMapper;
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
    public class StudentService
    {
        public static List<StudentDTO> Get()
        {
            var data = DataAccessFactory.StudentData().Get();
            return Convert(data);
        }

        public static bool Create(StudentDTO prj)
        {
            var data = Convert(prj);
            return DataAccessFactory.StudentData().Create(data);
        }

        public static StudentDTO Get(int id)
        {
            return Convert(DataAccessFactory.StudentData().Get(id));
        }

        public static StudentDTO Get(string name)
        {
            return Convert(DataAccessFactory.StudentData().Get(name));
        }

        public static bool Update(StudentDTO student)
        {
            var data = new Student()
            {
                id = student.id,
                Student_name = student.Student_name,
                Email = student.Email,
                PhoneNo = student.PhoneNo
            };
            return DataAccessFactory.StudentData().Update(data);
        }

        public static bool Delete(int id)
        {
            var student = DataAccessFactory.StudentData();
            return student.Delete(id);
        }

        static List<StudentDTO> Convert(List<Student> prj)
        {
            var data = new List<StudentDTO>();
            foreach (Student i in prj)
            {
                data.Add(Convert(i));
            }
            return data;
        }
        static StudentDTO Convert(Student prj)
        {
            return new StudentDTO()
            {
                id = prj.id,
                Student_name = prj.Student_name,
                Password = prj.Password,
                Dob = prj.Dob,
                Email = prj.Email,
                PhoneNo = prj.PhoneNo,
                Registration = DateTime.Now,
                fund = 0,
                action = true
            };
        }
        static Student Convert(StudentDTO prj)
        {
            return new Student()
            {
                id = prj.id,
                Student_name = prj.Student_name,
                Password = prj.Password,
                Dob = prj.Dob,
                Email = prj.Email,
                PhoneNo = prj.PhoneNo,
                Registration = DateTime.Now,
                fund = 0,
                action = true
            };
        }
    }
}
