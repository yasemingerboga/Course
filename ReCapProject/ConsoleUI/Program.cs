using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car{ ID=1, BrandID=1, ColorID=1, DailyPrice=45, Description="Megane", ModelYear=2007},
                new Car{ ID=2, BrandID=1, ColorID=2, DailyPrice=55, Description="Megane", ModelYear=2020},
                new Car{ ID=3, BrandID=2, ColorID=2, DailyPrice=50, Description="Mini Cooper", ModelYear=2010},
                new Car{ ID=4, BrandID=3, ColorID=3, DailyPrice=90, Description="Porsche ", ModelYear=2020},
                new Car{ ID=5, BrandID=3, ColorID=4, DailyPrice=80, Description="Porsche ", ModelYear=2015},
            };
            ICarDal carDal = new InMemoryCarDal(cars);
            CarManager carManager = new CarManager(carDal);

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
