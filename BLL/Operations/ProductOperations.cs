using NorthWndCore.Abstractions;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using NorthWndCore.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWndBLL.Operations
{
    public class ProductOperations : IProductOperations
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<ProductOperations> _logger;
        public ProductOperations(IRepositoryManager repository,ILogger<ProductOperations> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public Product Add(ProductViewModel model)
        {
            _logger.LogInformation("ProductOperations --- Add method started");
            Product product = new Product
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                UnitsOnOrder = model.UnitsOnOrder,
                QuantityPerUnit = model. QuantityPerUnit
            };
            _repository.Products.Add(product);
            _repository.SaveChange();
            _logger.LogInformation("ProductOperations --- Add method finished");
            return product;
        }

        public void Delete(int id)
        {
            _logger.LogInformation("ProductOperations --- Delete method started");
            var result = _repository.Products.Get(id);
            _repository.Products.Remove(result);
            _repository.SaveChange();
            _logger.LogInformation("ProductOperations --- Delete method finished");
        }

        public ProductViewModel Get(int id)
        {
            _logger.LogInformation("ProductOperations --- Get method started");
            var result = _repository.Products.Get(id) ?? throw new LogicException("Wrong id");
            _logger.LogInformation("ProductOperations --- Get method finished");
            return new ProductViewModel
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                QuantityPerUnit = result.QuantityPerUnit,
                UnitPrice = result.UnitPrice,
                UnitsInStock = result.UnitsInStock,
                UnitsOnOrder = result.UnitsOnOrder
            };
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            _logger.LogInformation("ProductOperations --- GetAll method started");
            var data = _repository.Products.GetAll();
            var result = data.Select(x => new ProductViewModel
            {
                UnitsOnOrder=x.UnitsOnOrder,
                UnitsInStock=x.UnitsInStock,
                UnitPrice=x.UnitPrice,
                ProductId=x.ProductId,
                ProductName=x.ProductName,
                QuantityPerUnit=x.QuantityPerUnit
            });
            _logger.LogInformation("ProductOperations --- GetAll method finished");
            return result;
        }


        public Product Update(ProductViewModel model)
        {
            _logger.LogInformation("ProductOperations --- Update method started");
            Product product = new Product
            {
                ProductId = model.ProductId
            };
            product.ProductId = model.ProductId;
            product.ProductName = model.ProductName;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            _repository.Products.Update(product);
            _repository.SaveChange();
            _logger.LogInformation("ProductOperations --- Update method finidhed");
            return product;
        }


        public IEnumerable<ProductsNeedReordering> GetProductsneedreorderings()
        {
            _logger.LogInformation("ProductOperations --- GetProductsneedreorderings method started");
            return _repository.Products.GetProductsneedreorderings();
        }

        public IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings()
        {
            _logger.LogInformation("ProductOperations --- GetProductsthatneedreorderings method started");
            return _repository.Products.GetProductsthatneedreorderings();
        }
    }
}
