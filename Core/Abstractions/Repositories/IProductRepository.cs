using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<ProductsNeedReordering> GetProductsneedreorderings();
        IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings();
    }
}
