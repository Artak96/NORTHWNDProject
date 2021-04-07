using NorthWndCore.Abstractions.Repositories;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>,IEmployeRepository
    {
        public EmployeeRepository(NORTHWNDContext context ) : base(context)
        {

        }

    }
}
