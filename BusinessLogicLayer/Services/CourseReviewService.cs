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
    public class CourseReviewService
    {
        public static List<CourseReviewDTO> Get()
        {
            var data = DataAccessFactory.CourseReviewData().Get();
            return Convert(data);
        }

        public static bool Create(CourseReviewDTO prj)
        {
            var data = Convert(prj);
            return DataAccessFactory.CourseReviewData().Add(data);
        }

        public static bool Update(CourseReviewDTO cat)
        {
            var data = Convert(cat);
            return DataAccessFactory.CourseReviewData().Update(data);
        }

        public static bool Delete(int id)
        {
            var courseReview = DataAccessFactory.CourseReviewData();
            return courseReview.Delete(id);
        }

        static List<CourseReviewDTO> Convert(List<CourseReview> prj)
        {
            var data = new List<CourseReviewDTO>();
            foreach (CourseReview i in prj)
            {
                data.Add(Convert(i));
            }
            return data;
        }
        static CourseReviewDTO Convert(CourseReview prj)
        {
            return new CourseReviewDTO()
            {
                id = prj.id,
                Review = prj.Review,
                Rating = prj.Rating,
            };
        }
        static CourseReview Convert(CourseReviewDTO prj)
        {
            return new CourseReview()
            {
                id = prj.id,
                Review = prj.Review,
                Rating = prj.Rating,
            };
        }
    }
}
