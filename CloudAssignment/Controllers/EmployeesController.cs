﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudAssignment.Models;

namespace CloudAssignment.Controllers
{
    [Authorize(Roles = "Supervisor,Employee")]
    public class EmployeesController : Controller
    {
       
        private anushaDBEntities db = new anushaDBEntities();

        //  
        // GET: /CRUD/  
       
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult EmployeeHome()
        {
            Employee stu = (Employee)Session["userEmployee"];
           
            return View(stu);
        }
        //  
        // GET: /CRUD/Details/5  
        
        public ActionResult Details(string id = null)
        {
            
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
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
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //  
        // GET: /CRUD/Edit/5  
       
        public ActionResult Edit(string id = null)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //  
        // POST: /CRUD/Edit/5  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //  
       // GET: /CRUD/Delete/5  

        //public ActionResult Delete(string id = null)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        ////  
        //// POST: /CRUD/Delete/5  

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    db.Employees.Remove(employee);
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
