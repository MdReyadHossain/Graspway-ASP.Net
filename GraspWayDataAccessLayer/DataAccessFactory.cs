using GraspWayDataAccessLayer.Interfaces;
using GraspWayDataAccessLayer.Models;
using GraspWayDataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraspWayDataAccessLayer
{
    public class DataAccessFactory
    {
        public static IProfile<Instructor, int, string, bool> InstructorData()
        {
            return new InstructorRepo();
        }

        public static IData<Course, int, bool> CourseData()
        {
            return new CourseRepo();
        }

        public static IData<CourseContent, int, bool> CourseContentData()
        {
            return new CourseContentRepo();
        }
    }
}
