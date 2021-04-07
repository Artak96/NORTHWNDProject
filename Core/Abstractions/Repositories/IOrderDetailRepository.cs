using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Repositories
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries();
        IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails();
    }
}
