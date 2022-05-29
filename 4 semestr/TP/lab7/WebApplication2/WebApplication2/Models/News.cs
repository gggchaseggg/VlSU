using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class News
    {
        [Key]
        [Required(ErrorMessage = "ID обязательно")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [MaxLength(36)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Текст обязательно")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Нужно указать рейтинг")]
        public float Raiting { get; set; }

        [Required]
        public Categ Category { get; set; }

        public List<News> NewsList { get; set; }
    }
}