using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class InstructorRepo : Repo, IProfile<Instructor, int, string, bool>
    {

        public List<Instructor> Get()
        {
            return db.Instructors.ToList();
        }

        public Instructor Get(int id)
        {
            return db.Instructors.Find(id);
        }

        public Instructor Get(string status)
        {
            bool isStatusTrue = bool.Parse(status);
            return db.Instructors.FirstOrDefault(i => i.Status == isStatusTrue);
        }

        public bool Create(Instructor obj)
        {
            db.Instructors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Instructor obj)
        {
            var instructor = (from i in db.Instructors
                              where i.Id == obj.Id
                              select i).SingleOrDefault();

            instructor.Name = obj.Name;
            instructor.Email = obj.Email;
            instructor.PhoneNumber = obj.PhoneNumber;
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var instructor = Get(id);
            db.Instructors.Remove(instructor);
            return db.SaveChanges() > 0;
        }

        public static double InstructorIncome(int instructorId)
        {
            var db = new AppDbContext();
            var data = (from instructor in db.Instructors
                        where instructor.Id == instructorId
                        select instructor.TotalIncome).SingleOrDefault();
            return data;
        }

        public static List<string> InstructorCount()
        {
            var db = new AppDbContext();
            var data = (from insructor in db.Instructors
                        select insructor.Name).ToList();
            return data;
        }
    }
}
