using Core.Abstractions.Repositories;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>,IEmployeRepository
    {
        public EmployeeRepository(NORTHWNDContext context ) : base(context)
        {

        }

    }
}
