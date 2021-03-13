using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectDatabaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new ReCapProjectDatabaseContext())
            {
                var resut = from operationClaim in context.OperationClaims
                            join userOperationClaim in context.UserOperationClaims
                            on operationClaim.Id equals userOperationClaim.OperationClaimId
                            where operationClaim.Id == user.Id
                            select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return resut.ToList();
            }
        }
    }
}
