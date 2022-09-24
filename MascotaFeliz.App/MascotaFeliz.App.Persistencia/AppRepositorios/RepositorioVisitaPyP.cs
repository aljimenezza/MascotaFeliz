// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MascotaFeliz.App.Dominio;
// using Microsoft.EntityFrameworkCore;

// namespace MascotaFeliz.App.Persistencia
// {
//     public class RepositorioVisitaPyP : IRepositorioVisitaPyP
//     {
//         private readonly AppContext _appContext;

//         public RepositorioVisitaPyP(AppContext appContext)
//         {
//             _appContext = appContext;
//         }

//         public VisitaPyP AddVisitaPyP(VisitaPyP visitaPyP)
//         {
//             var visitaPyPNuevo = _appContext.VisitasPyP.Add(visitaPyP);
//             _appContext.SaveChanges();
//             return visitaPyPNuevo.Entity;
//         }

//         public VisitaPyP UpdateVisita(VisitaPyP visitaPyP)
//         {
//             var visitaPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == visitaPyP.Id);
//             if(visitaPyPEncontrado != null)
//             {
//                 visitaPyPEncontrado.Temperatura = visitaPyP.Temperatura;
//                 visitaPyPEncontrado.Peso = visitaPyP.Peso;
//                 visitaPyPEncontrado.FrecuenciaRespiratoria = visitaPyP.FrecuenciaRespiratoria;
//                 visitaPyPEncontrado.FrecuenciaCardiaca = visitaPyP.FrecuenciaCardiaca;
//                 visitaPyPEncontrado.EstadoAnimo = visitaPyP.EstadoAnimo;
//                 visitaPyPEncontrado.FechaVisita = visitaPyP.FechaVisita;
//                 visitaPyPEncontrado.Recomendaciones = visitaPyP.Recomendaciones;
//                 visitaPyPEncontrado.IdVeterinario = visitaPyP.IdVeterinario;
//                 _appContext.SaveChanges();
//             }
//             return visitaPyPEncontrado;
//         }

//         public void DeleteVisitaPyP(int idVisitaPyP)
//         {
//             var visitaPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == idVisitaPyP);
//             if (visitaPyPEncontrado == null)
//                 return;
//             _appContext.VisitasPyP.Remove(visitaPyPEncontrado);
//             _appContext.SaveChanges();
//         }

//         public IEnumerable<VisitaPyP> GetAllVisitasPyP()
//         {
//             return GetAllVisitasPyP_();
//         }

//         public IEnumerable<VisitaPyP> GetVisitaPyPFiltro(VisitaPyP visitaPyP)
//         {
//             var visitasPyP = GetAllVisitasPyP();
//             if (visitasPyP != null)
//             {
//                 if(!String.IsNullOrEmpty(visitaPyP.EstadoAnimo))
//                 {
//                     visitasPyP = visitasPyP.Where(s => s.EstadoAnimo.Contains(visitaPyP.EstadoAnimo));
//                 }
//             }
//             return visitasPyP;
//         }
        
//         public IEnumerable<VisitaPyP> GetAllVisitasPyP_()
//         {
//             return _appContext.VisitasPyP;
//         }

//         public VisitaPyP GetVisitaPyP(int idVisitaPyP)
//         {
//             return _appContext.VisitasPyP.FirstOrDefault(d => d.Id == idVisitaPyP);
//         }

//     }
// }