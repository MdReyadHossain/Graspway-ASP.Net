using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        public static IProfile<Admin, int, string, bool> AdminData()
        {
            return new AdminRepo();
        }

        public static IProfile<Student, int, string, bool> StudentData()
        {
            return new StudentRepo();
        }

        public static IData<Catagory, int, bool> CatagoryData()
        {
            return new CatagoryRepo();
        }

        public static IData<CourseStudent, int, bool> CourseStudentData()
        {
            return new CourseStudentRepo();
        }

        public static IData<CourseReview, int, bool> CourseReviewData()
        {
            return new CourseReviewRepo();
        }
    }
}
