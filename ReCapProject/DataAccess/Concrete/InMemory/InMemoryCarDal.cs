using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{ CarId=1, BrandId=1, ColorId=1, DailyPrice=45, Descriptions="Megane", ModelYear=2007, Name="Megane"},
                new Car{ CarId=2, BrandId=1, ColorId=2, DailyPrice=55, Descriptions="Megane", ModelYear=2020, Name="Megane"},
                new Car{ CarId=3, BrandId=2, ColorId=2, DailyPrice=50, Descriptions="Mini Cooper", ModelYear=2010, Name="Mini Cooper"},
                new Car{ CarId=4, BrandId=3, ColorId=3, DailyPrice=90, Descriptions="Porsche ", ModelYear=2020, Name="Porsche"},
                new Car{ CarId=5, BrandId=3, ColorId=4, DailyPrice=80, Descriptions="Porsche ", ModelYear=2015, Name="Porsche"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Name == car.Name);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetByID(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.CarId = car.CarId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Name = car.Name;
        }
    }
}
