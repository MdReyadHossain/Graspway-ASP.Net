using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class StudentRepo : Repo, IProfile<Student, int, string, bool>
    {
        public bool Create(Student obj)
        {
            db.Students.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public Student Get(string name)
        {
            return db.Students.Find(name);
        }

        public bool Update(Student obj)
        {
            var student = (from s in db.Students
                           where s.id == obj.id
                           select s).SingleOrDefault();

            student.Student_name = obj.Student_name;
            student.Email = obj.Email;
            student.PhoneNo = obj.PhoneNo;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var st = Get(id);
            db.Students.Remove(st);
            return db.SaveChanges() > 0;
        }
    }
}
