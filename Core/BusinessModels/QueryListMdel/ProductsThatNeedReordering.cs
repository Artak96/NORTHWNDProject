﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.BusinessModels.QueryListMdel
{
    public class ProductsThatNeedReordering
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
