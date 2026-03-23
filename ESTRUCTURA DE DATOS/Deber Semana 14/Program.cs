using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    // Constructor del nodo
    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBST
{
    public Nodo Raiz;

    // Metodo para insertar un valor en el arbol
    public Nodo Insertar(Nodo raiz, int valor)
    {
        if (raiz == null)
            return new Nodo(valor);

        if (valor < raiz.Valor)
            raiz.Izquierdo = Insertar(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = Insertar(raiz.Derecho, valor);

        return raiz;
    }

    // Metodo para buscar un valor en el arbol
    public bool Buscar(Nodo raiz, int valor)
    {
        if (raiz == null) return false;
        if (raiz.Valor == valor) return true;

        if (valor < raiz.Valor)
            return Buscar(raiz.Izquierdo, valor);
        else
            return Buscar(raiz.Derecho, valor);
    }

    // Metodo para encontrar el valor minimo
    public Nodo Minimo(Nodo raiz)
    {
        while (raiz.Izquierdo != null)
            raiz = raiz.Izquierdo;
        return raiz;
    }

    // Metodo para encontrar el valor maximo
    public Nodo Maximo(Nodo raiz)
    {
        while (raiz.Derecho != null)
            raiz = raiz.Derecho;
        return raiz;
    }

    // Metodo para eliminar un nodo
    public Nodo Eliminar(Nodo raiz, int valor)
    {
        if (raiz == null) return raiz;

        if (valor < raiz.Valor)
            raiz.Izquierdo = Eliminar(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = Eliminar(raiz.Derecho, valor);
        else
        {
            // caso cuando no tiene hijos
            if (raiz.Izquierdo == null && raiz.Derecho == null)
                return null;

            // caso cuando tiene un hijo
            if (raiz.Izquierdo == null)
                return raiz.Derecho;
            else if (raiz.Derecho == null)
                return raiz.Izquierdo;

            // caso cuando tiene dos hijos
            Nodo temp = Minimo(raiz.Derecho);
            raiz.Valor = temp.Valor;
            raiz.Derecho = Eliminar(raiz.Derecho, temp.Valor);
        }
        return raiz;
    }

    // recorrido inorden
    public void Inorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Inorden(raiz.Izquierdo);
            Console.Write(raiz.Valor + " ");
            Inorden(raiz.Derecho);
        }
    }

    // recorrido preorden
    public void Preorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Console.Write(raiz.Valor + " ");
            Preorden(raiz.Izquierdo);
            Preorden(raiz.Derecho);
        }
    }

    // recorrido postorden
    public void Postorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Postorden(raiz.Izquierdo);
            Postorden(raiz.Derecho);
            Console.Write(raiz.Valor + " ");
        }
    }

    // calcular altura del arbol
    public int Altura(Nodo raiz)
    {
        if (raiz == null) return -1;
        int izq = Altura(raiz.Izquierdo);
        int der = Altura(raiz.Derecho);
        return Math.Max(izq, der) + 1;
    }

    // limpiar todo el arbol
    public void Limpiar()
    {
        Raiz = null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBST arbol = new ArbolBST();
        int opcion;
        int valor;

        do
        {
            Console.WriteLine("\nMENU ARBOL BINARIO DE BUSQUEDA");
            Console.WriteLine("1 Insertar valor");
            Console.WriteLine("2 Buscar valor");
            Console.WriteLine("3 Eliminar valor");
            Console.WriteLine("4 Mostrar Inorden");
            Console.WriteLine("5 Mostrar Preorden");
            Console.WriteLine("6 Mostrar Postorden");
            Console.WriteLine("7 Mostrar minimo");
            Console.WriteLine("8 Mostrar maximo");
            Console.WriteLine("9 Mostrar altura");
            Console.WriteLine("10 Limpiar arbol");
            Console.WriteLine("0 Salir");
            Console.Write("Seleccione una opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Insertar(arbol.Raiz, valor);
                    break;

                case 2:
                    Console.Write("Valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    if (arbol.Buscar(arbol.Raiz, valor))
                        Console.WriteLine("El valor si existe en el arbol");
                    else
                        Console.WriteLine("El valor no existe");
                    break;

                case 3:
                    Console.Write("Valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Eliminar(arbol.Raiz, valor);
                    break;

                case 4:
                    Console.WriteLine("Recorrido Inorden:");
                    arbol.Inorden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Recorrido Preorden:");
                    arbol.Preorden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Recorrido Postorden:");
                    arbol.Postorden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 7:
                    if (arbol.Raiz != null)
                        Console.WriteLine("Minimo: " + arbol.Minimo(arbol.Raiz).Valor);
                    else
                        Console.WriteLine("El arbol esta vacio");
                    break;

                case 8:
                    if (arbol.Raiz != null)
                        Console.WriteLine("Maximo: " + arbol.Maximo(arbol.Raiz).Valor);
                    else
                        Console.WriteLine("El arbol esta vacio");
                    break;

                case 9:
                    Console.WriteLine("Altura del arbol: " + arbol.Altura(arbol.Raiz));
                    break;

                case 10:
                    arbol.Limpiar();
                    Console.WriteLine("Arbol eliminado completamente");
                    break;
            }

        } while (opcion != 0);
    }
}
