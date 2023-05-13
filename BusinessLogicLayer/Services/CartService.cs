using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CartService
    {
        public static List<CartDTO> GetCart(int student_id)
        {
            var data = DataAccessFactory.CartData().GetCart(student_id);
            return Convert(data);
        }

        public static object Checkout(int studentId)
        {
            return DataAccessFactory.CartData().Checkout(studentId);
        }

        public static bool Create(CartDTO cart)
        {
            var data = Convert(cart);
            return DataAccessFactory.CartData().Add(data);
        }

        public static bool Delete(int id)
        {
            var cart = DataAccessFactory.CartData();
            return cart.Delete(id);
        }

        static List<CartDTO> Convert(List<Cart> prj)
        {
            var data = new List<CartDTO>();
            foreach (Cart i in prj)
            {
                data.Add(Convert(i));
            }
            return data;
        }
        static CartDTO Convert(Cart prj)
        {
            return new CartDTO()
            {
                id = prj.id,
                CourseId = prj.CourseId,
                StudentId = prj.StudentId
            };
        }
        static Cart Convert(CartDTO prj)
        {
            return new Cart()
            {
                id = prj.id,
                CourseId = prj.CourseId,
                StudentId = prj.StudentId
            };
        }
    }
}
