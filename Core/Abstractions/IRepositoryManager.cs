using NorthWndCore.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace NorthWndCore.Abstractions
{
    public interface IRepositoryManager
    {
        public IUserRepository Users {get;}
        public IEmployeRepository Employes { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public ICustomerRepository Customers { get; }
        public ISupplierRepository Supplier { get; }
        public IOrderDetailRepository OrderDetail { get; }

        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void SaveChange();
        Task SaveChangesAsync();
    } 
}
