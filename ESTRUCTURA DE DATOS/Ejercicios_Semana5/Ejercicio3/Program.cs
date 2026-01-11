using System;
using System.Linq;

class Palindromo
{
    public bool EsPalindromo(string palabra)
    {
        string invertida = new string(palabra.Reverse().ToArray());
        return palabra == invertida;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine().ToLower();

        Palindromo p = new Palindromo();

        if (p.EsPalindromo(palabra))
            Console.WriteLine("Es un palíndromo.");
        else
            Console.WriteLine("No es un palíndromo.");
    }
}

