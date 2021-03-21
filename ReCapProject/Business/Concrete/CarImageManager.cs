using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var fileUpload = FileHelper.AddAsync(file);
            IResult result = BusinessRules.Run(CheckCountOfCarImages(carImage.CarId), fileUpload);
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = fileUpload.Data;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(FileHelper.DeleteAsync(carImage.ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter), Messages.CarImageAdded);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId), Messages.CarImageAdded);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var fileUpload = FileHelper.UpdateAsync(_carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId).ImagePath, file);
            var result = BusinessRules.Run(fileUpload);
            if (result != null)
            {
                return result;
            }
            CarImage carImagetoUpdate = _carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId);
            if (carImagetoUpdate == null)
            {
                return new ErrorResult();
            }
            carImagetoUpdate.ImagePath = fileUpload.Data;
            carImagetoUpdate.Date = DateTime.Now;
            _carImageDal.Update(carImagetoUpdate);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        private IResult CheckCountOfCarImages(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\Logo.png";
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result.Count()<5)
            {
                List<CarImage> carsDefaultLogoImages = new List<CarImage>();
                carsDefaultLogoImages = result;
                for (int i = result.Count(); i < 5; i++)
                {
                    carsDefaultLogoImages.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                }
                return carsDefaultLogoImages;
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }
    }
}