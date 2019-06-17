using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teste.Models;
using teste.Repositorio;

namespace teste.Controllers
{

    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            ViewData["LoggedNome"] = HttpContext.Session.GetString("NomeLogado");
            ViewData["LoggedEmail"] = HttpContext.Session.GetString("EmailLogado");
            ViewData["LoggedSenha"] = HttpContext.Session.GetString("SenhaLogado");
            ViewData["UserAdmin"] = HttpContext.Session.GetString("AdminLogado");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){
            Usuario usuario = new Usuario(
                nome: form["nome"],
                sobrenome: form["sobrenome"],
                email: form["email"],
                senha: form["senha"],
                dataNascimento: DateTime.Parse(form["datanascimento"])
            );
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

            usuarioRepositorio.Cadastrar(usuario);

            TempData["mensagem"] = "Usuario cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form){
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            Usuario user = usuarioRepositorio.ProcurarUsuario(form["emailLogin"], form["senhaLogin"]);
            if(user != null){
                    HttpContext.Session.SetString("NomeLogado", user.Nome);
                    HttpContext.Session.SetString("EmailLogado", user.Email);
                    HttpContext.Session.SetString("SenhaLogado", user.Senha);
                    HttpContext.Session.SetString("AdminLogado", user.Admin);
                if (user.Admin == "True"){
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Depoimentos");
            };
            return RedirectToAction("Index");
        }

        [HttpGet]  
        public IActionResult Logoff(){
            HttpContext.Session.Remove("NomeLogado");
            HttpContext.Session.Remove("EmailLogado");
            HttpContext.Session.Remove("SenhaLogado");
            HttpContext.Session.Remove("AdminLogado");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
