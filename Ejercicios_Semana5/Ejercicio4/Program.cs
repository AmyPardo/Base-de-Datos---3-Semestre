using System;
using System.Collections.Generic;

class ContadorVocales
{
    public Dictionary<char, int> Contar(string palabra)
    {
        Dictionary<char, int> vocales = new Dictionary<char, int>
        {
            {'a',0}, {'e',0}, {'i',0}, {'o',0}, {'u',0}
        };

        foreach (char c in palabra)
        {
            if (vocales.ContainsKey(c))
                vocales[c]++;
        }

        return vocales;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine().ToLower();

        ContadorVocales contador = new ContadorVocales();
        var resultado = contador.Contar(palabra);

        Console.WriteLine("Cantidad de vocales:");
        foreach (var v in resultado)
        {
            Console.WriteLine($"{v.Key}: {v.Value}");
        }
    }
}

