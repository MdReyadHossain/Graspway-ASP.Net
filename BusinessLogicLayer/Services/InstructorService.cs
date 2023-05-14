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
    public class InstructorService
    {
        public static List<string> Dashboard()
        {
            var data = InstructorRepo.InstructorCount().ToList();
            return data;
        }

        public static List<InstructorDTO> Get()
        {
            var data = DataAccessFactory.InstructorData().Get();
            return Convert(data);
        }

        public static InstructorDTO Get(int id)
        {
            return Convert(DataAccessFactory.InstructorData().Get(id));
        }

        public static InstructorDTO Get(string status)
        {
            return Convert(DataAccessFactory.InstructorData().Get(status));
        }

        public static bool Create(InstructorDTO instructor)
        {
            var data = Convert(instructor);
            return DataAccessFactory.InstructorData().Create(data);
        }

        public static bool Update(InstructorDTO instructor)
        {
            var data = Convert(instructor);
            return DataAccessFactory.InstructorData().Update(data);
        }

        public static bool Delete(int id)
        {
            var instructor = DataAccessFactory.InstructorData();
            return instructor.Delete(id);
        }

        public static double InstructorIncome(int instructorId)
        {
            var data = InstructorRepo.InstructorIncome(instructorId);
            return data;
        }

        public static List<string> CourseStudentRequest()
        {
            var data = InstructorRepo.CourseStudentRequest().ToList();
            return data;
        }

        public static bool CourseStudentConfirm(int studentId, int courseId)
        {
            var data = InstructorRepo.CourseStudentConfirm(studentId, courseId);
            return data;
        }

        static List<InstructorDTO> Convert(List<Instructor> instructors)
        {
            var data = new List<InstructorDTO>();
            foreach (Instructor i in instructors)
            {
                data.Add(Convert(i));
            }
            return data;
        }

        static InstructorDTO Convert(Instructor instructor)
        {
            return new InstructorDTO()
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Password = instructor.Password,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                DOB = instructor.DOB,
                TotalIncome = instructor.TotalIncome,
                Rating = instructor.Rating,
                Status = instructor.Status
            };
        }

        static Instructor Convert(InstructorDTO instructor)
        {
            return new Instructor()
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Password = instructor.Password,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                DOB = instructor.DOB,
                TotalIncome = instructor.TotalIncome,
                Rating = instructor.Rating,
                Status = instructor.Status
            };
        }
    }
}
