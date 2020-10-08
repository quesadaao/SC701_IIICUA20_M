using Microsoft.AspNetCore.Mvc;
using Solution.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.UI.ViewComponents
{
    public class PaisesViewComponent : ViewComponent
    {
        public IRepositoryPaisEF repositoryPaisEF { get; set; }

        public PaisesViewComponent(IRepositoryPaisEF repository) {
            repositoryPaisEF = repository;        
        }

        public IViewComponentResult Invoke() 
        {
            return View(repositoryPaisEF.ObtenerTodos());        
        }
    }
}
