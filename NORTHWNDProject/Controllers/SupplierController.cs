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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierOperations _supplier;
        public SupplierController(ISupplierOperations supplier)
        {
            _supplier = supplier;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _supplier.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _supplier.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]SupplierViewModel model)
        {
            var result = _supplier.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]SupplierViewModel model)
        {
            var result = _supplier.Update(model);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            _supplier.Delete(id);
            return Ok();
        }
    }
}