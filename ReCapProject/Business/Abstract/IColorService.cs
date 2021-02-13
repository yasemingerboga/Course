using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IColorService
    {
        List<Color> GetAll();
        void Insert(Color color);
        void Delete(Color color);
        void Update(Color color);
        Color GetById(int colorId);
    }
}
