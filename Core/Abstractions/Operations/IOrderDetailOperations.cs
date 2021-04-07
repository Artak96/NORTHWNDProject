using NorthWndCore.BusinessModels;
using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Operations
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
