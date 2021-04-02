using Core.BusinessModels;
using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Operations
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
