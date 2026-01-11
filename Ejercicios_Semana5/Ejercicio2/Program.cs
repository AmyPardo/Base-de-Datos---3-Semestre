using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<char> abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            if ((i + 1) % 3 == 0)
            {
                abecedario.RemoveAt(i);
            }
        }

        Console.WriteLine("Abecedario resultante:");
        Console.WriteLine(string.Join(", ", abecedario));
    }
}
