using AutoMapper_Sample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.ViewModels
{
    public class CarViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public IList<CheckBoxModel> Colors { get; set; }
    }

    public class CheckBoxModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
    }
}