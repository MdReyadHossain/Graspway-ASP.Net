using GraspWayDataAccessLayer.Interfaces;
using GraspWayDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraspWayDataAccessLayer.Repositories
{
    internal class CourseRepo : Repo, IData<Course, int, bool>
    {

        public List<Course> Get()
        {
            return db.Courses.ToList();
        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Add(Course obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }


        public bool Update(Course obj)
        {
            var course = Get(obj.Id);
            db.Entry(course).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var course = Get(id);
            db.Courses.Remove(course);
            return db.SaveChanges() > 0;
        }     
    }
}
