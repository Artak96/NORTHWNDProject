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
    public class ProductController : Controller
    {
        private readonly IProductOperations _product;
        public ProductController(IProductOperations product)
        {
            _product = product;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _product.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _product.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]ProductViewModel model)
        {
            var result = _product.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]ProductViewModel model)
        {
            var result = _product.Update(model);
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
             _product.Delete(id);
            return Ok();
        }

        [HttpGet("Productsneedreorderings")]
        public IActionResult Productsneedreorderings()
        {
            var res = _product.GetProductsneedreorderings();
            return Ok(res);
        }

        [HttpGet("Productsthatneedreorderings")]
        public IActionResult Productsthatneedreorderings()
        {
            var res = _product.GetProductsthatneedreorderings();
            return Ok(res);
        }

    }
}