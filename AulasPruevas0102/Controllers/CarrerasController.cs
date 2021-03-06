﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AulasPruevas0102.Models;

namespace AulasPruevas0102.Controllers
{
    public class CarrerasController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        // GET: Carreras
        public ActionResult Index()
        {
            var carreras = db.Carreras.Include(c => c.Facultad);
            return View(carreras.ToList());
        }

        // GET: Carreras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "Nombre");
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCarrera,IdFacultad,Nombre")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Carreras.Add(carrera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "Nombre", carrera.IdFacultad);
            return View(carrera);
        }

        // GET: Carreras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "Nombre", carrera.IdFacultad);
            return View(carrera);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCarrera,IdFacultad,Nombre")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "Nombre", carrera.IdFacultad);
            return View(carrera);
        }

        // GET: Carreras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.Carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrera carrera = db.Carreras.Find(id);
            db.Carreras.Remove(carrera);
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
