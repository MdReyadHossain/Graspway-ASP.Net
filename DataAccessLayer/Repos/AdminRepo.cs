using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class AdminRepo : Repo, IProfile<Admin, int, string, bool>
    {
        public bool Create(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin Get(string name)
        {
            return db.Admins.Find(name);
        }

        public bool Update(Admin obj)
        {
            var admin = Get(obj.id);
            db.Entry(admin).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var admin = Get(id);
            db.Admins.Remove(admin);
            return db.SaveChanges() > 0;
        }

        public static int AdminCount()
        {
            var db = new AppDbContext();
            var count = (from admin in db.Admins
                         select admin).Count();

            return count;
        }
    }
}
