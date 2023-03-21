using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;
        private readonly ITipoPagamentoService _tipoPagamentoService;

        public TransacaoController(
          ILogger<TransacaoController> logger,
          ITransacaoService transacaoService,
          IPlanoContaService planoContaService,
          ITipoPagamentoService tipoPagamentoService
        )
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
            _tipoPagamentoService = tipoPagamentoService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.ListaTransacoes = _transacaoService.ListarRegistros();

            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            var model = new TransacaoModel();

            if (id != null)
            {
                model = _transacaoService.RetornarRegistro((int)id);
            }

            var listaPlanoConta = _planoContaService.ListarRegistros();
            var listaTipoPagamento = _tipoPagamentoService.ListarRegistros();
            model.PlanoContas = new SelectList(listaPlanoConta, "Id", "Descricao");
            model.TiposPagamento = new SelectList(listaTipoPagamento, "Id", "Tipo");

            return View(model);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(TransacaoModel model)
        {
            _transacaoService.Salvar(model);
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
            _transacaoService.Excluir((int)id);
            return RedirectToAction("Index");
        }
    }
}