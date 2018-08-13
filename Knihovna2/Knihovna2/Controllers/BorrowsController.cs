using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Knihovna2.DAL;
using Knihovna2.Models;

namespace Knihovna2.Controllers
{

    public class BorrowsController : Controller
    {
        
        private LibraryContext db = new LibraryContext();

        // GET: Borrows
        public ActionResult Index()
        {
            /* List<string> BookTitles = new List<string>();

             foreach(var item in db.Books)
             {
                 BookTitles.Add(item.Title);
             }
             ViewBag.book = new SelectList(db.Books, "Title");
             */

            return View(db.Borrows.ToList());
        }

        // GET: Borrows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrow borrow = db.Borrows.Find(id);
            if (borrow == null)
            {
                return HttpNotFound();
            }
            return View(borrow);
        }

        // GET: Borrows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReaderID,BookID,BorrowedSince,BorrowedTo")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                if(borrow.ReaderID>db.Readers.Count())
                {
                    ViewBag.ExceptionLabel = "There are only " + db.Readers.Count() + " readers.";
                    return View();
                }
                if (borrow.BookID > db.Books.Count())
                {
                    ViewBag.ExceptionLabel = "There are only " + db.Books.Count() + " books.";
                    return View();
                }
                foreach (Borrow b in db.Borrows)
                {
                    
                    if(borrow.BookID==b.BookID)
                    {
                        if (borrow.BorrowedSince >= borrow.BorrowedTo)
                        {
                            ViewBag.ExceptionLabel = "You have entered date since the book is borowed greater than date to when it is borrowed";
                            return View();
                        }
                        if(borrow.BorrowedSince >b.BorrowedSince&&borrow.BorrowedSince <b.BorrowedTo|| borrow.BorrowedTo < b.BorrowedTo && borrow.BorrowedTo > b.BorrowedSince)
                        {
                            ViewBag.ExceptionLabel = "The book isnt avaible to borrow at this date we are sorry.";
                            return View();
                        }
                    }
                }
                db.Borrows.Add(borrow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrow borrow = db.Borrows.Find(id);
            if (borrow == null)
            {
                return HttpNotFound();
            }
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ReaderID,BookID,BorrowedSince,BorrowedTo")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                foreach (Borrow b in db.Borrows)
                {
                    if (borrow.ReaderID > db.Readers.Count())
                    {
                        ViewBag.ExceptionLabel = "There are only " + db.Readers.Count() + " readers.";
                        return View();
                    }
                    if (borrow.BookID > db.Books.Count())
                    {
                        ViewBag.ExceptionLabel = "There are only " + db.Books.Count() + " books.";
                        return View();
                    }
                    if (borrow.BookID == b.BookID)
                    {
                        if (borrow.BorrowedSince >= borrow.BorrowedTo)
                        {
                            ViewBag.ExceptionLabel = "You have entered date since the book is borowed greater than date to when it is borrowed";
                            return View();
                        }
                        if (borrow.BorrowedSince > b.BorrowedSince && borrow.BorrowedSince < b.BorrowedTo || borrow.BorrowedTo < b.BorrowedTo && borrow.BorrowedTo > b.BorrowedSince)
                        {
                            ViewBag.ExceptionLabel = "The book isnt avaible to borrow at this date we are sorry.";
                            return View();
                        }
                    }
                }
                db.Entry(borrow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrow borrow = db.Borrows.Find(id);
            if (borrow == null)
            {
                return HttpNotFound();
            }
            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Borrow borrow = db.Borrows.Find(id);
            db.Borrows.Remove(borrow);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        

    
}
    

    
}
