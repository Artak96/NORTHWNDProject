using NorthWndCore.BusinessModels;
using NorthWndCore.BusinessModels.QueryListMdel;
using NorthWndCore.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWndCore.Abstractions.Operations
{
    public interface IOrderOperations
    {
        public Order Add(OrderViewModel model);
        public Order Update(OrderViewModel model);
        public OrderViewModel Get(int id);
        public IEnumerable<OrderViewModel> GetAll();
        public void Delete(int id);

        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<HighFreightOrders> GetHighfreightorders();
        IEnumerable<HighFreightOrders> GetHighfreightorders1996();
        IEnumerable<HighFreightOrders> GetHighfreight1996_1997();
    }
}
