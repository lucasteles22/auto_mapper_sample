using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMapper_Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleRelationship()
        {
            return View();
        }

        public ActionResult ManyToManyRelationship()
        {
            return View();
        }
    }
}