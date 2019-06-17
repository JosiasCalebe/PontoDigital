using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teste.Models;
using teste.Repositorio;
using teste.ViewModels;

namespace teste.Controllers {
    public class DepoimentosController : Controller {

        DepoimentoRepositorio depoimentoRepositorio = new DepoimentoRepositorio();


        public IActionResult Index () {
            ViewData["LoggedNome"] = HttpContext.Session.GetString("NomeLogado");
            ViewData["LoggedEmail"] = HttpContext.Session.GetString("EmailLogado");
            ViewData["LoggedSenha"] = HttpContext.Session.GetString("SenhaLogado");
            ViewData["UserAdmin"] = HttpContext.Session.GetString("AdminLogado");
            var depoimentos = depoimentoRepositorio.ListarDepoimentos();
            ViewModel depoimento = new ViewModel();
            depoimento.Depoimentos = depoimentos;
            return View(depoimento);
        }
        public IActionResult Cadastrar (IFormCollection form) {
            Depoimento depoimento = new Depoimento ();
            depoimento.Nome = HttpContext.Session.GetString("NomeLogado");
            depoimento.Profissao = form["profissao"];
            depoimento.Texto = form["mensagem"];
            depoimento.Aprovado = "False";

            depoimentoRepositorio.Cadastrar (depoimento);

            return RedirectToAction ("Index");
        }

        public IActionResult Aprovar (IFormCollection form){
            Depoimento depoimento = depoimentoRepositorio.ProcurarDepoimento(int.Parse(form["item-id"]));
            depoimentoRepositorio.TrocarLinha($"{depoimento.Id};{depoimento.Nome};{depoimento.Profissao};{depoimento.Texto};{depoimento.Data};True", "Database/depoimentos.csv", int.Parse(form["item-id"]));
            return RedirectToAction ("Index");
        }
        public IActionResult Excluir (IFormCollection form){
            Depoimento depoimento = depoimentoRepositorio.ProcurarDepoimento(int.Parse(form["item-id"]));
            depoimentoRepositorio.TrocarLinha($"{depoimento.Id};{depoimento.Nome};{depoimento.Profissao};{depoimento.Texto};{depoimento.Data};Excluido", "Database/depoimentos.csv", int.Parse(form["item-id"]));
            return RedirectToAction ("Index");
        }
    }
}