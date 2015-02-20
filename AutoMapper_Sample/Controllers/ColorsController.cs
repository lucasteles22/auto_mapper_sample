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
    public class ColorsController : Controller
    {
        private ApplicationDbContext _Db = new ApplicationDbContext();
        // GET: Colors
        public async Task<ActionResult> Index()
        {
            var colorViewModel = Mapper.Map<IEnumerable<Color>, IEnumerable<ColorViewModel>>(await this._Db.Colors.ToListAsync());
            return View(colorViewModel);
        }

        // GET: Colors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var color = await this._Db.Colors.FindAsync(id.Value);
            if (color == null)
                return HttpNotFound();

            var colorViewModel = Mapper.Map<Color, ColorViewModel>(color);

            return View(colorViewModel);
        }

        // GET: Colors/Create
        public ActionResult Create()
        {
            var colorViewModel = Mapper.Map<Color, ColorViewModel>(new Color());
            return View(colorViewModel);
        }

        // POST: Colors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ColorViewModel colorViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var color = Mapper.Map<ColorViewModel, Color>(colorViewModel);
                    this._Db.Colors.Add(color);
                    await this._Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            { }
            return View();
        }

        // GET: Colors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var color = await this._Db.Colors.FindAsync(id.Value);
            if (color == null)
                return HttpNotFound();

            var colorViewModel = Mapper.Map<Color, ColorViewModel>(color);

            return View(colorViewModel);
        }

        // POST: Colors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ColorViewModel colorViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var color = Mapper.Map<ColorViewModel, Color>(colorViewModel);
                    this._Db.Entry(color).State = EntityState.Modified;
                    await this._Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            { }
            return View();
        }

        // GET: Colors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var color = await this._Db.Colors.FindAsync(id.Value);
            if (color == null)
                return HttpNotFound();

            var colorViewModel = Mapper.Map<Color, ColorViewModel>(color);

            return View(colorViewModel);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return HttpNotFound();

                var color = await this._Db.Colors.FindAsync(id.Value);
                if (color == null)
                    return HttpNotFound();

                this._Db.Colors.Remove(color);
                await this._Db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
