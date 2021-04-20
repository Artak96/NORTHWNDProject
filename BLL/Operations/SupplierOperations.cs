using NorthWndCore.Abstractions;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using NorthWndCore.Entities;
using NorthWndCore.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWndBLL.Operations
{
    public class SupplierOperations : ISupplierOperations
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<SupplierOperations> _logger;
        public SupplierOperations(IRepositoryManager repository,ILogger<SupplierOperations> logger)
        {
            _logger = logger;
            _repository = repository;
        }


        public Supplier Add(SupplierViewModel model)
        {
            _logger.LogInformation("SupplierOperations --- Add method started");
            Supplier supplier = new Supplier
            {
                Address =  model.Address,
                City = model.City,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Phone = model.Phone,
                SupplierId = model.SupplierId
            };
            _repository.Supplier.Add(supplier);
            _repository.SaveChange();
            _logger.LogInformation("SupplierOperations --- Add method finished");
            return supplier;
        }

        public void Delete(int id)
        {
            _logger.LogInformation("SupplierOperations --- Delete method strated");
            var supplier = _repository.Supplier.Get(id);
            _repository.Supplier.Remove(supplier);
            _repository.SaveChange();
            _logger.LogInformation("SupplierOperations --- Delete method finished");

        }

        public SupplierViewModel Get(int id)
        {
            _logger.LogInformation("SupplierOperations --- Get method statrted");
            var supplier = _repository.Supplier.Get(id) ?? throw new LogicException("Wrong id");
            _logger.LogInformation("SupplierOperations --- Get method finished");
            return new SupplierViewModel
            {
                Address = supplier.Address,
                City = supplier.City,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Phone = supplier.Phone,
                SupplierId = supplier.SupplierId
            };
        }

        public IEnumerable<SupplierViewModel> GetAll()
        {
            _logger.LogInformation("SupplierOperations --- GetAll method started");
            var supplier = _repository.Supplier.GetAll();
            var result = supplier.Select(x => new SupplierViewModel
            {
                SupplierId = x.SupplierId,
                Phone = x.Phone,
                ContactTitle = x.ContactTitle,
                ContactName = x.ContactName,
                CompanyName = x.CompanyName,
                Address = x.Address,
                City = x.City
            });
            _logger.LogInformation("SupplierOperations --- GetAll method finished");
            return result;
        }

        public Supplier Update(SupplierViewModel model)
        {
            _logger.LogInformation("SupplierOperations --- Update method started");
            Supplier supplier = new Supplier
            {
                SupplierId =model.SupplierId
            };
            supplier.SupplierId = model.SupplierId;
            supplier.Phone = model.Phone;
            supplier.ContactTitle = model.ContactTitle;
            supplier.ContactName = model.ContactName;
            supplier.CompanyName = model.CompanyName;
            supplier.Address = model.Address;
            supplier.City = model.City;
            _repository.Supplier.Update(supplier);
            _repository.SaveChange();
            _logger.LogInformation("SupplierOperations --- Update method finished");
            return supplier;
        }
    }
}
