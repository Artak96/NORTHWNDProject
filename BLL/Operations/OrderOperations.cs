using Core.Abstractions;
using Core.Abstractions.Operations;
using Core.BusinessModels;
using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using Core.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operations
{
    public class OrderOperations : IOrderOperations
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<OrderOperations> _logger;
        public OrderOperations(IRepositoryManager repository,ILogger<OrderOperations> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Order Add(OrderViewModel model)
        {
            _logger.LogInformation("OrderOperations --- Add method started");
            Order order = new Order
            {
                OrderId = model.OrderId,
                OrderDate = model.OrderDate,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipCountry = model.ShipCountry,
                ShipName = model.ShipName

            };
            _repository.Orders.Add(order);
            _repository.SaveChange();
            _logger.LogInformation("OrderOperations --- Add method finished");
            return order;
        }

        public Order Update(OrderViewModel model)
        {
            _logger.LogInformation("OrderOperations --- Update method started");
            Order order = new Order
            {
                OrderId = model.OrderId
            };
            order.OrderDate = model.OrderDate;
            order.ShipAddress = model.ShipAddress;
            order.ShipCity = model.ShipCity;
            order.ShipCountry = model.ShipCountry;
            order.ShipName = model.ShipName;
            _repository.Orders.Update(order);
            _repository.SaveChange();
            _logger.LogInformation("OrderOperations --- Update method finished");
            return order;
        }

        public OrderViewModel Get(int id)
        {
            _logger.LogInformation("OrderOperations --- GetOrder method started");
            var order = _repository.Orders.Get(id) ?? throw new LogicException("Wrong id");
            _logger.LogInformation("OrderOperations --- GetOrder method finished");
            return new OrderViewModel
            {
                ShipName = order.ShipName,
                ShipCountry=order.ShipCountry,
                ShipCity=order.ShipCity,
                ShipAddress = order.ShipAddress,
                OrderDate=order.OrderDate,
                OrderId = order.OrderId
            };
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            _logger.LogInformation("OrderOperations --- GetAllOrder method started");
            var data = _repository.Orders.GetAll();
            var result = data.Select(x => new OrderViewModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                ShipAddress = x.ShipAddress,
                ShipCity = x.ShipCity,
                ShipCountry = x.ShipCountry,
                ShipName = x.ShipName
            });
            _logger.LogInformation("OrderOperations --- GetAllOrder method finished");
            return result;
        }

        public void Delete(int id)
        {
            _logger.LogInformation("OrderOperations --- Delete method started");
            var result = _repository.Orders.Get(id);
            _repository.Orders.Remove(result);
            _repository.SaveChange();
            _logger.LogInformation("OrderOperations --- Delete method finished");
        }

        

        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            _logger.LogInformation("OrderOperations --- GetInventoryList method started");
            return _repository.Orders.GetInventoryList();
        }

        public IEnumerable<HighFreightOrders> GetHighfreightorders()
        {
            _logger.LogInformation("OrderOperations --- GetHighfreightorders method started");
            return _repository.Orders.GetHighfreightorders();
        }

        public IEnumerable<HighFreightOrders> GetHighfreightorders1996()
        {
            _logger.LogInformation("OrderOperations --- GetHighfreightorders1996 method started");
            return _repository.Orders.GetHighfreightorders1996();
        }

        public IEnumerable<HighFreightOrders> GetHighfreight1996_1997()
        {
            _logger.LogInformation("OrderOperations --- GetHighfreight1996_1997 method started");
            return _repository.Orders.GetHighfreight1996_1997();
        }

        public void Test()
        {
            using (var transaction = _repository.BeginTransaction())
            {
                try
                {
                    //add
                    //remove
                    //delete
                    _repository.SaveChange();
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
