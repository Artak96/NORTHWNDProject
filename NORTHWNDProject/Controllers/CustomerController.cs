using System;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NorthWndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerOperations _customer;
        public CustomerController(ICustomerOperations customer)
        {
            _customer = customer;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _customer.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customer.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]CustomerViewModel model )
        {
            var result = _customer.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]CustomerViewModel model)
        {
            var result = _customer.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete([FromRoute] int id)
        {
            _customer.Delete(id);
            return Ok();
        }

        [HttpGet("totalcustomers")]
        public IActionResult Totalcustomers()
        {
            var res = _customer.GetTotalCustomers();
            return Ok(res);
        }



        [HttpGet("customerswithnoorders")]
        public IActionResult Customerswithnoorders()
        {
            var result = _customer.GetCustomerswithnoorders();
            return Ok(result);
        }

        [HttpGet("Customerlistbyregions")]
        public IActionResult Customerlistbyregions()
        {
            var res = _customer.GetCustomerlistbyregions();
            return Ok(res);
        }

        [HttpGet("customers_no_orders_empid4")]
        public IActionResult Customers_no_orders_empid4()
        {
            var res = _customer.Get4s();
            return Ok(res);
        }

        [HttpGet("Highvaluecustomers")]
        public IActionResult Highvaluecustomers()
        {
            var res = _customer.GetHighvaluecustomers();
            return Ok(res);
        }

       
    }
}