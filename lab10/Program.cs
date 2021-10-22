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

            //Consulta para obtener los productos cuyo nombre incluye la palabra queso
            var query_queso = from p in context.Products
                              where SqlMethods.Like(p.ProductName, "%Queso%")
                              select p;

            //Consulta para obtener los productos cuya presentacion sea paquetes (pkg o pkgs)
            var query_paquetes = from p in context.Products
                                 where SqlMethods.Like(p.QuantityPerUnit, "%pkg%")
                                 select p;

            //Consulta para obtener los productos que empiezan con la letra a
            var query_a = from p in context.Products
                          where SqlMethods.Like(p.ProductName, "A%")
                          select p;


            //Consulta para obtener los productos sin  stock
            var query_sin_stock = from p in context.Products
                                  where p.UnitsInStock == 0
                                  select p;

            //Consulta para obtener los productos descontonuados
            var query_descontonuados = from p in context.Products
                                       where p.Discontinued == true
                                       select p;

            //ejecucion de la consulta
            readQuery(query_queso, "Consulta para obtener los productos cuyo nombre incluye la palabra queso");
            readQuery(query_paquetes, "Consulta para obtener los productos cuya presentacion sea paquetes (pkg o pkgs)");
            readQuery(query_a, "Consulta para obtener los productos que empiezan con la letra a");
            readQuery(query_sin_stock, "Consulta para obtener los productos sin  stock");
            readQuery(query_descontonuados, "Consulta para obtener los productos descontonuados");

            Console.ReadKey();

        }

        private static void readQuery(IQueryable<dynamic> query, String msg)
        {
            Console.WriteLine("\n" + msg);
            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Name={1} ", prod.ProductID, prod.ProductName);
            }
        }
    }
}