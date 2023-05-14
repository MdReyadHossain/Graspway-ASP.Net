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
        public List<Cart> GetCart(int studentId)
        {
            return (from cart in db.Carts
                    where cart.StudentId == studentId
                    select cart).ToList();
        }

        public bool Add(Cart obj)
        {
            var isCourse = true;
            var isError = (from c in db.Carts
                           where c.CourseId == obj.CourseId
                           select c.id).SingleOrDefault();

            var courseList = (from c in db.CourseStudents
                            where c.CourseId == obj.CourseId
                            select c).ToList();

            foreach(var c in courseList)
            {
                if(c.StudentId == obj.StudentId)
                {
                    isCourse = false;
                    break;
                }
            }

            if (isError == 0 && isCourse)
            {
                Cart cart = new Cart();
                cart.CourseId = obj.CourseId;
                cart.StudentId = obj.StudentId;
                cart.Price = (from course in db.Courses
                                where course.Id == obj.CourseId
                                select course.Price).SingleOrDefault();

                db.Carts.Add(cart);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public Cart Get(int id)
        {
            return db.Carts.Find(id);
        }

        public object Checkout(int studentId)
        {
            double totalPrice = 0;
            var cart = GetCart(studentId);
            var student = (from ct in db.Carts
                           where ct.StudentId == studentId
                           select ct).SingleOrDefault();

            if(student != null)
            {
                CourseStudent cs = new CourseStudent();
                foreach (var c in cart)
                {
                    totalPrice += c.Price;
                }

                var isValidStudent = (from s in db.Students
                                      where s.id == studentId && s.fund >= totalPrice
                                      select s).SingleOrDefault();

                if (isValidStudent != null)
                {
                    foreach (var c in cart)
                    {
                        cs.CourseId = c.CourseId;
                        cs.StudentId = c.StudentId;
                        cs.PurchaseAt = DateTime.Now;
                        cs.Rating = 0;
                        cs.Price = c.Price;
                        cs.Status = false;

                        var instructorId = (from course in db.Courses
                                            where course.Id == c.CourseId
                                            select course.InstructorId).SingleOrDefault();

                        var instructor = (from i in db.Instructors
                                          where i.Id == instructorId
                                          select i).SingleOrDefault();


                        instructor.TotalIncome += Math.Round((double)(c.Price * 0.7), 2);


                        var admin = db.Admins.Find((from ad in db.Admins
                                                   select ad.id).Max());

                        admin.TotalRevenue += Math.Round((double)(c.Price * 0.3), 2);

                        db.Carts.Remove(c);
                        db.CourseStudents.Add(cs);
                        db.SaveChanges();
                    }

                    OrderDetails od = new OrderDetails();
                    od.StudentId = studentId;
                    od.CheckoutAt = DateTime.Now;
                    od.TotalPayment = totalPrice;

                    isValidStudent.fund -= totalPrice;

                    db.OrderDetails.Add(od);
                    return new { status = db.SaveChanges() > 0, total_price = totalPrice };
                }
            }
            
            return new { status = false };
        }

        public bool Delete(int id)
        {
            var cart = Get(id);
            db.Carts.Remove(cart);
            return db.SaveChanges() > 0;
        }
    }
}
