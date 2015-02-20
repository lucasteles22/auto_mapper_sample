using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.ViewModels
{
    public class NewsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é um campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Texto é um campo obrigatório")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Body { get; set; }

        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
    }
}