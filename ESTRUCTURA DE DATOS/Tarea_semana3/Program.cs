using System;

namespace RegistroEstudiante
{
    class Estudiante
    {
        public int Id;
        public string Nombres;
        public string Apellidos;
        public string Direccion;
        public string[] Telefonos; // Array para los números de teléfono

        public void MostrarDatos()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine("- " + Telefonos[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Estudiante estudiante = new Estudiante();

            estudiante.Id = 1;
            estudiante.Nombres = "Amy Mabel";
            estudiante.Apellidos = "Pardo Calle";
            estudiante.Direccion = "Santos Pamba";

            estudiante.Telefonos = new string[3];
            estudiante.Telefonos[0] = "0991111111";
            estudiante.Telefonos[1] = "0982222222";
            estudiante.Telefonos[2] = "0973333333";

            estudiante.MostrarDatos();

            Console.ReadKey();
        }
    }
}
