using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudAssignment.Models;

namespace CloudAssignment.Controllers
{
    public class ExpensesController : Controller
    {
        private anushaDBEntities db = new anushaDBEntities();
        // GET: Expenses
        [Authorize(Roles = "Supervisor")]
        public ActionResult Index()
        {
            return View(db.Expenses.ToList());
        }
        [Authorize(Roles = "Supervisor,Employee")]
        public ActionResult Details(string id = null)
        {

            Expens expens = db.Expenses.Find(id);
            if (expens == null)
            {
                return HttpNotFound();
            }
            return View(expens);
        }


        // GET: /CRUD/Create  
        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /CRUD/Create  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expens expens)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expens);
        }


        // GET: /CRUD/Edit/5  

        //public ActionResult Edit(string id = null)
        //{
        //    Expens expens = db.Expenses.Find(id);
        //    if (expens == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expens);
        //}

        ////  
        //// POST: /CRUD/Edit/5  

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Expens expens)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(expens).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(expens);
        //}

        //  
        //GET: /CRUD/Delete/5  

        //public ActionResult Delete(string id = null)
        //{
        //    Expens expens = db.Expenses.Find(id);
        //    if (expens == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expens);
        //}

        ////  
        //// POST: /CRUD/Delete/5  

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Expens expens = db.Expenses.Find(id);
        //    db.Expenses.Remove(expens);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}