using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreateAPI.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProductController(IRepository repository)
        {
            _repository = repository;
        }



        // GET: /api/orders/?name= "???"
        [HttpGet]
        public async Task<IActionResult> GetAllByNameAsync([FromQuery] string name)
        {
            IEnumerable<Product> Products = await _repository.GetProductsAsync(name);



            return new JsonResult(Products);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInventoryAsync([FromQuery] string name, int numLeft)
        {
            IEnumerable<Product> Products = await _repository.SetInventoryAsync(name, numLeft);



            return new JsonResult(Products);
        }
    }
}