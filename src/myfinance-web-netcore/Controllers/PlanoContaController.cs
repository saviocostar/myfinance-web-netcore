using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

    }
}