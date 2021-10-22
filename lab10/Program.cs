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
                        where p.Categories.CategoryName == "Beverages"
                        select p;

            //Ejecución de la consulta
            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);
            }

            Console.ReadKey();

        }
    }
}