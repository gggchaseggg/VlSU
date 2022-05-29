using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class News
    {
        [Required(ErrorMessage = "Название обязательно")]
        [MaxLength(36)]
        public string title { get; set; }
        [Required(ErrorMessage = "Текст обязательно")]
        public string text { get; set; }
        [Required(ErrorMessage = "Нужно указать рейтинг")]
        public float raiting { get; set; }

    }
}
