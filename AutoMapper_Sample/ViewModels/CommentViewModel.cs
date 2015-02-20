using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Texto é um campo obrigatório")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Body { get; set; }

        [Required]
        public int NewsId { get; set; }
        public virtual NewsViewModel News { get; set; }
    }
}