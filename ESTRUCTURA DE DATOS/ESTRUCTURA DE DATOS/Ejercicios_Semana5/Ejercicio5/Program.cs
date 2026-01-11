using System;
using System.Collections.Generic;
using System.Linq;

class Precios
{
    public int ObtenerMenor(List<int> precios)
    {
        return precios.Min();
    }

    public int ObtenerMayor(List<int> precios)
    {
        return precios.Max();
    }
}

class Program
{
    static void Main()
    {
        List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };

        Precios p = new Precios();

        Console.WriteLine("Precio menor: " + p.ObtenerMenor(precios));
        Console.WriteLine("Precio mayor: " + p.ObtenerMayor(precios));
    }
}
