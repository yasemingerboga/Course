using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        List<Brand> GetAll();
        void Insert(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
        Brand GetById(int brandId);
    }
}
