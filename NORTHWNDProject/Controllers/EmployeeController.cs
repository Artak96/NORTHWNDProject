using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NorthWndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeOperations _employee;
        public EmployeeController(IEmployeeOperations employee)
        {
            _employee = employee;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _employee.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employee.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]EmployeeViewModel model )
        {
            var result = _employee.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles ="Admin")]
        public IActionResult Update([FromBody]EmployeeViewModel model)
        {
            var result = _employee.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute]int id )
        {
            _employee.Delete(id);
            return Ok();
        }


    }
}