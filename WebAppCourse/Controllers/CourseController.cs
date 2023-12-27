﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppCourse.Models;

namespace WebAppCourse.Controllers
{
    public class CourseController : Controller
    {
        private CourseEntities1 db = new CourseEntities1();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.CourseTables.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTable courseTable = db.CourseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CId,CName,CFee,Technology,Status")] CourseTable courseTable)
        {
            if (ModelState.IsValid)
            {
                db.CourseTables.Add(courseTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseTable);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTable courseTable = db.CourseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CId,CName,CFee,Technology,Status")] CourseTable courseTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseTable);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTable courseTable = db.CourseTables.Find(id);
            if (courseTable == null)
            {
                return HttpNotFound();
            }
            return View(courseTable);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseTable courseTable = db.CourseTables.Find(id);
            db.CourseTables.Remove(courseTable);
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
