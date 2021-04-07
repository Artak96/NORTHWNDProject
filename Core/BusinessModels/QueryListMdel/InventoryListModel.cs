﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.BusinessModels.QueryListMdel
{
    public class InventoryListModel
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public int TotalLateOrders { get; set; }
    }
}
