using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}
