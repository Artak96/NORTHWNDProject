using Core.BusinessModels.QueryListMdel;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<HighFreightOrders> GetHighfreightorders();
        IEnumerable<HighFreightOrders> GetHighfreightorders1996();
        IEnumerable<HighFreightOrders> GetHighfreight1996_1997();
    }
}
