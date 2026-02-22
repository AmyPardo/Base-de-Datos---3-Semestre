using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaniaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Crear el conjunto de 500 ciudadanos
                HashSet<string> ciudadanos = GenerarCiudadanos(500, "Ciudadano");

                // Crear conjuntos de vacunados
                HashSet<string> vacunadosPfizer = GenerarCiudadanos(75, "CiudadanoPfizer");
                HashSet<string> vacunadosAstraZeneca = GenerarCiudadanos(75, "CiudadanoAstraZeneca");

                // Asegurar que no haya duplicados entre los vacunados (un ciudadano no puede tener ambas vacunas)
                VacunadosSinDuplicados(ref vacunadosPfizer, ref vacunadosAstraZeneca);

                // Mostrar información general
                MostrarInformacionGeneral(ciudadanos, vacunadosPfizer, vacunadosAstraZeneca);

                // 1. Ciudadanos que no se han vacunado
                HashSet<string> noVacunados = ObtenerNoVacunados(ciudadanos, vacunadosPfizer, vacunadosAstraZeneca);
                MostrarListado("CIUDADANOS NO VACUNADOS", noVacunados);

                // 2. Ciudadanos que han recibido ambas dosis
                HashSet<string> ambasDosis = ObtenerAmbasDosis(vacunadosPfizer, vacunadosAstraZeneca);
                MostrarListado("CIUDADANOS CON AMBAS DOSIS", ambasDosis);

                // 3. Ciudadanos que solo han recibido la vacuna de Pfizer
                HashSet<string> soloPfizer = ObtenerSoloPfizer(vacunadosPfizer, vacunadosAstraZeneca);
                MostrarListado("CIUDADANOS SOLO CON VACUNA PFIZER", soloPfizer);

                // 4. Ciudadanos que solo han recibido la vacuna de AstraZeneca
                HashSet<string> soloAstraZeneca = ObtenerSoloAstraZeneca(vacunadosPfizer, vacunadosAstraZeneca);
                MostrarListado("CIUDADANOS SOLO CON VACUNA ASTRAZENECA", soloAstraZeneca);

                // Mostrar resumen estadístico
                MostrarResumenEstadistico(ciudadanos.Count, noVacunados.Count, 
                    soloPfizer.Count, soloAstraZeneca.Count, ambasDosis.Count);

                Console.WriteLine("\nPresione cualquier tecla para salir...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la ejecución: {ex.Message}");
            }
        }

        /// <summary>
        /// Genera un HashSet de ciudadanos con identificadores únicos
        /// </summary>
        static HashSet<string> GenerarCiudadanos(int cantidad, string prefijo)
        {
            var ciudadanos = new HashSet<string>();
            for (int i = 1; i <= cantidad; i++)
            {
                ciudadanos.Add($"{prefijo} {i}");
            }
            return ciudadanos;
        }

        /// <summary>
        /// Asegura que no haya ciudadanos duplicados entre las vacunas
        /// </summary>
        static void VacunadosSinDuplicados(ref HashSet<string> pfizer, ref HashSet<string> astraZeneca)
        {
            var duplicados = new HashSet<string>(pfizer.Intersect(astraZeneca));
            
            if (duplicados.Any())
            {
                Console.WriteLine($"Nota: Se encontraron {duplicados.Count} ciudadanos en ambos conjuntos de vacunados.");
                Console.WriteLine("Ajustando para que cada ciudadano tenga solo una vacuna...\n");
                
                // Eliminar duplicados del conjunto de AstraZeneca
                foreach (var ciudadano in duplicados)
                {
                    astraZeneca.Remove(ciudadano);
                }
            }
        }

        /// <summary>
        /// Obtiene ciudadanos no vacunados usando teoría de conjuntos
        /// </summary>
        static HashSet<string> ObtenerNoVacunados(HashSet<string> totalCiudadanos, 
            HashSet<string> pfizer, HashSet<string> astraZeneca)
        {
            var totalVacunados = new HashSet<string>(pfizer);
            totalVacunados.UnionWith(astraZeneca);
            
            var noVacunados = new HashSet<string>(totalCiudadanos);
            noVacunados.ExceptWith(totalVacunados);
            
            return noVacunados;
        }

        /// <summary>
        /// Obtiene ciudadanos con ambas dosis usando teoría de conjuntos
        /// </summary>
        static HashSet<string> ObtenerAmbasDosis(HashSet<string> pfizer, HashSet<string> astraZeneca)
        {
            var ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);
            return ambasDosis;
        }

        /// <summary>
        /// Obtiene ciudadanos que solo tienen vacuna Pfizer
        /// </summary>
        static HashSet<string> ObtenerSoloPfizer(HashSet<string> pfizer, HashSet<string> astraZeneca)
        {
            var soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);
            return soloPfizer;
        }

        /// <summary>
        /// Obtiene ciudadanos que solo tienen vacuna AstraZeneca
        /// </summary>
        static HashSet<string> ObtenerSoloAstraZeneca(HashSet<string> pfizer, HashSet<string> astraZeneca)
        {
            var soloAstraZeneca = new HashSet<string>(astraZeneca);
            soloAstraZeneca.ExceptWith(pfizer);
            return soloAstraZeneca;
        }

        /// <summary>
        /// Muestra información general de los conjuntos
        /// </summary>
        static void MostrarInformacionGeneral(HashSet<string> ciudadanos, 
            HashSet<string> pfizer, HashSet<string> astraZeneca)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("CAMPAÑA DE VACUNACIÓN COVID-19");
            Console.WriteLine("==========================================\n");
            
            Console.WriteLine($"Total de ciudadanos registrados: {ciudadanos.Count}");
            Console.WriteLine($"Total vacunados Pfizer: {pfizer.Count}");
            Console.WriteLine($"Total vacunados AstraZeneca: {astraZeneca.Count}");
            Console.WriteLine($"Total vacunados (general): {pfizer.Count + astraZeneca.Count}");
            Console.WriteLine("\n------------------------------------------\n");
        }

        /// <summary>
        /// Muestra un listado formateado
        /// </summary>
        static void MostrarListado(string titulo, HashSet<string> listado)
        {
            Console.WriteLine($" {titulo}");
            Console.WriteLine($"Total: {listado.Count} ciudadanos");
            
            if (listado.Any())
            {
                Console.WriteLine("Listado:");
                foreach (var ciudadano in listado.OrderBy(c => c))
                {
                    Console.WriteLine($"  • {ciudadano}");
                }
            }
            else
            {
                Console.WriteLine("  No hay ciudadanos en este listado.");
            }
            Console.WriteLine("\n------------------------------------------\n");
        }

        /// <summary>
        /// Muestra resumen estadístico
        /// </summary>
        static void MostrarResumenEstadistico(int totalCiudadanos, int noVacunados, 
            int soloPfizer, int soloAstraZeneca, int ambasDosis)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("RESUMEN ESTADÍSTICO");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Total ciudadanos: {totalCiudadanos}");
            Console.WriteLine($"No vacunados: {noVacunados} ({(noVacunados * 100.0 / totalCiudadanos):F1}%)");
            Console.WriteLine($"Solo Pfizer: {soloPfizer} ({(soloPfizer * 100.0 / totalCiudadanos):F1}%)");
            Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca} ({(soloAstraZeneca * 100.0 / totalCiudadanos):F1}%)");
            Console.WriteLine($"Ambas dosis: {ambasDosis} ({(ambasDosis * 100.0 / totalCiudadanos):F1}%)");
            Console.WriteLine($"Total vacunados: {soloPfizer + soloAstraZeneca + ambasDosis} " +
                $"{((soloPfizer + soloAstraZeneca + ambasDosis) * 100.0 / totalCiudadanos):F1}%)");
        }
    }
}
