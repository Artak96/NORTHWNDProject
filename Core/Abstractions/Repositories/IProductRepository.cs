using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<ProductsNeedReordering> GetProductsneedreorderings();
        IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings();
    }
}
