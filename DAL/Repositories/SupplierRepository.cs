using Core.Abstractions.Repositories;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>,ISupplierRepository
    {
        public SupplierRepository(NORTHWNDContext context) : base(context)
        {

        }
    }
}
