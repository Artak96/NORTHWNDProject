using NorthWndCore.Abstractions.Repositories;
using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NorthWndDAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(NORTHWNDContext context) : base(context)
        {

        }

        public IEnumerable<ProductsNeedReordering> GetProductsneedreorderings()
        {
            var query = from product in context.Products
                        where product.UnitsInStock < product.ReorderLevel
                        orderby product.ProductId
                        select new ProductsNeedReordering
                        {
                            Productid = product.ProductId,
                            ProductName = product.ProductName,
                            UnitsInStock = product.UnitsInStock,
                            ReorderLevel = product.ReorderLevel
                        };
            return query.ToList();

        }

        public IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings()
        {
            var query = from product in context.Products
                        where (product.UnitsInStock + product.UnitsOnOrder) <= product.ReorderLevel
                        where product.Discontinued == false
                        orderby product.ProductId
                        select new ProductsThatNeedReordering
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            UnitsInStock = product.UnitsInStock,
                            UnitsOnOrder = product.UnitsOnOrder,
                            ReorderLevel = product.ReorderLevel,
                            Discontinued = product.Discontinued
                        };
            return query.ToList();
        }
    }
}
