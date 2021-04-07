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

namespace BLL.Operations
{
    public class OrderDetailOperations : IOrderDetailOperations
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<OrderDetailOperations> _logger;
        public OrderDetailOperations(IRepositoryManager repository,ILogger<OrderDetailOperations> logger)
        {
            _logger =logger;
            _repository = repository;
        }

        public OrderDetail Add(OrderDetailViewModel model)
        {
            _logger.LogInformation("OrderDetailOperations --- Add method started");
            OrderDetail orderDetail = new OrderDetail
            {
                OrderId = model.OrderId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                Discount = model.Discount
            };
            _repository.OrderDetail.Add(orderDetail);
            _repository.SaveChange();
            _logger.LogInformation("OrderDetailOperations --- Add method finished");
            return orderDetail;
            
        }

        public void Delete(int id)
        {
            _logger.LogInformation("OrderDetailOperations --- Delete method started");
            var orderDetail = _repository.OrderDetail.Get(id);
            _repository.OrderDetail.Remove(orderDetail);
            _logger.LogInformation("OrderDetailOperations --- Delete method Finished");
        }

        public OrderDetailViewModel Get(int id)
        {
            _logger.LogInformation("OrderDetailOperations --- Get method started");
            var result = _repository.OrderDetail.Get(id) ?? throw new LogicException("Wrong id");
            _logger.LogInformation("OrderDetailOperations --- Get method finished");
            return new OrderDetailViewModel
            {
                Quantity = result.Quantity,
                OrderId = result.OrderId,
                Discount = result.Discount,
                UnitPrice = result.UnitPrice
            };

        }

        public IEnumerable<OrderDetailViewModel> GetAll()
        {
            _logger.LogInformation("OrderDetailOperations --- GetAll method started");
            var data = _repository.OrderDetail.GetAll();
            var result = data.Select(x => new OrderDetailViewModel
            {
                Discount = x.Discount,
                UnitPrice = x.UnitPrice,
                OrderId = x.OrderId,
                Quantity = x.Quantity
            });
            _logger.LogInformation("OrderDetailOperations --- GetAll method finished");
            return result;
        }


        public OrderDetail Update(OrderDetailViewModel model)
        {
            _logger.LogInformation("OrderDetailOperations --- Update method started");
            OrderDetail orderDetail = new OrderDetail
            {
                OrderId = model.OrderId
            };
            orderDetail.OrderId = model.OrderId;
            orderDetail.Quantity = model.Quantity;
            orderDetail.UnitPrice = model.UnitPrice;
            orderDetail.Discount = model.Discount;
            _repository.OrderDetail.Update(orderDetail);
            _repository.SaveChange();
            _logger.LogInformation("OrderDetailOperations --- Update method finished");
            return orderDetail;
        }


        public IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries()
        {
            _logger.LogInformation("OrderDetailOperations --- GetDoubleEntries method started");
            return _repository.OrderDetail.GetDoubleEntries();
        }

        public IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails()
        {
            _logger.LogInformation("OrderDetailOperations --- GetDoubleEntriesDetails method started");
            return _repository.OrderDetail.GetDoubleEntriesDetails();
        }
    }
}
