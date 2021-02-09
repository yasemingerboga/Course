using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category {CategoryId=1, CategoryName="Bilgisayar"},
                new Category {CategoryId=1, CategoryName="Telefon"},
            };
            List<Product> products = new List<Product>
            {
                new Product { ProductID=1,CategoryID=1, ProductName="Acer Laptop", QuantityPerUnit="32GB Ram", UnitPrice=10000, UnitInStock=5},
                new Product { ProductID=2,CategoryID=1, ProductName="Asus Laptop", QuantityPerUnit="16GB Ram", UnitPrice=8000, UnitInStock=2},
                new Product { ProductID=3,CategoryID=1, ProductName="Hp Laptop", QuantityPerUnit="8GB Ram", UnitPrice=6000, UnitInStock=2},
                new Product { ProductID=4,CategoryID=2, ProductName="Samsung Laptop", QuantityPerUnit="4GB Ram", UnitPrice=5000, UnitInStock=15},
                new Product { ProductID=5,CategoryID=2, ProductName="Apple Laptop", QuantityPerUnit="4GB Ram", UnitPrice=8000, UnitInStock=0},
            };
            Console.WriteLine("----------------Algoritmik------------------");
            foreach (var product in products)
            {
                if(product.UnitPrice>5000 && product.UnitInStock > 3)
                {
                    Console.WriteLine(product.ProductName) ;
                }
            }
            Console.WriteLine("----------------Linq------------------");
            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
            getProdcts(products);
            getProdctsLinq(products);
        }
        static List<Product> getProdcts(List<Product> products)
        {
            List<Product> filteredProduct = new List<Product>();
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitInStock > 3)
                {
                    filteredProduct.Add(product);
                }
            }
            return filteredProduct;
        }
        static List<Product> getProdctsLinq(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3).ToList();
        }
        class Product
        {
            public int ProductID { get; set; }
            public int CategoryID { get; set; }
            public string ProductName { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitInStock { get; set; }
        }
        class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
