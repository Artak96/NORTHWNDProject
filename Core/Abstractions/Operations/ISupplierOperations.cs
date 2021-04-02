using Core.BusinessModels;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Operations
{
    public interface ISupplierOperations
    {
        public SupplierViewModel Get(int id);
        public IEnumerable<SupplierViewModel> GetAll();
        public Supplier Add(SupplierViewModel model);
        public Supplier Update(SupplierViewModel model);
        public void Delete(int id);
    }
}
