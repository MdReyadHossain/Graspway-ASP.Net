using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class CatagoryRepo : Repo, IData<Catagory, int, bool>
    {
        public bool Add(Catagory obj)
        {
            db.Catagories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var catagory = Get(id);
            db.Catagories.Remove(catagory);
            return db.SaveChanges() > 0;
        }

        public List<Catagory> Get()
        {
            return db.Catagories.ToList();
        }

        public bool Update(Catagory obj)
        {
            var admin = Get(obj.id);
            db.Entry(admin).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public Catagory Get(int id)
        {
            return db.Catagories.Find(id);
        }
    }
}
