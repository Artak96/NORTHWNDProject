using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessModels
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
