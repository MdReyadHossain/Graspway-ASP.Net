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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseStudent> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(CourseStudent obj)
        {
            throw new NotImplementedException();
        }
    }
}
