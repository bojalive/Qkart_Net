
global using Qkart_WebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Qkart_WebAPI.Data;

namespace Qkart_WebAPI.Controllers
{
    [Route("v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ProductsDTO>> GetAllProducts()
        {
            var productsList = ProductsData.ProductsList;
            if (productsList != null)
            {
                return StatusCode(statusCode: 200, productsList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:Guid}", Name = "GetProductById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ProductsDTO>> GetProductsById(Guid id)
        {
            var productsListById = ProductsData.ProductsList.First(i => i.Id == id);
            if (productsListById == null)
            {
                return NotFound();
            }

            return Ok(productsListById);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ProductsDTO>> AddNewProduct([FromBody] ProductsDTO data)
        {
            if (ProductsData.ProductsList.FirstOrDefault(i => i.Name.ToLower() == data.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "The Name was Duplicate");
                return BadRequest(ModelState);
            }
            if (data == null) return BadRequest();
            data.Id = Guid.NewGuid();
            ProductsData.ProductsList.Add(data);
            return CreatedAtRoute("GetProductById", new { id = data.Id }, data);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProductById(Guid id)
        {
            ProductsDTO product = ProductsData.ProductsList.FirstOrDefault(i => i.Id == id);
            if (product == null) return NotFound();
            ProductsData.ProductsList.Remove(product);
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult PutProductsById(Guid id, [FromBody] ProductsDTO data)
        {
            if (data == null) return BadRequest();
            ProductsDTO product = ProductsData.ProductsList.FirstOrDefault(i => i.Id == id);
            if (product == null) return NotFound();
            product.Name = data.Name;
            product.Cost = data.Cost;
            product.Catagory = data.Catagory;
            product.Rating = data.Rating;

            return NoContent();
        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult PatchProductsById(Guid id, [FromBody] JsonPatchDocument<ProductsDTO> data)
        {
            if (data == null) return BadRequest();
            ProductsDTO product = ProductsData.ProductsList.FirstOrDefault(i => i.Id == id);
            if (product == null) return NotFound();

            data.ApplyTo(product, ModelState);
            if (!ModelState.IsValid) return BadRequest();

            return NoContent();
        }
    }
}
