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
    public class AgregarVisitasPyPModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        private readonly IRepositorioVeterinario _repoVeterinario;
        
        [BindProperty]
        public VisitaPyP visitaPyP { get; set; }
        public Veterinario veterinario { get; set; }
        public Historia historia { get; set; }
        public IEnumerable<Veterinario> listaVeterinarios { get; set; }

        public AgregarVisitasPyPModel()
        {
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public void OnGet(int? visitaPyPId)
        {
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();

            if (visitaPyPId.HasValue)
            {
                visitaPyP = _repoVisitaPyP.GetVisitaPyP(visitaPyPId.Value);
            }
            else
            {
                visitaPyP = new VisitaPyP();
            }

            Page();

        }

        public IActionResult OnPost(VisitaPyP visitaPyP, int veterinarioId)
        {
            if (ModelState.IsValid)
            {
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                
                historia = new Historia
                {
                    FechaInicial = new DateTime(2020, 01, 01)


                };


                
                if (visitaPyP.Id > 0)
                {
                    visitaPyP.Veterinario = veterinario;
                    
                    visitaPyP = _repoVisitaPyP.UpdateVisitaPyP(visitaPyP);
                }
                else
                {
                    visitaPyP = _repoVisitaPyP.AddVisitaPyP(visitaPyP);
                    _repoVisitaPyP.AsignarVeterinario(visitaPyP.Id, veterinario.Id);
                }
                return RedirectToPage("/Visitas/ListaVisitasPyP");

            }
            else
            {
                return Page();
            }
        }
    }
}
