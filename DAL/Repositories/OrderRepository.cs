using Core.Abstractions.Repositories;
using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class OrderRepository : RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(NORTHWNDContext context) : base(context)
        {

        }
        public IEnumerable<HighFreightOrders> GetHighfreight1996_1997()
        {
            var query = (from order in context.Orders
                         where order.OrderDate.Value.Year > 1997
                         where order.OrderDate.Value.Year < 1998
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }

        
        public IEnumerable<HighFreightOrders> GetHighfreightorders()
        {
            var query = (from order in context.Orders
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }


        
        public IEnumerable<HighFreightOrders> GetHighfreightorders1996()
        {
            var query = (from order in context.Orders
                         where order.OrderDate.Value.Year == 1997
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }


        
        public IEnumerable<InventoryListModel> GetInventoryList()
        {

            var query = from order in context.Orders
                        join employee in context.Employees on order.EmployeeId equals employee.EmployeeId
                        join orderDetail in context.OrderDetails on order.OrderId equals orderDetail.OrderId
                        join product in context.Products on orderDetail.ProductId equals product.ProductId
                        orderby order.OrderId, product.ProductId
                        select new InventoryListModel
                        {
                            EmployeeId = employee.EmployeeId,
                            LastName = employee.LastName,
                            OrderId = order.OrderId,
                            ProductName = product.ProductName,
                            Quantity = orderDetail.Quantity
                        };

            return query.ToList();
        }


        
    }
}
