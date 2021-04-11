using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserInformationService
    {
        IResult Add(UserInformation userInformation);
        IResult Delete(UserInformation userInformation);
        IResult Update(UserInformation userInformation);
        IDataResult<UserInformation> GetByUserId(int userId);
    }
}
