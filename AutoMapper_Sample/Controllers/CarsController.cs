using AutoMapper;
using AutoMapper_Sample.Context;
using AutoMapper_Sample.Models;
using AutoMapper_Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AutoMapper_Sample.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _Db = new ApplicationDbContext();
        // GET: Cars
        public async Task<ActionResult> Index()
        {
            var carViewModel = Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(await this._Db.Cars.ToListAsync());
            return View(carViewModel);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            var carViewModel = Mapper.Map<Car, CarViewModel>(new Car());
            carViewModel.Colors = this._Db.Colors.Select(x => new CheckBoxModel() { Id = x.Id, Status = false, Value = x.Name }).ToList();
            return View(carViewModel);
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cars/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cars/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                this._Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
