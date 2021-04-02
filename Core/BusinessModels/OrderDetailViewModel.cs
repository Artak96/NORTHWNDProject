using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessModels
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
