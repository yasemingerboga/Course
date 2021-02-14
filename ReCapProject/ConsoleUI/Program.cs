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
            //InMemoryTest();
            //EntityFrameworkTest();
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.CarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("ID: " + car.CarId + "Name: " + car.CarName + " Brand: " + car.BrandName + " Color: " + car.ColorName);
                }
            }
        }

        private static void EntityFrameworkTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Before: ");
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }

            Car car = new Car { BrandId = 3, ColorId = 1, DailyPrice = 120, Descriptions = "Porsche", ModelYear = 2021 };
            var result1 = carManager.Add(car);
            result = carManager.GetAll();
            if (result1.Success && result.Success)
            {
                Console.WriteLine("After adding process: ");
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }
            car.DailyPrice = 100;
            var result2 = carManager.Update(car);
            result = carManager.GetAll();
            if (result2.Success && result.Success)
            {
                Console.WriteLine("After updating process: ");
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }
            var result3 = carManager.Delete(car);
            result = carManager.GetAll();
            if (result3.Success && result.Success)
            {
                Console.WriteLine("After deletion process: ");
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }
            Console.WriteLine("-----------------------------------------------");
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("Before: ");
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }
            Car car = new Car { CarId = 6, BrandId = 3, ColorId = 1, DailyPrice = 120, Descriptions = "Porsche", ModelYear = 2021 };
            var result1 = carManager.Add(car);
            result = carManager.GetAll();
            if(result1.Success && result.Success)
            {
                Console.WriteLine("After adding process: ");
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }     
            Car car1 = new Car { CarId = 6, BrandId = 3, ColorId = 1, DailyPrice = 100, Descriptions = "Porsche", ModelYear = 2021 };
            var result2 = carManager.Update(car1);
            result = carManager.GetAll();
            if (result1.Success && result.Success)
            {
                Console.WriteLine("After updating process: ");
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }
            var result3 = carManager.Delete(car1);
            result = carManager.GetAll();
            if (result1.Success && result.Success)
            {
                Console.WriteLine("Car with ID number 6 is deleted. After deletion process: ");
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.Descriptions + " Daily Price is: " + c.DailyPrice + "$");
                }
            }
            Console.WriteLine("-----------------------------------------------");
            //Car car2 = carManager.GetById(3);
            //Console.WriteLine("(input ID = 3) Car with ID number : " + car2.Id + " " + car2.Descriptions);
        }
    }
}
