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
    public class ProductController : Controller
    {
        private readonly IProductOperations _productOperations;
        public ProductController(IProductOperations productOperations)
        {
            _productOperations = productOperations;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _productOperations.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productOperations.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]ProductViewModel model)
        {
            var result = _productOperations.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]ProductViewModel model)
        {
            var result = _productOperations.Update(model);
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
             _productOperations.Delete(id);
            return Ok();
        }

        [HttpGet("Productsneedreorderings")]
        public IActionResult Productsneedreorderings()
        {
            var res = _productOperations.GetProductsneedreorderings();
            return Ok(res);
        }

        [HttpGet("Productsthatneedreorderings")]
        public IActionResult Productsthatneedreorderings()
        {
            var res = _productOperations.GetProductsthatneedreorderings();
            return Ok(res);
        }

    }
}