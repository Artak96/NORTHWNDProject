using NorthWndCore.Abstractions;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using NorthWndCore.Entities;
using NorthWndCore.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class EmployeeOperations : IEmployeeOperations
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<EmployeeOperations> _logger;

        public EmployeeOperations(IRepositoryManager repository,ILogger<EmployeeOperations> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public Employee Add(EmployeeViewModel model)
        {
            _logger.LogInformation("EmployeeOperations --- Add method started");
            Employee employee = new Employee
            {
                EmployeeId =  model.EmployeeId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                BirthDate = model.BirthDate
            };
            _repository.Employes.Add(employee);
            _repository.SaveChange();
            _logger.LogInformation("EmployeeOperations --- Add method finished");
            return employee;
        }

        public void Delete(int id)
        {
            _logger.LogInformation("EmployeeOperations --- Delete method started");
            var result = _repository.Employes.Get(id);
            _repository.Employes.Remove(result);
            _logger.LogInformation("EmployeeOperations --- Delet method finished");
        }

        public EmployeeViewModel Get(int id)
        {
            _logger.LogInformation("EmployeeOperations --- Get method started");
            var employee = _repository.Employes.Get(id) ?? throw new LogicException("Wrong id");
            _logger.LogInformation("EmployeeOperations --- Get method finished");
            return new EmployeeViewModel
            {
                BirthDate = employee.BirthDate,
                EmployeeId = employee.EmployeeId,
                FirstName=employee.FirstName,
                LastName=employee.LastName,
                Title=employee.Title
            };
           
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            _logger.LogInformation("EmployeeOperations --- GetAll method started");
            var data = _repository.Employes.GetAll();
            var result = data.Select(x => new EmployeeViewModel
            {
                Title = x.Title,
                LastName = x.LastName,
                FirstName = x.FirstName,
                EmployeeId = x.EmployeeId,
                BirthDate = x.BirthDate

            });
            _logger.LogInformation("EmployeeOperations --- GetAll method finished");
            return result;
        }

        public Employee Update(EmployeeViewModel model)
        {
            _logger.LogInformation("EmployeeOperations --- Update method started");
            Employee employee = new Employee
            {
                EmployeeId = model.EmployeeId
            };
            employee.BirthDate = model.BirthDate;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Title = model.Title;
            _repository.Employes.Update(employee);
            _repository.SaveChange();
            _logger.LogInformation("EmployeeOperations --- Update method finished");
            return employee;
        }

    }
}
