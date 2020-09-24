using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using Solution.UI.Services;

namespace Solution.UI.Controllers
{
    [Authorize]
    public class PaisController : Controller
    {
        public IRepositorioPais repo { get; }

        public PaisController(IRepositorioPais repositorio) 
        {
            repo = repositorio;         
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //throw new ApplicationException("Ha ocurrido algo malo");
            //List<string> paises = new List<string>() { "Ghana", "Japon", "Costa Rica","Ecuador" };
            return View(repo.ObtenerTodos());
        }
    }
}
