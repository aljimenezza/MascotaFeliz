using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria  // Repositorio implementa los metodos de la interfaz IRepositorio
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;  // Define un objeto AppContext, _appContext es el nombre de la variable
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioHistoria(AppContext appContext) // Metodo Constructor, recibe un AppContext y lo almacena en appContext
        {
            _appContext = appContext; // lo que se recibe en appContext se le asigna a la variable de la clase _appContext
        }

        public Historia AddHistoria(Historia historia)
        {
            var historiaAdicionado = _appContext.Historias.Add(historia); // En la tabla agrega ja historia
            _appContext.SaveChanges();  // Guarda el cambio
            return historiaAdicionado.Entity;
        }

        public void DeleteHistoria(int idHistoria)
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrado == null)
                return;
            _appContext.Historias.Remove(historiaEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Historia> GetAllHistoria()
        {
            return GetAllHistoria_();
        }

        public IEnumerable<Historia> GetAllHistoria_()
        {
            return _appContext.Historias;
        }

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
        }

        public Historia UpdateHistoria(Historia historia)
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(d => d.Id == historia.Id);
            if (historiaEncontrado != null)
            {
                historiaEncontrado.FechaInicial = historia.FechaInicial;
                _appContext.SaveChanges();
            }
            return historiaEncontrado;
        }     

        public Historia AsignarHistoria(int idMascota, int idHistoria)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if(mascotaEncontrado != null)
            {
                var historiaEncontrado = _appContext.Historias.FirstOrDefault(v => v.Id == idHistoria);
                if (historiaEncontrado != null)
                {   
                    mascotaEncontrado.Historia = historiaEncontrado;
                    _appContext.SaveChanges();
                }
                return historiaEncontrado;
            }
            return  null;
        }
    }
}