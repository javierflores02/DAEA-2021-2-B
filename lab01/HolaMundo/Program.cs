using System;

namespace HolaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¿Cuál es tu nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Hola " + nombre);
        }
    }
}
