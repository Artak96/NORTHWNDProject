using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessModels.QueryListMdel
{
    public class CustomersWithOrders
    {
        public string Customers_Customerid { get; set; }
        public string Orders_Customerid { get; set; }
    }
}
