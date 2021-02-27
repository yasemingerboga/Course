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
                new Product { ProductID=2,CategoryID=1, ProductName="Asus Laptop", QuantityPerUnit="16GB Ram", UnitPrice=18000, UnitInStock=2},
                new Product { ProductID=3,CategoryID=1, ProductName="Hp Laptop", QuantityPerUnit="8GB Ram", UnitPrice=18000, UnitInStock=2},
                new Product { ProductID=4,CategoryID=2, ProductName="Samsung", QuantityPerUnit="4GB Ram", UnitPrice=5000, UnitInStock=15},
                new Product { ProductID=5,CategoryID=2, ProductName="Apple", QuantityPerUnit="4GB Ram", UnitPrice=8000, UnitInStock=0},
            };
            //Test(products);
            //AnyTest(products);
            //FindTest(products);
            //FindAllTest(products);
            //OrderBy(products);
            //AscDescTest(products);
            //FromInSelectTest(products);
            //FromWhereOrderBySelectTest(products);
            //ClassicLinqTest(products);
            //?
            var result = from p in products join c in categories
                         on p.CategoryID equals c.CategoryId
                         where p.UnitPrice>5000
                         orderby p.UnitPrice descending
                         select new ProductDTO { ProductID = p.ProductID, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
            foreach (var productDto in result)
            {
                Console.WriteLine("{0} --- {1}",productDto.ProductName,productDto.CategoryName);
            }
            //?
        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice > 6000
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDTO { ProductID = p.ProductID, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FromWhereOrderBySelectTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice > 6000
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select p;
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FromInSelectTest(List<Product> products)
        {
            var result = from p in products
                         select p;
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            //Single Line Query
            //Eger ayni isimde ayni UnitPrice'a sahip datalar varsa onları da kendi arasinda sıralar.
            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void OrderBy(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice);
            var result1 = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("----------");
            foreach (var product in result1)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            Product result = products.Find(p => p.ProductID == 3);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");
            Console.WriteLine(result);
        }

        private static void Test(List<Product> products)
        {
            Console.WriteLine("----------------Algoritmik------------------");
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
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
        class ProductDTO
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public string CategoryName { get; set; }
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
