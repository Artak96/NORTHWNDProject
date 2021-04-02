using Core.Abstractions.Repositories;
using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(NORTHWNDContext context) : base(context)
        {

        }

        public IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries()
        {
            var query = from orddet in context.OrderDetails
                        where orddet.Quantity >= 60
                        group orddet by new { orddet.OrderId, orddet.Quantity } into g
                        where g.Count() > 1
                        select new OrdersAccidentalDoubleEntry
                        {
                            OrderId = g.Key.OrderId
                        };
            return query.ToList();
        }



        public IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails()
        {
            var query = from order in context.OrderDetails
                        where order.Quantity >= 60
                        group order by new { order.OrderId, order.Quantity } into g
                        where g.Count() > 1
                        select g.Key.OrderId;
            var res = from order in context.OrderDetails
                      where query.Contains(order.OrderId)
                      select new OrdersAccidentalDoubleEntryDetails
                      {
                          OrderId = order.OrderId,
                          Discount = order.Discount,
                          ProductId = order.ProductId,
                          Quantity = order.Quantity,
                          UnitPrice = order.UnitPrice
                      };
            return res.ToList();
        }
    }
}
