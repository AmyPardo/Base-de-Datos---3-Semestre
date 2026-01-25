using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Se crean las tres pilas que representan las torres
    static Stack<int> origen = new Stack<int>();
    static Stack<int> auxiliar = new Stack<int>();
    static Stack<int> destino = new Stack<int>();

    static void Main()
    {
        int n = 3; // Número de discos

        // Se colocan los discos en la torre de origen
        // El disco más grande queda abajo y el más pequeño arriba
        for (int i = n; i >= 1; i--)
            origen.Push(i);

        // Se llama al método recursivo para resolver el problema
        ResolverHanoi(n, origen, destino, auxiliar,
                      "Origen", "Destino", "Auxiliar");
    }

    static void ResolverHanoi(int n, Stack<int> origen,
                              Stack<int> destino, Stack<int> auxiliar,
                              string nombreOrigen, string nombreDestino,
                              string nombreAuxiliar)
    {
        // Caso base: si solo hay un disco, se mueve directamente
        if (n == 1)
        {
            int disco = origen.Pop(); // Sacamos el disco de la torre origen
            destino.Push(disco);      // Lo colocamos en la torre destino
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            return;
        }

        // Paso 1: mover n-1 discos de origen a auxiliar
        ResolverHanoi(n - 1, origen, auxiliar, destino,
                      nombreOrigen, nombreAuxiliar, nombreDestino);

        // Paso 2: mover el disco más grande al destino
        int discoActual = origen.Pop();
        destino.Push(discoActual);
        Console.WriteLine($"Mover disco {discoActual} de {nombreOrigen} a {nombreDestino}");

        // Paso 3: mover los discos de auxiliar a destino
        ResolverHanoi(n - 1, auxiliar, destino, origen,
                      nombreAuxiliar, nombreDestino, nombreOrigen);
    }
}
