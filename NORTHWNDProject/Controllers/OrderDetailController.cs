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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailOperations _orderDetailOperations;
        public OrderDetailController(IOrderDetailOperations orderDetailOperations)
        {
            _orderDetailOperations = orderDetailOperations;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _orderDetailOperations.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _orderDetailOperations.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]OrderDetailViewModel model)
        {
            var result = _orderDetailOperations.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]OrderDetailViewModel model)
        {
            var result = _orderDetailOperations.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Rempve([FromRoute]int id)
        {
            _orderDetailOperations.Delete(id);
            return Ok();
        }

        [HttpGet("OrdersDoubleEntry")]
        public IActionResult OrdersDoubleEntry()
        {
            var res = _orderDetailOperations.GetDoubleEntries();
            return Ok(res);
        }


        [HttpGet("OrdersDoubleEntryDetails")]
        public IActionResult OrdersDoubleEntryDetails()
        {
            var res = _orderDetailOperations.GetDoubleEntriesDetails();
            return Ok(res);
        }

    }
}