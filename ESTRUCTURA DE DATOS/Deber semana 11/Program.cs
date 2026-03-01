using System;
using System.Collections.Generic;
using System.Linq;

class Traductor
{
    static void Main()
    {
        // Diccionario Español -> Inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"forma", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"niña", "child"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"tema", "point"},
            {"gobierno", "government"},
            {"empresa", "company"},
            {"compañía", "company"}
            
        };

        int opcion;

        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la frase: ");
        string frase = Console.ReadLine().ToLower();

        string[] palabras = frase.Split(' ');
        string traduccion = "";

        foreach (string palabra in palabras)
        {
            string palabraLimpia = palabra.Trim(',', '.', ';', ':', '¿', '?', '¡', '!');
            
            if (diccionario.ContainsKey(palabraLimpia))
            {
                traduccion += diccionario[palabraLimpia] + " ";
            }
            else
            {
                traduccion += palabra + " ";
            }
        }

        Console.WriteLine("\nTraducción parcial:");
        Console.WriteLine(traduccion);
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en español: ");
        string esp = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en inglés: ");
        string ing = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(esp))
        {
            diccionario.Add(esp, ing);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
