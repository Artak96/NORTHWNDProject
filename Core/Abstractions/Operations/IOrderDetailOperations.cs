using Core.BusinessModels;
using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Operations
{
    public interface IOrderDetailOperations
    {
        public OrderDetail Add(OrderDetailViewModel model);
        public OrderDetail Update(OrderDetailViewModel model);
        public OrderDetailViewModel Get(int id);
        public IEnumerable<OrderDetailViewModel> GetAll();
        public void Delete(int id);

        IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries();
        IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails();
    }
}
