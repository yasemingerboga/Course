using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryTest();
            EntityFrameworkTest();
        }

        private static void EntityFrameworkTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Before: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            Car car = new Car { BrandId = 3, ColorId = 1, DailyPrice = 120, Descriptions = "Porsche", ModelYear = 2021 };
            carManager.Add(car);
            Console.WriteLine("After adding process: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            car.DailyPrice = 100;
            carManager.Update(car);
            Console.WriteLine("After updating process: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Delete(car);
            Console.WriteLine("After deletion process: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
            }
            Console.WriteLine("-----------------------------------------------");
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("Before: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.ID + " " + c.Description + " Daily Price is: " + c.DailyPrice + "$");
            }
            Car car = new Car { ID = 6, BrandID = 3, ColorID = 1, DailyPrice = 120, Description = "Porsche", ModelYear = 2021 };
            carManager.Add(car);
            Console.WriteLine("After adding process: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.ID + " " + c.Description + " Daily Price is: " + c.DailyPrice + "$");
            }
            Car car1 = new Car { ID = 6, BrandID = 3, ColorID = 1, DailyPrice = 100, Description = "Porsche", ModelYear = 2021 };
            carManager.Update(car1);
            Console.WriteLine("After updating process: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.ID + " " + c.Description + " Daily Price is: " + c.DailyPrice + "$");
            }
            carManager.Delete(car1);
            Console.WriteLine("Car with ID number 6 is deleted. After deletion process: ");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.ID + " " + c.Description + " Daily Price is: " + c.DailyPrice + "$");
            }
            Console.WriteLine("-----------------------------------------------");
            Car car2 = carManager.GetByID(3);
            Console.WriteLine("(input ID = 3) Car with ID number : " + car2.ID + " " + car2.Description);
        }
    }
}
