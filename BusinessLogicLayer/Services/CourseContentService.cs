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
    public class CourseContentService
    {
        public static List<CourseContentDTO> Get()
        {
            var data = DataAccessFactory.CourseContentData().Get();
            return Convert(data);
        }

        public static CourseContentDTO Get(int id)
        {
            return Convert(DataAccessFactory.CourseContentData().Get(id));
        }

        public static bool Create(CourseContentDTO courseContent)
        {
            var data = Convert(courseContent);
            return DataAccessFactory.CourseContentData().Add(data);
        }

        public static bool Update(CourseContentDTO courseContent)
        {
            var data = Convert(courseContent);
            return DataAccessFactory.CourseContentData().Update(data);
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.CourseContentData();
            return data.Delete(id);
        }

        static List<CourseContentDTO> Convert(List<CourseContent> courseContent)
        {
            var data = new List<CourseContentDTO>();
            foreach (CourseContent i in courseContent)
            {
                data.Add(Convert(i));
            }
            return data;
        }

        static CourseContentDTO Convert(CourseContent courseContent)
        {
            return new CourseContentDTO()
            {
                Id = courseContent.Id,
                Name = courseContent.Name,
                Description = courseContent.Description,
                CourseId = courseContent.CourseId,
            };
        }

        static CourseContent Convert(CourseContentDTO courseContent)
        {
            return new CourseContent()
            {
                Id = courseContent.Id,
                Name = courseContent.Name,
                Description = courseContent.Description,
                CourseId = courseContent.CourseId
            };
        }
    }
}
