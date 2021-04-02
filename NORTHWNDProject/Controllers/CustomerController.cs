using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstractions.Operations;
using Core.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NORTHWNDProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerOperations _customerOperations;
        public CustomerController(ICustomerOperations customerOperations)
        {
            _customerOperations = customerOperations;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _customerOperations.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customerOperations.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]CustomerViewModel model )
        {
            var result = _customerOperations.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]CustomerViewModel model)
        {
            var result = _customerOperations.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete([FromRoute] int id)
        {
            _customerOperations.Delete(id);
            return Ok();
        }

        [HttpGet("totalcustomers")]
        public IActionResult Totalcustomers()
        {
            var res = _customerOperations.GetTotalCustomers();
            return Ok(res);
        }



        [HttpGet("customerswithnoorders")]
        public IActionResult Customerswithnoorders()
        {
            var result = _customerOperations.GetCustomerswithnoorders();
            return Ok(result);
        }

        [HttpGet("Customerlistbyregions")]
        public IActionResult Customerlistbyregions()
        {
            var res = _customerOperations.GetCustomerlistbyregions();
            return Ok(res);
        }

        [HttpGet("customers_no_orders_empid4")]
        public IActionResult Customers_no_orders_empid4()
        {
            var res = _customerOperations.Get4s();
            return Ok(res);
        }

        [HttpGet("Highvaluecustomers")]
        public IActionResult Highvaluecustomers()
        {
            var res = _customerOperations.GetHighvaluecustomers();
            return Ok(res);
        }

       
    }
}