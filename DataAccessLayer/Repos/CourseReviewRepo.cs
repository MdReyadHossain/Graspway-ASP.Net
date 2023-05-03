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
            throw new NotImplementedException();
        }

        public List<CourseReview> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(CourseReview obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotSupportedException();
        }
    }
}
