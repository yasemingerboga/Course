using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        public IResult Add(Rental rental)
        {
            //var available = _rentalDal.GetRentalDetails(r => ((r.CarId == rental.CarId) && ((r.ReturnDate != null)|| (r.ReturnDate == null && r.RentDate == null))));
            var availableForDeleteMethod = _carDal.Get(r => (r.CarId == rental.CarId));
            if ( availableForDeleteMethod.AvailableStatus==0)
            {
                Console.WriteLine("Car is not available.");
                return new ErrorResult(Messages.NotAvailable);
            }
            _rentalDal.Add(rental);
            availableForDeleteMethod.AvailableStatus = 0;
            _carDal.Update(availableForDeleteMethod);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            var result = _carDal.Get(c => c.CarId == rental.CarId);
            result.AvailableStatus = 1;
            _carDal.Update(result);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==id), Messages.RentalGetById);
        }

        public IDataResult<List<RentalDetailDto>> RentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return filter == null 
                ?  new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetails)
                :  new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter), Messages.RentalDetails);

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
