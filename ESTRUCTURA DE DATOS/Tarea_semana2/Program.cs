using System;

// Clase Cuadrado con encapsulamiento
public class Cuadrado
{
    // Atributo privado (encapsulado)
    private double lado;

    // Constructor del cuadrado
    public Cuadrado(double lado)
    {
        this.lado = lado;
    }

    // Método para calcular el área del cuadrado
    // Fórmula: lado * lado
    public double CalcularArea()
    {
        return lado * lado;
    }

    // Método para calcular el perímetro del cuadrado
    // Fórmula: 4 * lado
    public double CalcularPerimetro()
    {
        return 4 * lado;
    }
}

// Clase Triangulo con encapsulamiento
public class Triangulo
{
    // Atributos privados
    private double baseT;
    private double altura;
    private double lado1;
    private double lado2;
    private double lado3;

    // Constructor del triángulo
    // Requiere base, altura y los 3 lados para el perímetro
    public Triangulo(double baseT, double altura, double lado1, double lado2, double lado3)
    {
        this.baseT = baseT;
        this.altura = altura;
        this.lado1 = lado1;
        this.lado2 = lado2;
        this.lado3 = lado3;
    }

    // Método para calcular el área
    // Fórmula del área: (base * altura) / 2
    public double CalcularArea()
    {
        return (baseT * altura) / 2;
    }

    // Método para calcular el perímetro
    // Fórmula: suma de sus lados
    public double CalcularPerimetro()
    {
        return lado1 + lado2 + lado3;
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        // Crear objeto Cuadrado
        Cuadrado cuadrado = new Cuadrado(5); // Lado = 5

        Console.WriteLine("=== CUADRADO ===");
        Console.WriteLine("Área del cuadrado: " + cuadrado.CalcularArea());
        Console.WriteLine("Perímetro del cuadrado: " + cuadrado.CalcularPerimetro());

        // Crear objeto Triángulo
        Triangulo triangulo = new Triangulo(6, 4, 5, 6, 7);

        Console.WriteLine("\n=== TRIÁNGULO ===");
        Console.WriteLine("Área del triángulo: " + triangulo.CalcularArea());
        Console.WriteLine("Perímetro del triángulo: " + triangulo.CalcularPerimetro());
    }
}
