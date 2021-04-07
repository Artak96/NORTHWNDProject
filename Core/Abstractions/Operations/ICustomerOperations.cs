using NorthWndCore.BusinessModels;
using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Operations
{
    public interface ICustomerOperations
    {
        public Customer Add(CustomerViewModel model);
        public Customer Update(CustomerViewModel model);
        public CustomerViewModel Get(int id);
        public IEnumerable<CustomerViewModel> GetAll();
        public void Delete(int id);

        IEnumerable<CustomersWithOrders> GetCustomerswithnoorders();
        IEnumerable<TotalCustomers> GetTotalCustomers();
        IEnumerable<CustomerListByRegion> GetCustomerlistbyregions();
        IEnumerable<CustomersWithNoOrdersForEmpId4> Get4s();
        IEnumerable<HighValueCustomers> GetHighvaluecustomers();

    }
}
