using Core.DataAccess.EntityFramework;
using Core.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDatabaseContext>,IRentalDal
    {
        public IResult CheckAvailability(DateTime rentDate, int carId)
        {
            List<RentalDetailDto> rentals = GetRentalDetails(c=>c.ReturnDate >= rentDate && c.CarId==carId);
            if (rentals.Count == 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentId = r.RentalId,
                                 CarName = c.Name,
                                 CustomerName = u.FirstName,
                                 CustomerSurname = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
