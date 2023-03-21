using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(
          ILogger<PlanoContaController> logger,
          IPlanoContaService planoContaService
        )
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.ListaPlanoConta = _planoContaService.ListarRegistros();

            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                var registro = _planoContaService.RetornarRegistro((int)id);

                return View(registro);
            }

            return View();
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel model)
        {
            _planoContaService.Salvar(model);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _planoContaService.Excluir((int)id);
            return RedirectToAction("Index");
        }
    }
}