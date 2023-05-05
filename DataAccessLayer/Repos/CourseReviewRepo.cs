using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class CourseReviewRepo : Repo, IData<CourseReview, int, bool>
    {
        public bool Add(CourseReview obj)
        {
            db.CourseReviews.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<CourseReview> Get()
        {
            return db.CourseReviews.ToList();
        }

        public bool Update(CourseReview obj)
        {
            var cr = Get(obj.id);
            db.Entry(cr).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var st = Get(id);
            db.CourseReviews.Remove(st);
            return db.SaveChanges() > 0;
        }

        public CourseReview Get(int id)
        {
            return db.CourseReviews.Find(id);
        }
    }
}
