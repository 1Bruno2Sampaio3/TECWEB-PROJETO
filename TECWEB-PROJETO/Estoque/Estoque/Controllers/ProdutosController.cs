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
    public class ProdutosController : Controller
    {
        private EstoqueContext db = new EstoqueContext();
        [Route("produtos", Name = "ListaProdutos")]
        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produtos.ToList());
        }

        
        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.Fornecedores = new SelectList(db.Fornecedores.ToList(), "Id", "Nome");
            ViewBag.Categorias = new SelectList(db.Categorias.ToList(), "Id", "Nome");

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Quantidade,CodigoExterno,FornecedorId,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);

            ViewBag.Fornecedores = new SelectList(db.Fornecedores.ToList(), "Id", "Nome");
            ViewBag.Categorias = new SelectList(db.Categorias.ToList(), "Id", "Nome");

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from  attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Quantidade,CodigoExterno,FornecedorId,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DecrementaQtd(int id)
        {
            var produto = db.Produtos.Where(x => x.Id == id).ToList().FirstOrDefault();
            
            if(produto != null)
            {
                if (produto.Quantidade > 0)
                {
                    produto.Quantidade--;
                    db.SaveChanges();
                }
                
            }

            return Json(produto);
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
