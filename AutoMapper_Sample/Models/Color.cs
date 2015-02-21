using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Models
{
    public class Color : Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Color()
        {
            this.Cars = new List<Car>();
        }
    }
}