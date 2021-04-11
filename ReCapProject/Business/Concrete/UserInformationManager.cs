using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserInformationManager : IUserInformationService
    {
        IUserInformationDal _userInformationDal;
        public UserInformationManager(IUserInformationDal userInformationDal)
        {
            _userInformationDal = userInformationDal;
        }

        [ValidationAspect(typeof(UserInformationValidator))]
        public IResult Add(UserInformation userInformation)
        {
            _userInformationDal.Add(userInformation);
            return new SuccessResult(Messages.UserInformationAdded);
        }

        [ValidationAspect(typeof(UserInformationValidator))]
        public IResult Delete(UserInformation userInformation)
        {
            _userInformationDal.Delete(userInformation);
            return new SuccessResult(Messages.UserInformationDeleted);
        }

        [CacheAspect]
        public IDataResult<UserInformation> GetByUserId(int userId)
        {
            return new SuccessDataResult<UserInformation>(_userInformationDal.Get(u=> u.UserId==userId),Messages.GetUserInformationByUserId);
        }

        [ValidationAspect(typeof(UserInformationValidator))]
        public IResult Update(UserInformation userInformation)
        {
            _userInformationDal.Update(userInformation);
            return new SuccessResult(Messages.UserInformationUpdated);
        }
    }
}
