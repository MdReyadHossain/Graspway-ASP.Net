using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class CartRepo : Repo, ICart<Cart, int, bool>
    {
        public bool Add(Cart obj)
        {
            db.Carts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var cart = Get(id);
            db.Carts.Remove(cart);
            return db.SaveChanges() > 0;
        }

        public Cart Get(int id)
        {
            return db.Carts.Find(id);
        }

        public bool Update(Cart obj)
        {
            var cart = Get(obj.id);
            db.Entry(cart).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Cart> GetCart(int id)
        {
            return (from cart in db.Carts
                    where cart.StudentId == id
                    select cart).ToList();
        }
    }
}
