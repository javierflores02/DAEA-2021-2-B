﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio k -> 1
            //using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            //{
            //    var products = AWEntities.Product;
            //    IQueryable<string> productNames = from p in products
            //                                      select p.Name;
            //    Console.WriteLine("Productos:");
            //    foreach (var productName in productNames)
            //    {
            //        Console.WriteLine(productName);
            //    }
            //    Console.ReadKey();
            //}

            // Ejercicio k -> 2
            //using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            //{
            //    var products = AWEntities.Product;
            //    IQueryable<string> productNames = from p in products
            //                                      select p.Name;
            //    Console.WriteLine("Productos:");
            //    foreach (var productName in productNames)
            //    {
            //        Console.WriteLine(productName);
            //    }
            //    Console.ReadKey();
            //}

            // Ejercicio k -> 3
            //using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            //{
            //    var products = AWEntities.Product;
            //    IQueryable<Product> productsQuery = from p in products
            //                                        select p;
            //    IQueryable<Product> largeProducts = productsQuery.Where(p => p.Size == "L");
            //    Console.WriteLine("Productos de tamaño 'L':");
            //    foreach (var product in largeProducts)
            //    {
            //        Console.WriteLine(product.Name);
            //    }
            //    Console.ReadKey();
            //}

            // Ejercicio k -> 4
            //using (AdventureWorksEntities context = new AdventureWorksEntities())
            //{
            //    IQueryable<Product> productsQurey = from product in context.Product
            //                                        select product;
            //    Console.WriteLine("Productos:");
            //    foreach (var prod in productsQurey)
            //    {
            //        Console.WriteLine(prod.Name);
            //    }
            //    Console.ReadKey();
            //}

            // Ejercicio k -> 5
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from product in context.Product
                            select new
                            {
                                ProductId = product.ProductID,
                                ProductName = product.Name
                            };
                Console.WriteLine("Información de productos:");
                foreach (var productInfo in query)
                {
                    Console.WriteLine("Product Id: {0} Product Name: {1}",
                        productInfo.ProductId, productInfo.ProductName);
                }
                Console.ReadKey();
            }

        }
    }
}
