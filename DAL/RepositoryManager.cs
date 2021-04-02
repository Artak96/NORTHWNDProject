using Core.Abstractions;
using Core.Abstractions.Repositories;
using Core.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private NORTHWNDContext _context;
        public RepositoryManager(NORTHWNDContext context)
        {
            _context = context;
        }

        private IUserRepository _user;
        public IUserRepository Users => _user ?? (_user = new UserRepository(_context));

        private IEmployeRepository _employe;
        public IEmployeRepository Employes => _employe ?? (_employe = new EmployeeRepository(_context));

        private IOrderRepository _order;
        public IOrderRepository Orders => _order ?? (_order = new OrderRepository(_context));

        private IProductRepository _product;
        public IProductRepository Products => _product ?? (_product = new ProductRepository(_context));

        private ICustomerRepository _customer;
        public ICustomerRepository Customers => _customer ?? (_customer = new CustomerRepository(_context));

        private ISupplierRepository _supplier;
        public ISupplierRepository Supplier => _supplier ?? (_supplier = new SupplierRepository(_context));

        private IOrderDetailRepository _orderDetail;
        public IOrderDetailRepository OrderDetail => _orderDetail ?? (_orderDetail = new OrderDetailRepository(_context));

        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new DatabaseTransaction(_context, isolationLevel);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
