using System;
using System.Collections.Generic;

class ParentesisBalanceados
{
    static void Main()
    {
        // Expresión que se va a evaluar
        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";

        // Llamamos al método que verifica si la expresión está balanceada
        if (EstaBalanceada(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula no balanceada.");
    }

    static bool EstaBalanceada(string expresion)
    {
        // Creamos una pila para guardar los símbolos de apertura
        Stack<char> pila = new Stack<char>();

        // Recorremos cada carácter de la expresión
        foreach (char c in expresion)
        {
            // Si es un símbolo de apertura, lo guardamos en la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si es un símbolo de cierre
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, significa que no hay con qué cerrar
                if (pila.Count == 0)
                    return false;

                // Sacamos el último símbolo de apertura
                char apertura = pila.Pop();

                // Verificamos si el símbolo de apertura coincide con el de cierre
                if (!Coinciden(apertura, c))
                    return false;
            }
        }

        // Si la pila queda vacía al final, la expresión está bien balanceada
        return pila.Count == 0;
    }

    static bool Coinciden(char apertura, char cierre)
    {
        // Verifica que cada símbolo de apertura tenga su cierre correcto
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }
}
