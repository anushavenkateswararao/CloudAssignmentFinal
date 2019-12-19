using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudAssignment.Models;

namespace CloudAssignment.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class SupervisorsController : Controller
    {
        private anushaDBEntities db = new anushaDBEntities();

        //  
        // GET: /CRUD/  
      
        public ActionResult Index()
        {
            return View(db.Supervisors.ToList());
        }

        public ActionResult SupervisorHome()
        {
            Supervisor stu = (Supervisor)Session["userSupervisor"];
           // Student stu = (Student)Session["userStudent"];
            return View(stu);
        }
        //  
        // GET: /CRUD/Details/5  

        public ActionResult Details(string id = null)
        {

            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        //  
        // GET: /CRUD/Create  

        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /CRUD/Create  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                db.Supervisors.Add(supervisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supervisor);
        }


        // GET: /CRUD/Edit/5  

        public ActionResult Edit(string id = null)
        {
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        //  
        // POST: /CRUD/Edit/5  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supervisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supervisor);
        }

        //  
        //GET: /CRUD/Delete/5  

        public ActionResult Delete(string id = null)
        {
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        //  
        // POST: /CRUD/Delete/5  

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Supervisor supervisor = db.Supervisors.Find(id);
            db.Supervisors.Remove(supervisor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}