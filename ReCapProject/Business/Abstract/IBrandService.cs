using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Insert(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<Brand> GetById(int brandId);
    }
}
