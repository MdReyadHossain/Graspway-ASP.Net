using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class CourseStudentRepo : Repo, IData<CourseStudent, int, bool>
    {
        public bool Add(CourseStudent obj)
        {
            db.CourseStudents.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var st = Get(id);
            db.CourseStudents.Remove(st);
            return db.SaveChanges() > 0;
        }

        public List<CourseStudent> Get()
        {
            return db.CourseStudents.ToList();
        }

        public bool Update(CourseStudent obj)
        {
            var courseStudent = Get(obj.id);
            db.Entry(courseStudent).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public CourseStudent Get(int id)
        {
            return db.CourseStudents.Find(id);
        }
    }
}
