using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<HighFreightOrders> GetHighfreightorders();
        IEnumerable<HighFreightOrders> GetHighfreightorders1996();
        IEnumerable<HighFreightOrders> GetHighfreight1996_1997();
    }
}
