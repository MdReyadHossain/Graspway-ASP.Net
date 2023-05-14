using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class CourseContentRepo : Repo, IData<CourseContent, int, bool>
    {
        public List<CourseContent> Get()
        {
            return db.CourseContents.ToList();
        }

        public CourseContent Get(int id)
        {
            return db.CourseContents.Find(id);
        }

        public bool Add(CourseContent obj)
        {
            db.CourseContents.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(CourseContent obj)
        {
            var coursecontent = Get(obj.Id);
            db.Entry(coursecontent).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var coursecontent = Get(id);
            db.CourseContents.Remove(coursecontent);
            return db.SaveChanges() > 0;
        }
    }
}
