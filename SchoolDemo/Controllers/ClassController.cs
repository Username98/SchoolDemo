using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDemo.Controllers
{
    public class ClassController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: Class
        public ActionResult Index()
        {
            return View(db.Classes);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Class c)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Class c = db.Classes.Find(id);

            if (c != null)
            {
                return View(c);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Class c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public ActionResult Delete(int? id)
        {
            Class c = db.Classes.Find(id);
            db.Classes.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}