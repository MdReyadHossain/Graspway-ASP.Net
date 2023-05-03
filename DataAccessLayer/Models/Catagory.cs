using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Catagory
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
