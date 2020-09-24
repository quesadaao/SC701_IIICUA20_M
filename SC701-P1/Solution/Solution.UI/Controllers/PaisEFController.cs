using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solution.UI.Services;

namespace Solution.UI.Controllers
{
    public class PaisEFController : Controller
    {
        public IRepositoryPaisEF repo { get; }

        public PaisEFController(IRepositoryPaisEF repositorio)
        {
            repo = repositorio;
        }

        public IActionResult Index()
        {
            return View(repo.ObtenerTodos());
        }
    }
}
