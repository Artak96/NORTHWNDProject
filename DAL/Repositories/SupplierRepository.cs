using NorthWndCore.Abstractions.Repositories;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>,ISupplierRepository
    {
        public SupplierRepository(NORTHWNDContext context) : base(context)
        {

        }
    }
}
