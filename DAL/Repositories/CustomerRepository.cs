using NorthWndCore.Abstractions.Repositories;
using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NorthWndDAL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>,ICustomerRepository
    {
        public CustomerRepository(NORTHWNDContext context) : base(context)
        {

        }

        public IEnumerable<TotalCustomers> GetTotalCustomers()
        {
            var query = (from customer in context.Customers
                         group customer by new { customer.City, customer.Country } into g
                         select new TotalCustomers
                         {
                             Country = g.Key.Country,
                             City = g.Key.City,
                             Totalcustomers = g.Count()
                         }).OrderByDescending(x => x.Totalcustomers);
            return query.ToList();
        }


        
        public IEnumerable<CustomerListByRegion> GetCustomerlistbyregions()
        {
            var query = from customer in context.Customers
                        orderby customer.Region, customer.CustomerId
                        select new CustomerListByRegion
                        {
                            CustomerId = customer.CustomerId,
                            CompanyName = customer.CompanyName,
                            Region = customer.Region
                        };
            return query.ToList();
        }


        
        public IEnumerable<CustomersWithOrders> GetCustomerswithnoorders()
        {
            var query = from customer in context.Customers
                        join order in context.Orders
                            on customer.CustomerId equals order.CustomerId into g
                        from or in g.DefaultIfEmpty()
                        where or.CustomerId == null
                        select new CustomersWithOrders
                        {
                            Customers_Customerid = customer.CustomerId,
                            Orders_Customerid = or.CustomerId
                        };
            return query.ToList();
        }


        
        public IEnumerable<CustomersWithNoOrdersForEmpId4> Get4s()
        {
            var customerIds = (from order in context.Orders
                               where order.EmployeeId == 4
                               select order.CustomerId).ToList();
            var query = from customer in context.Customers
                        where !customerIds.Contains(customer.CustomerId)
                        select new CustomersWithNoOrdersForEmpId4
                        {
                            CustomerId = customer.CustomerId,
                        };
            return query.ToList();
        }


        
        public IEnumerable<HighValueCustomers> GetHighvaluecustomers()
        {
            var query = (from customer in context.Customers
                         join order in context.Orders on customer.CustomerId equals order.CustomerId
                         where order.OrderDate.Value.Year == 1998
                         join orddet in context.OrderDetails on order.OrderId equals orddet.OrderId
                         group orddet by new { customer.CustomerId, customer.CompanyName, order.OrderId } into g
                         where g.Sum(x => x.Quantity * x.UnitPrice) > 10000
                         select new HighValueCustomers
                         {
                             CompanyName = g.Key.CompanyName,
                             CustomerId = g.Key.CustomerId,
                             OrderId = g.Key.OrderId,
                             OrderIdTotalOrderAmount = g.Sum(x => x.Quantity * x.UnitPrice)
                         }).OrderByDescending(x => x.OrderIdTotalOrderAmount);
            return query.ToList();
        }
    }
}
