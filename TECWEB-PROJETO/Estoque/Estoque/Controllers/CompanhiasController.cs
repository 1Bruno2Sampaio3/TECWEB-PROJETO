using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleEstoque.Context;
using ControleEstoque.Models;
using Estoque.Filtros;

namespace Estoque.Controllers
{
    [AutorizacaoFilter]
    public class CompanhiasController : Controller
    {
        private EstoqueContext db = new EstoqueContext();

        // GET: Companhias
        public ActionResult Index()
        {
            return View(db.Companhias.ToList());
        }

        // GET: Companhias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = db.Companhias.Find(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // GET: Companhias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companhias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cnpj,Endereco")] Companhia companhia)
        {
            if (ModelState.IsValid)
            {
                db.Companhias.Add(companhia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companhia);
        }

        // GET: Companhias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = db.Companhias.Find(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // POST: Companhias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cnpj,Endereco")] Companhia companhia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companhia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companhia);
        }

        // GET: Companhias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = db.Companhias.Find(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // POST: Companhias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Companhia companhia = db.Companhias.Find(id);
            db.Companhias.Remove(companhia);
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
