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
    public class CommentsController : Controller
    {
        private ApplicationDbContext _Db = new ApplicationDbContext();
        // GET: Comments
        public ActionResult Index()
        {
            var commentsViewModel = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(this._Db.Comments.ToList());
            return View(commentsViewModel);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.News = new SelectList(this._Db.News, "Id", "Title");
            return View(new CommentViewModel());
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CommentViewModel commentViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var comment = Mapper.Map<CommentViewModel, Comment>(commentViewModel);
                    this._Db.Comments.Add(comment);
                    await this._Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }                
            }
            catch
            { }
            ViewBag.News = new SelectList(this._Db.News, "Id", "Title", commentViewModel.NewsId);
            return View(commentViewModel);
        }

        // GET: Comments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var commentViewModel = Mapper.Map<Comment, CommentViewModel>(await this._Db.Comments.FindAsync(id.Value));
            ViewBag.News = new SelectList(this._Db.News, "Id", "Title", commentViewModel.NewsId);
            return View(commentViewModel);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CommentViewModel commentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var comment = Mapper.Map<CommentViewModel, Comment>(commentViewModel);
                    this._Db.Entry(comment).State = EntityState.Modified;
                    await this._Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
               
            }
            catch
            { }
            ViewBag.News = new SelectList(this._Db.News, "Id", "Title", commentViewModel.NewsId);
            return View(commentViewModel);
        }

        // GET: Comments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            var commentViewModel = Mapper.Map<Comment, CommentViewModel>(await this._Db.Comments.FindAsync(id.Value));
            return View(commentViewModel);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return HttpNotFound();

                var comment = await this._Db.Comments.FindAsync(id.Value);
                this._Db.Comments.Remove(comment);
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
