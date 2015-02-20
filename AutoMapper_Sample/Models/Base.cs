using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Models
{
    public class Base
    {
        public DateTime CreatedAt { get; set; }

        public Base()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}