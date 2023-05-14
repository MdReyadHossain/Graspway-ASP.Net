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
    public class CourseStudentService
    {
        public static List<CourseStudentDTO> Get()
        {
            var data = DataAccessFactory.CourseStudentData().Get();
            return Convert(data);
        }

        public static bool Create(CourseStudentDTO prj)
        {
            var data = Convert(prj);
            return DataAccessFactory.CourseStudentData().Add(data);
        }

        public static bool Update(CourseStudentDTO cs)
        {
            var data = Convert(cs);
            return DataAccessFactory.CourseStudentData().Update(data);
        }

        public static bool Delete(int id)
        {
            var courseReview = DataAccessFactory.CourseStudentData();
            return courseReview.Delete(id);
        }

        public static List<CourseStudentDTO> MyCourse(int studentId)
        {
            var data = CourseStudentRepo.MyCourse(studentId);   
            return Convert(data);
        }

        static List<CourseStudentDTO> Convert(List<CourseStudent> prj)
        {
            var data = new List<CourseStudentDTO>();
            foreach (CourseStudent i in prj)
            {
                data.Add(Convert(i));
            }
            return data;
        }
        static CourseStudentDTO Convert(CourseStudent prj)
        {
            return new CourseStudentDTO()
            {
                id = prj.id,
                Status = prj.Status,
                Rating = prj.Rating,
            };
        }
        static CourseStudent Convert(CourseStudentDTO prj)
        {
            return new CourseStudent()
            {
                id = prj.id,
                Status = prj.Status,
                Rating = prj.Rating,
            };
        }
    }
}
