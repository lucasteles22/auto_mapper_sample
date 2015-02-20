using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Models
{
    public class Car : Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Color> Colors { get; set; }
    }
}