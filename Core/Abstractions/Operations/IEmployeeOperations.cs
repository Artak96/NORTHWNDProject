using NorthWndCore.BusinessModels;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Operations
{
    public interface IEmployeeOperations
    {
        public Employee Add(EmployeeViewModel model);
        public void Delete(int id);
        public Employee Update(EmployeeViewModel model);
        public IEnumerable<EmployeeViewModel> GetAll();
        EmployeeViewModel Get(int id);


    }
}
