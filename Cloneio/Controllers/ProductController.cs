using Cloneio.Models;
using Cloneio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cloneio.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       

        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
       public IActionResult GetAllProducts()
        {
            var p = _unitOfWork.ProductRepo.GetAll();
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        /*
          
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(int id)
        {
        }

         */

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
                _unitOfWork.ProductRepo.Add(product);
                _unitOfWork.Commit();
                CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
         
               return Ok(product);
        }

        

        [HttpGet("{Id}" , Name ="ProductById")]
        public IActionResult GetProductById(int Id)
        {
            var product = _unitOfWork.ProductRepo.GetById(Id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product =  _unitOfWork.ProductRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepo.Delete(product);
            _unitOfWork.Commit();
            return NoContent();
        }


        [HttpPut("{Id}")]
        public IActionResult UpdateProduct(int Id, [FromBody]Product product )
        {

            var p = _unitOfWork.ProductRepo.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the properties of p with the values from the product object
            p.Name = product.Name;
            p.Description = product.Description;
            p.AvailableStock = product.AvailableStock;
            p.Price = product.Price;
            p.MaximumOrderQuantity = product.MaximumOrderQuantity;

            _unitOfWork.ProductRepo.Update(p);
            _unitOfWork.Commit();
            return Ok(p);
        }

    }
}
