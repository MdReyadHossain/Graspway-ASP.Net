using GraspWayBusinessLogicLayer.DTOs;
using GraspWayDataAccessLayer;
using GraspWayDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraspWayBusinessLogicLayer.Services
{
    public class CourseService
    {

        public static List<CourseDTO> Get()
        {
            var data = DataAccessFactory.CourseData().Get();
            return Convert(data);
        }

        public static CourseDTO Get(int id)
        {
            return Convert(DataAccessFactory.CourseData().Get(id));
        }

        public static bool Create(CourseDTO course)
        {
            var data = Convert(course);
            return DataAccessFactory.CourseData().Add(data);
        }

        public static bool Update(CourseDTO course)
        {
            var data = Convert(course);
            return DataAccessFactory.CourseData().Update(data);
        }

        public static bool Delete(int id)
        {
            var course = DataAccessFactory.CourseData();
            return course.Delete(id);
        }

        static List<CourseDTO> Convert(List<Course> course)
        {
            var data = new List<CourseDTO>();
            foreach (Course i in course)
            {
                data.Add(Convert(i));
            }
            return data;
        }

        static CourseDTO Convert(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CatagoryId = course.CatagoryId,
                InstructorId = course.InstructorId,
                InstructorName = course.InstructorName,
                Rating = course.Rating
            };
        }

        static Course Convert(CourseDTO course)
        {
            return new Course()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CatagoryId = course.CatagoryId,
                InstructorId = course.InstructorId,
                InstructorName = course.InstructorName,
                Rating = course.Rating
            };
        }
    }
}
