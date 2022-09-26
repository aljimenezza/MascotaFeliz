using System;
using System.Collections; // para uso de listas
using System.Collections.Generic; // para uso de listas 
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> GetAllHistoria();  // Devuelve lista de elementos
        Historia AddHistoria(Historia historia); 
        Historia UpdateHistoria(Historia historia);
        void DeleteHistoria(int idHistoria);
        Historia GetHistoria(int idHistoria);
       // IEnumerable<Historia> GetHistoriaPorFiltro(String filtro); 
        Historia AsignarHistoria(int idMascota, int idHistoria);
    }
}