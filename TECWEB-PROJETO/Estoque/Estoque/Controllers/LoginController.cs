using ControleEstoque.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estoque.Controllers
{
    public class LoginController : Controller
    {
        private EstoqueContext db = new EstoqueContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            var usuario = db.Usuarios.Where(x => x.Email == login && x.Senha == senha).FirstOrDefault();
            if(usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Produtos");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}