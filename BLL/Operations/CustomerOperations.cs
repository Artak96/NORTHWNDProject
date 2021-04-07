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
    public class CustomerOperations : ICustomerOperations
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<CustomerOperations> _logger;
        public CustomerOperations(IRepositoryManager repository,ILogger<CustomerOperations> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public Customer Add(CustomerViewModel model)
        {
            _logger.LogInformation("CustomerOperations --- Add method started");
            Customer customer = new Customer
            {
                Address = model.Address,
                City = model.City,
                ContactTitle =  model.ContactTitle,
                Country = model.Country,
                CustomerId = model.CustomerId,
                Fax = model.Fax,
                Phone = model.Phone
            };
            _repository.Customers.Add(customer);
            _repository.SaveChange();
            _logger.LogInformation("CustomerOperations --- Add method finished");
            return customer;

        }

        public void Delete(int id)
        {
            _logger.LogInformation("CustomerOperations --- Delet method started");
            var result = _repository.Customers.Get(id);
            _repository.Customers.Remove(result);
            _logger.LogInformation("CustomerOperations --- Delete method finished");

        }

        public CustomerViewModel Get(int id)
        {
            _logger.LogInformation("CustomerOperations --- Get method started");
            var customer = _repository.Customers.Get(id) ?? throw new LogicException("Wrong id");
            _logger.LogInformation("CustomerOperations --- Get method finished");
            return new CustomerViewModel
            {
                Address = customer.Address,
                City = customer.City,
                ContactTitle = customer.ContactTitle,
                Country = customer.Country,
                CustomerId = customer.CustomerId,
                Fax = customer.Fax,
                Phone = customer.Phone
            };
        }


        public IEnumerable<CustomerViewModel> GetAll()
        {
            _logger.LogInformation("CustomerOperations --- GetAll method started");
            var data = _repository.Customers.GetAll();
            var result = data.Select(x => new CustomerViewModel
            {
                Phone=x.Phone,
                Fax=x.Fax,
                CustomerId=x.CustomerId,
                Country=x.Country,
                ContactTitle=x.ContactTitle,
                Address= x.Address,
                City=x.City
            });
            _logger.LogInformation("CustomerOperations --- GetAll method finished");
            return result;
        }


        public Customer Update(CustomerViewModel model)
        {
            _logger.LogInformation("CustomerOperations --- Update method started");
            Customer customer = new Customer
            {
                CustomerId = model.CustomerId
            };
            customer.CustomerId = model.CustomerId;
            customer.Phone = model.Phone;
            customer.Fax = model.Fax;
            customer.Country = model.Country;
            customer.ContactTitle = model.ContactTitle;
            customer.Address = model.Address;
            customer.City = model.City;
            _repository.Customers.Update(customer);
            _repository.SaveChange();
            _logger.LogInformation("CustomerOperations --- Update method finished");
            return customer;
        }


        public IEnumerable<CustomersWithNoOrdersForEmpId4> Get4s()
        {
            _logger.LogInformation("CustomerOperations --- Get4s method started");
            return _repository.Customers.Get4s();
        }

        public IEnumerable<CustomerListByRegion> GetCustomerlistbyregions()
        {
            _logger.LogInformation("CustomerOperations --- GetCustomerlistbyregions method started");
            return _repository.Customers.GetCustomerlistbyregions();
        }

        public IEnumerable<CustomersWithOrders> GetCustomerswithnoorders()
        {
            _logger.LogInformation("CustomerOperations --- Add method started");
            return _repository.Customers.GetCustomerswithnoorders();
        }

        public IEnumerable<HighValueCustomers> GetHighvaluecustomers()
        {
            _logger.LogInformation("CustomerOperations --- GetHighvaluecustomers method started");
            return _repository.Customers.GetHighvaluecustomers();
        }

        public IEnumerable<TotalCustomers> GetTotalCustomers()
        {
            _logger.LogInformation("CustomerOperations --- GetTotalCustomers method started");
            return _repository.Customers.GetTotalCustomers();
        }
    }
}
