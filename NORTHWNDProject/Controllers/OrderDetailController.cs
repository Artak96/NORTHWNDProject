using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWndCore.Abstractions.Operations;
using NorthWndCore.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthWndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailOperations _orderDetail;
        public OrderDetailController(IOrderDetailOperations orderDetail)
        {
            _orderDetail = orderDetail;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = _orderDetail.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _orderDetail.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]OrderDetailViewModel model)
        {
            var result = _orderDetail.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]OrderDetailViewModel model)
        {
            var result = _orderDetail.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Rempve([FromRoute]int id)
        {
            _orderDetail.Delete(id);
            return Ok();
        }

        [HttpGet("OrdersDoubleEntry")]
        public IActionResult OrdersDoubleEntry()
        {
            var res = _orderDetail.GetDoubleEntries();
            return Ok(res);
        }


        [HttpGet("OrdersDoubleEntryDetails")]
        public IActionResult OrdersDoubleEntryDetails()
        {
            var res = _orderDetail.GetDoubleEntriesDetails();
            return Ok(res);
        }

    }
}