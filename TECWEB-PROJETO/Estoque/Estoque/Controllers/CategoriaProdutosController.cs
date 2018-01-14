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
    public class CategoriaProdutosController : Controller
    {
        private EstoqueContext db = new EstoqueContext();
        [Route("categorias")]
        // GET: CategoriaProdutos
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        // GET: CategoriaProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.Categorias.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProdutos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categoriaProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.Categorias.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // POST: CategoriaProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.Categorias.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // POST: CategoriaProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaProduto categoriaProduto = db.Categorias.Find(id);
            db.Categorias.Remove(categoriaProduto);
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
