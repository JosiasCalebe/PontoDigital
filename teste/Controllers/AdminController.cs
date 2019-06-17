using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teste.Repositorio;
using teste.ViewModels;

namespace teste.Controllers
{
    public class AdminController : Controller
    {
        DepoimentoRepositorio depoimentoRepositorio = new DepoimentoRepositorio();
         UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        public IActionResult Index()
        {
            
            ViewData["LoggedNome"] = HttpContext.Session.GetString("NomeLogado");
            ViewData["LoggedEmail"] = HttpContext.Session.GetString("EmailLogado");
            ViewData["LoggedSenha"] = HttpContext.Session.GetString("SenhaLogado");
            ViewData["UserAdmin"] = HttpContext.Session.GetString("AdminLogado");
            ViewBag.Users = usuarioRepositorio.ContarUsuarios();
            ViewBag.DepoimentosAprovados = depoimentoRepositorio.ContarDepoimentos("True");
            ViewBag.DepoimentosPendentes = depoimentoRepositorio.ContarDepoimentos("False");
            ViewBag.DepoimentosExcluidos = depoimentoRepositorio.ContarDepoimentos("Excluido");
            ViewBag.Depoimentos = ViewBag.DepoimentosAprovados + ViewBag.DepoimentosPendentes + ViewBag.DepoimentosExcluidos;
            var depoimentos = depoimentoRepositorio.ListarDepoimentos();
            ViewModel viewModel = new ViewModel();
            viewModel.Depoimentos = depoimentos;
            var usuarios = usuarioRepositorio.ListarUsuarios();
            viewModel.Usuarios = usuarios;
            return View(viewModel);
        }


    }
}