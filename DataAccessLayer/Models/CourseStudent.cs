﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CourseStudent
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public DateTime PurchaseAt { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
