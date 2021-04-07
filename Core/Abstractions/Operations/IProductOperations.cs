using NorthWndCore.BusinessModels;
using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Operations
{
    public interface IProductOperations
    {
        public ProductViewModel Get(int id);
        public IEnumerable<ProductViewModel> GetAll();
        public Product Update(ProductViewModel model);
        public Product Add(ProductViewModel model);
        public void Delete(int id);

        IEnumerable<ProductsNeedReordering> GetProductsneedreorderings();
        IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings();

    }
}
