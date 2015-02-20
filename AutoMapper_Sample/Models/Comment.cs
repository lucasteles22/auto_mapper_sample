using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }
    }
}