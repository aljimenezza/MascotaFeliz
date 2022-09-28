using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetallesVisitasPyPModel : PageModel
    {
       private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        public VisitaPyP visitaPyP {get;set;}
        
        public DetallesVisitasPyPModel()
        {
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        }
        
        public IActionResult OnGet(int visitaPyPId)
        {
            visitaPyP = _repoVisitaPyP.GetVisitaPyP(visitaPyPId);
            if (visitaPyP == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
