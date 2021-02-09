using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ ID=1, BrandID=1, ColorID=1, DailyPrice=45, Description="Megane", ModelYear=2007},
                new Car{ ID=2, BrandID=1, ColorID=2, DailyPrice=55, Description="Megane", ModelYear=2020},
                new Car{ ID=3, BrandID=2, ColorID=2, DailyPrice=50, Description="Mini Cooper", ModelYear=2010},
                new Car{ ID=4, BrandID=3, ColorID=3, DailyPrice=90, Description="Porsche ", ModelYear=2020},
                new Car{ ID=5, BrandID=3, ColorID=4, DailyPrice=80, Description="Porsche ", ModelYear=2015},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.ID == car.ID);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetByID(int id)
        {
            return _cars.SingleOrDefault(c => c.ID == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.ID == car.ID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ID = car.ID;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
