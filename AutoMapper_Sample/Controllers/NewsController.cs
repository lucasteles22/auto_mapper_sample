using AutoMapper;
using AutoMapper_Sample.Context;
using AutoMapper_Sample.Models;
using AutoMapper_Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoMapper_Sample.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext _Db = new ApplicationDbContext();
        // GET: News
        public ActionResult Index()
        {
            var newsViewModel = Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(_Db.News.ToList());
            return View(newsViewModel);
        }

        // GET: News/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var newsViewModel = Mapper.Map<News, NewsViewModel>(await _Db.News.FindAsync(id.Value));

            return View(newsViewModel);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View(new NewsViewModel());
        }

        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewsViewModel newsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var news = Mapper.Map<NewsViewModel, News>(newsViewModel);
                    this._Db.News.Add(news);
                    await this._Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            { }
            return View();
        }

        // GET: News/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var newsViewModel = Mapper.Map<News, NewsViewModel>(await _Db.News.FindAsync(id.Value));
            return View(newsViewModel);
        }

        // POST: News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NewsViewModel newsViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var news = Mapper.Map<NewsViewModel, News>(newsViewModel);
                    this._Db.Entry(news).State = EntityState.Modified;
                    await this._Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            { }
            return View();

        }

        // GET: News/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var newsViewModel = Mapper.Map<News, NewsViewModel>(await _Db.News.FindAsync(id.Value));

            return View(newsViewModel);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return HttpNotFound();

                var news = await _Db.News.FindAsync(id.Value);
                this._Db.News.Remove(news);
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
