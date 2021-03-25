using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IResult isValid(int carId)
        {
            List<Rental> rentalCars = _rentalDal.GetAll(r => r.CarId == carId).ToList();
            foreach (var car in rentalCars)
            {
                if (car.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalGetByCarId);
                }
            }
            return new SuccessResult(Messages.RentalGetByCarId);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), Messages.RentalGetById);
        }

        public IDataResult<List<RentalDetailDto>> RentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return filter == null
                ? new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetails)
                : new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter), Messages.RentalDetails);

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
