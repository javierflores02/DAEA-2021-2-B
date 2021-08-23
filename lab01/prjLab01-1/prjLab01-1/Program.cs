using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLab01_1
{
    class Program
    {
        static Tuple<int, int> GetData()
        {
            Console.WriteLine("Ingrese el primer valor: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo valor: ");
            int y = Convert.ToInt32(Console.ReadLine());
            var tuple = new Tuple<int, int>(x, y);
            return tuple;
        }
        static int Operacion(int a, int b, string ope)
        {
            switch (ope)
            {
                case "-":
                    return a - b;
                case "+":
                    return a + b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
            }
            return 0;
        }
        
        static void Raiz()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raíz cuadrada de {0} es {1}", i, Math.Sqrt(i));
            }
        }
        static void Primos()
        {
            int cant = 1;
            string primos = "";
            for(int i=2; cant <= 10; i++)
            {
                int contador = 2;
                bool primo = true;
                while ((primo) && (contador != i))
                {
                    if (i % contador == 0)
                        primo = false;
                    contador++;
                }
                if (primo)
                {
                    primos = primos + i + ((cant != 10) ? "," : ".");
                    cant++;
                }
            }
            Console.WriteLine("Los primeros diez primos son: " + primos);
        }

        static double Temperaturas(int valor, string tipo)
        {
            if (tipo.Equals("c-f"))
            {
                return (valor * 9) / 5 + 32;
            }
            else
            {
                return 5 * (valor - 32) / 9;
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y funciones";
            String opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Suma de dos números");
                Console.WriteLine("2. Resta de dos números");
                Console.WriteLine("3. Multiplicación de dos números");
                Console.WriteLine("4. División de dos números");
                Console.WriteLine("5. Imprimir raíz cuadrada de los 10 primeros enteros");
                Console.WriteLine("6. Imprimir los diez primeros primos");
                Console.WriteLine("7. Convertir de Celsius a Farenheit");
                Console.WriteLine("8. Convertir de Farenheit a Celsius");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Ingrese una opción.");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        var datos_s = GetData();
                        Console.WriteLine("La suma de {0} y {1} es: {2}", datos_s.Item1, datos_s.Item2, Operacion(datos_s.Item1, datos_s.Item2, "+"));
                        Console.ReadKey();
                        break;
                    case "2":
                        var datos_r = GetData();
                        Console.WriteLine("La resta de {0} y {1} es: {2}", datos_r.Item1, datos_r.Item2, Operacion(datos_r.Item1, datos_r.Item2, "-"));
                        Console.ReadKey();
                        break;
                    case "3":
                        var datos_m = GetData();
                        Console.WriteLine("La multiplicación de {0} y {1} es: {2}", datos_m.Item1, datos_m.Item2, Operacion(datos_m.Item1, datos_m.Item2, "*"));
                        Console.ReadKey();
                        break;
                    case "4":
                        var datos_d = GetData();
                        Console.WriteLine("La división de {0} y {1} es: {2}", datos_d.Item1, datos_d.Item2, Operacion(datos_d.Item1, datos_d.Item2, "/"));
                        Console.ReadKey();
                        break;
                    case "5":
                        Raiz();
                        Console.ReadKey();
                        break;
                    case "6":
                        Primos();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("Ingrese la temperatura en Celsius: ");
                        int tmp_c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("El resultado de la conversión de {0}C° es: {1}F", tmp_c, Temperaturas(tmp_c, "c-f"));
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.WriteLine("Ingrese la temperatura en Farenheit:");
                        int tmp_f = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("El resultado de la conversión de {0}F es: {1}C°", tmp_f, Temperaturas(tmp_f, "f-c"));
                        Console.ReadKey();
                        break;
                }
            } while (!opcion.Equals("0"));
        }
    }
}
