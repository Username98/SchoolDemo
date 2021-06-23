using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SchoolDemo.Models;

namespace SchoolDemo.Controllers
{

    public class EmployeeAndClassController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: EmplyeeAndClass
        public ActionResult Index()
        {
            var EaC = db.EmployeeAndClasses.Include(e => e.c).Include(e => e.employee);
            return View(EaC);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList classes = new SelectList(db.Classes, "Id", "ClassName");
            ViewBag.Classes = classes;
            SelectList employees = new SelectList(db.Employees, "Id", "FullName", "Position", db.Employees.First().Id);
            ViewBag.Employees = employees;
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeAndClass EaC)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAndClasses.Add(EaC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList classes = new SelectList(db.Classes, "Id", "ClassName", EaC.ClassId);
            ViewBag.Classes = classes;
            SelectList employees = new SelectList(db.Employees, "Id", "FullName", "Position", EaC.EmployeeId);
            ViewBag.Employees = employees;

            return View(EaC);

        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            EmployeeAndClass EaC = db.EmployeeAndClasses.Find(id);

            SelectList classes = new SelectList(db.Classes, "Id", "ClassName", EaC.ClassId);
            ViewBag.Classes = classes;
            SelectList employees = new SelectList(db.Employees, "Id", "FullName", "Position", EaC.EmployeeId);
            ViewBag.Employees = employees;
            if (EaC != null)
            {
                return View(EaC);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(EmployeeAndClass EaC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(EaC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList classes = new SelectList(db.Classes, "Id", "ClassName", EaC.ClassId);
            ViewBag.Classes = classes;
            SelectList employees = new SelectList(db.Employees, "Id", "FullNmae", "Position", EaC.EmployeeId);
            ViewBag.Employees = employees;
            return View(EaC);
        }
        public ActionResult Delete(int? id)
        {
            EmployeeAndClass EaC = db.EmployeeAndClasses.Find(id);
            db.EmployeeAndClasses.Remove(EaC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}