using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessModels.QueryListMdel
{
    public class ProductsNeedReordering
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public short? UnitsInStock { get; set; }
        public short? ReorderLevel { get; set; }
    }
}
