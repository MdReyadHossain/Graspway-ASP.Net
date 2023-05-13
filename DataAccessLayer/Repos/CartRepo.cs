using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class CartRepo : Repo, ICart<Cart, int, bool>
    {
        public List<Cart> GetCart(int student_id)
        {
            return (from cart in db.Carts
                    where cart.StudentId == student_id
                    select cart).ToList();
        }

        public bool Add(Cart obj)
        {
            db.Carts.Add(obj);
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

        public bool Checkout(int student_id)
        {
            return true;
            /*double totalPrice = 0;
            var cart = GetCart(student_id);
            CourseStudent cs = new CourseStudent();
            foreach(var c in cart)
            {
                cs.CourseId = c.CourseId;
                cs.StudentId = c.StudentId;
                cs.PurchaseAt = DateTime.Now;
                cs.Rating = 0;
                cs.Price = c.Price;
                cs.Status = false;

                totalPrice += c.Price;
                db.Carts.Remove(c);
            }

            OrderDetails od = new OrderDetails();
            od.StudentId = student_id;
            od.CheckoutAt = DateTime.Now;
            od.TotalPayment = totalPrice;

            db.OrderDetails.Add(od);

            db.CourseStudents.Add(cs);
            return db.SaveChanges() > 0;*/
        }

        public bool Delete(int id)
        {
            var cart = Get(id);
            db.Carts.Remove(cart);
            return db.SaveChanges() > 0;
        }
    }
}
