using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kpsUowRmqTest.Data.Interfaces;
using kpsUowRmqTest.Data.Models;
using kpsUowRmqTest.RabbitMQ;
using Microsoft.AspNetCore.Mvc;

namespace kpsUowRmqTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
           IEnumerable<Product> products=_unitOfWork.ProductRepository.Get();
            return new JsonResult(products);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_unitOfWork.ProductRepository.Find(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            Product newProduct = new Product() { Name = product.Name };
            _unitOfWork.ProductRepository.Insert(newProduct);
            _unitOfWork.Complete();

            new PublisherHelper("productLog", newProduct.Name);

            return new JsonResult(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (id != product.Id) return BadRequest();
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Complete();

            return new JsonResult(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _unitOfWork.ProductRepository.Delete(id);
            if (result == false) return NotFound();

            return Ok();
        }
    }
}
