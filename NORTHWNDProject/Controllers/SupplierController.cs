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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierOperations _supplierOperations;
        public SupplierController(ISupplierOperations supplierOperations)
        {
            _supplierOperations = supplierOperations;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _supplierOperations.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _supplierOperations.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody]SupplierViewModel model)
        {
            var result = _supplierOperations.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]SupplierViewModel model)
        {
            var result = _supplierOperations.Update(model);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            _supplierOperations.Delete(id);
            return Ok();
        }
    }
}