using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SchoolDemo.Filters;

namespace SchoolDemo.Controllers
{
    public class PupilController : Controller
    {
        // GET: Pupil
        SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            var pupils = db.Pupils.Include(p => p.c);
            return View(pupils);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList classes = new SelectList(db.Classes, "Id", "ClassName");
            ViewBag.Classes = classes;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Pupil pupil)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Pupils.Add(pupil);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Ex ="Возникла ошибка. Текст ошибки:"+ ex.Message.ToString();
                }
            }
            SelectList classes = new SelectList(db.Classes, "Id", "ClassName");
            ViewBag.Classes = classes;

            return View(pupil);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Pupil pupil = db.Pupils.Find(id);

            SelectList classes = new SelectList(db.Classes, "Id", "ClassName", pupil.ClassId);
            ViewBag.Classes = classes;
            if (pupil != null)
            {
                return View(pupil);
            }
            return HttpNotFound();
        }


        [HttpPost]
        [DbSaveException]
        public ActionResult Edit(Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pupil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList classes = new SelectList(db.Classes, "Id", "ClassName", pupil.ClassId); ;
            ViewBag.Classes = classes;
            return View(pupil);
        }

        public ActionResult Delete(int? id)
        {
            Pupil pupil = db.Pupils.Find(id);
            db.Pupils.Remove(pupil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
