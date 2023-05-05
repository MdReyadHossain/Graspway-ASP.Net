using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CatagoryService
    {
        public static List<CatagoryDTO> Get()
        {
            var data = DataAccessFactory.CatagoryData().Get();
            return Convert(data);
        }

        public static bool Create(CatagoryDTO prj)
        {
            var data = Convert(prj);
            return DataAccessFactory.CatagoryData().Add(data);
        }

        public static bool Update(CatagoryDTO cat)
        {
            var data = Convert(cat);
            return DataAccessFactory.CatagoryData().Update(data);
        }

        public static bool Delete(int id)
        {
            var student = DataAccessFactory.CatagoryData();
            return student.Delete(id);
        }

        static List<CatagoryDTO> Convert(List<Catagory> prj)
        {
            var data = new List<CatagoryDTO>();
            foreach (Catagory i in prj)
            {
                data.Add(Convert(i));
            }
            return data;
        }
        static CatagoryDTO Convert(Catagory prj)
        {
            return new CatagoryDTO()
            {
                id = prj.id,
                Name = prj.Name
            };
        }
        static Catagory Convert(CatagoryDTO prj)
        {
            return new Catagory()
            {
                id = prj.id,
                Name = prj.Name
            };
        }
    }
}
