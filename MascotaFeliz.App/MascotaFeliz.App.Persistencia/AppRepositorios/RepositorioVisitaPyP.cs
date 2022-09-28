using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisitaPyP : IRepositorioVisitaPyP
    {
        /// <summary>
        /// Referencia al contexto de VisitaPyP
        /// </summary>


        private readonly AppContext _appContext;


        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioVisitaPyP(AppContext appContext)
        {
            _appContext = appContext;
        }

        public VisitaPyP AddVisitaPyP(VisitaPyP visitaPyP)
        {
            var visitaPyPAdicionado = _appContext.VisitasPyP.Add(visitaPyP);
            _appContext.SaveChanges();
            return visitaPyPAdicionado.Entity;
        }

        public void DeleteVisitaPyP(int idVisitaPyP)
        {
            var visitaPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == idVisitaPyP);
            if (visitaPyPEncontrado == null)
                return;
            _appContext.VisitasPyP.Remove(visitaPyPEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<VisitaPyP> GetAllVisitasPyP()
        {
            return GetAllVisitaPyPs_();
        }

        public IEnumerable<VisitaPyP> GetAllVisitaPyPs_()
        {
            return _appContext.VisitasPyP;
        }

        public VisitaPyP GetVisitaPyP(int idVisitaPyP)
        {
            return _appContext.VisitasPyP.Include("Veterinario").Include("Historia").FirstOrDefault(d => d.Id == idVisitaPyP);
        }

        public VisitaPyP UpdateVisitaPyP(VisitaPyP visitaPyP)
        {
            var visitaPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == visitaPyP.Id);
            if (visitaPyPEncontrado != null)
            {
                visitaPyPEncontrado.FechaVisita = visitaPyP.FechaVisita;
                visitaPyPEncontrado.Temperatura = visitaPyP.Temperatura;
                visitaPyPEncontrado.Peso = visitaPyP.Peso;
                visitaPyPEncontrado.FrecuenciaRespiratoria = visitaPyP.FrecuenciaRespiratoria;
                visitaPyPEncontrado.FrecuenciaCardiaca = visitaPyP.FrecuenciaCardiaca;
                visitaPyPEncontrado.EstadoAnimo = visitaPyP.EstadoAnimo;
                visitaPyPEncontrado.Veterinario = visitaPyP.Veterinario;
                visitaPyPEncontrado.Historia = visitaPyP.Historia;
                visitaPyPEncontrado.Recomendaciones = visitaPyP.Recomendaciones;


                _appContext.SaveChanges();
            }
            return visitaPyPEncontrado;
        }

        public Veterinario AsignarVeterinario(int idVisitaPyP, int idVeterinario)
        {
            var visitaPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(m => m.Id == idVisitaPyP);
            if (visitaPyPEncontrado != null)
            {
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
                if (veterinarioEncontrado != null)
                {
                    visitaPyPEncontrado.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;
        }   

        public Historia AsignarHistoria(int idVisitaPyP, int idHistoria)
        {
            var visitaPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(m => m.Id == idVisitaPyP);
            if (visitaPyPEncontrado != null)
            {
                var historiaEncontrado = _appContext.Historias.FirstOrDefault(v => v.Id == idHistoria);
                if (historiaEncontrado != null)
                {
                    visitaPyPEncontrado.Historia = historiaEncontrado;
                    _appContext.SaveChanges();
                }
                return historiaEncontrado;
            }
            return null;
        }

    }
}