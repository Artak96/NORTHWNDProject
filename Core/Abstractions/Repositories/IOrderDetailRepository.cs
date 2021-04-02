using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Repositories
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        IEnumerable<OrdersAccidentalDoubleEntry> GetDoubleEntries();
        IEnumerable<OrdersAccidentalDoubleEntryDetails> GetDoubleEntriesDetails();
    }
}
