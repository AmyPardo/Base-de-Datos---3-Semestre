using System;
using System.Collections.Generic;

class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }

    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }
}

class Program
{
    static void Main()
    {
        List<Asignatura> asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas"),
            new Asignatura("Física"),
            new Asignatura("Química"),
            new Asignatura("Historia"),
            new Asignatura("Lengua")
        };

        foreach (var a in asignaturas)
        {
            Console.Write($"Ingrese la nota de {a.Nombre}: ");
            a.Nota = double.Parse(Console.ReadLine());
        }

        asignaturas.RemoveAll(a => a.Nota >= 7);

        Console.WriteLine("\nAsignaturas que debe repetir:");
        foreach (var a in asignaturas)
        {
            Console.WriteLine(a.Nombre);
        }
    }
}
