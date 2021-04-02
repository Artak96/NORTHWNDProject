using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstractions.Operations;
using Core.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NORTHWNDProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeOperations _employeeOperations;
        public EmployeeController(IEmployeeOperations employeeOperations)
        {
            _employeeOperations = employeeOperations;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _employeeOperations.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeOperations.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]EmployeeViewModel model )
        {
            var result = _employeeOperations.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles ="Admin")]
        public IActionResult Update([FromBody]EmployeeViewModel model)
        {
            var result = _employeeOperations.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute]int id )
        {
            _employeeOperations.Delete(id);
            return Ok();
        }


    }
}