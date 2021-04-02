using Core.Abstractions.Operations;
using Core.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTHWNDProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderOperations _orderOperations;
        public OrderController(IOrderOperations  order)
        {
            _orderOperations = order;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _orderOperations.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _orderOperations.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] OrderViewModel model)
        {
            var result = _orderOperations.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] OrderViewModel model)
        {
            var result = _orderOperations.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute]int id)
        {
            _orderOperations.Delete(id);
            return Ok();
        }

        [HttpGet("inventory")]
        public IActionResult GetInventoryList()
        {
            var result = _orderOperations.GetInventoryList();
            return Ok(result);
        }

        [HttpGet("Highfreightorders")]
        public IActionResult GetHighFreight()
        {
            var res = _orderOperations.GetHighfreightorders();
            return Ok(res);
        }

        [HttpGet("Highfreightorders1996")]
        public IActionResult GetHighFreight1996()
        {
            var res = _orderOperations.GetHighfreightorders1996();
            return Ok(res);
        }

        [HttpGet("Highfreight1996_1997")]
        public IActionResult Highfreight1996_1997()
        {
            var res = _orderOperations.GetHighfreight1996_1997();
            return Ok(res);
        }


       
    }
}
