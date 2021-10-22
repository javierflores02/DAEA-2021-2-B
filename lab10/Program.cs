using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Origen de datos
            NorthwndDataContext context = new NorthwndDataContext();


            //Creacion de la consulta
            var query = from p in context.Products
                        where p.UnitPrice < 20
                        select p;

            //Ejecución de la consulta
            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Price={1} \t Name={2} ", prod.ProductID, prod.UnitPrice, prod.ProductName);
            }

            Console.ReadKey();

        }
    }
}