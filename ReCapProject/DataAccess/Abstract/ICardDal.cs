using Core.DataAccess;
using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICardDal : IEntityRepository<Card>
    {
    }
}
