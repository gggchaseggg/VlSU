using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Categ
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}