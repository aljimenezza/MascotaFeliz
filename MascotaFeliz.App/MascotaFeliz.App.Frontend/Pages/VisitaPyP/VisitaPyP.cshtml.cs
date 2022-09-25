using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Persistencia;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class VisitaPyPModel : PageModel
    {
        private readonly IRepositorioVisitaPyP repositorioVisitaPyP;
        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        [BindProperty]
        public VisitaPyP VisitaPyP  { get; set; } 

        public IEnumerable<Veterinario> veterinarios {get; set;}

        public VisitaPyPModel(IRepositorioVisitaPyP repositorioVisitaPyP)
        {
            this.repositorioVisitaPyP = new RepositorioVisitaPyP(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? visitaPyPId)
        {   
            veterinarios = repositorioVeterinario.GetAllVeterinarios();
            
            if (visitaPyPId.HasValue)
            {
                VisitaPyP = repositorioVisitaPyP.GetVisitaPyP(visitaPyPId.Value);
            }
            else
            {
                VisitaPyP = new VisitaPyP();
            }
            if (VisitaPyP == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                if(VisitaPyP.Id>0)
                {
                    VisitaPyP = repositorioVisitaPyP.UpdateVisitaPyP(VisitaPyP);
                }
                else
                {
                    repositorioVisitaPyP.AddVisitaPyP(VisitaPyP);
                }
                return Page();
            }
            else
            {            
                return Page();
            }
        } 
    }
}