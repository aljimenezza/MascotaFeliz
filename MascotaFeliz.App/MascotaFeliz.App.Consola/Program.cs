using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // AddDueno();
            // BuscarDueno(1);
            // ListarDuenos();
            // AddVeterinario();
            // BuscarVeterinario(3);
            // ListarVeterinarios();
            // AddMascota();
            // BuscarMascota(1);
            // ListarMascotas();
        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Liliana",
                Apellidos = "Jimenez",
                Direccion = "Copacabana",
                Telefono = "2742423",
                Correo = "liajiza@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

        private static void ListarDuenos()
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
            {
                Console.WriteLine(d.Nombres + " " + d.Apellidos);
            }
        }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Pibe",
                Apellidos = "Valderrama",
                Direccion = "Bucaramanga",
                Telefono = "15425874",
                TarjetaProfesional = "3335458"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
        }

        private static void ListarVeterinarios()
        {
            var veterinario = _repoVeterinario.GetAllVeterinarios();
            foreach (Veterinario v in veterinario)
            {
                Console.WriteLine(v.Nombres + " " + v.Apellidos);
            }
        }


        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Polo",
                Color = "Café",
                Raza = "Cocker Spaniel",
                Especie = "Canino",
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Raza + " " + mascota.Especie);
        }

        private static void ListarMascotas()
        {
            var mascota = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascota)
            {
                Console.WriteLine(m.Nombre + " " + m.Especie);
            }
        }
        
        private static void AsignarVisitaPyP(int idHistoria)
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null)
                {
                    historia.VisitasPyP.Add(new VisitaPyP { FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema"});
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>{
                        new VisitaPyP{FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema" }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
        }

    }
}
