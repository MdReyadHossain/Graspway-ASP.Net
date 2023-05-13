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

        public static bool Checkout(int student_id)
        {
            return DataAccessFactory.CartData().Checkout(student_id);
        }

        public static bool Create(CartDTO prj)
        {
            var data = Convert(prj);
            return DataAccessFactory.CartData().Add(data);
        }

        public static bool Update(CartDTO cat)
        {
            var data = Convert(cat);
            return DataAccessFactory.CartData().Update(data);
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
                StudentId = prj.StudentId,
                Price = prj.Price
            };
        }
        static Cart Convert(CartDTO prj)
        {
            return new Cart()
            {
                id = prj.id,
                CourseId = prj.CourseId,
                StudentId = prj.StudentId,
                Price = prj.Price
            };
        }
    }
}
