using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderOperations _order;
        public OrderController(IOrderOperations  order)
        {
            _order = order;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _order.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _order.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] OrderViewModel model)
        {
            var result = _order.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] OrderViewModel model)
        {
            var result = _order.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute]int id)
        {
            _order.Delete(id);
            return Ok();
        }

        [HttpGet("inventory")]
        public IActionResult GetInventoryList()
        {
            var result = _order.GetInventoryList();
            return Ok(result);
        }

        [HttpGet("Highfreightorders")]
        public IActionResult GetHighFreight()
        {
            var res = _order.GetHighfreightorders();
            return Ok(res);
        }

        [HttpGet("Highfreightorders1996")]
        public IActionResult GetHighFreight1996()
        {
            var res = _order.GetHighfreightorders1996();
            return Ok(res);
        }

        [HttpGet("Highfreight1996_1997")]
        public IActionResult Highfreight1996_1997()
        {
            var res = _order.GetHighfreight1996_1997();
            return Ok(res);
        }


       
    }
}
