using System;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;
    
    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    private Nodo cabeza;
    
    public void Agregar(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        if (cabeza == null)
            cabeza = nuevo;
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
    }
    
    public void EliminarFueraDeRango(int min, int max)
    {
        // Eliminar nodos al inicio fuera de rango
        while (cabeza != null && (cabeza.Dato < min || cabeza.Dato > max))
        {
            cabeza = cabeza.Siguiente;
        }
        
        // Eliminar nodos en medio fuera de rango
        Nodo actual = cabeza;
        while (actual != null && actual.Siguiente != null)
        {
            if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                actual.Siguiente = actual.Siguiente.Siguiente;
            else
                actual = actual.Siguiente;
        }
    }
    
    public void Mostrar()
    {
        Nodo actual = cabeza;
        int contador = 0;
        while (actual != null)
        {
            Console.Write(actual.Dato + " ");
            actual = actual.Siguiente;
            contador++;
            if (contador % 10 == 0) Console.WriteLine();
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        ListaEnlazada lista = new ListaEnlazada();
        
        // Crear lista con 50 números aleatorios
        for (int i = 0; i < 50; i++)
        {
            lista.Agregar(rnd.Next(1, 1000));
        }
        
        Console.WriteLine("Lista original (50 números aleatorios 1-999):");
        lista.Mostrar();
        
        Console.Write("\nIngrese valor mínimo del rango: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Ingrese valor máximo del rango: ");
        int max = int.Parse(Console.ReadLine());
        
        lista.EliminarFueraDeRango(min, max);
        
        Console.WriteLine("\nLista después de eliminar fuera del rango:");
        lista.Mostrar();
    }
}