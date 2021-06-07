using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Net5.Model.Models;


namespace Net5.IServices
{
    public interface IAdvertisementServices : IBaseServices<Advertisement>
    {

        int Add(Advertisement model);
        bool Delete(Advertisement model);
        bool Update(Advertisement model);
        List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression);

        int Sum(int i, int j);
    }
}
