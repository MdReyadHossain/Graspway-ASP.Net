using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLogicLayer.DTOs
{
    public class CatagoryDTO
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
