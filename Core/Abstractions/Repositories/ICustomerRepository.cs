using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<CustomersWithOrders> GetCustomerswithnoorders();
        IEnumerable<TotalCustomers> GetTotalCustomers();
        IEnumerable<CustomerListByRegion> GetCustomerlistbyregions();
        IEnumerable<CustomersWithNoOrdersForEmpId4> Get4s();
        IEnumerable<HighValueCustomers> GetHighvaluecustomers();
    }
}
