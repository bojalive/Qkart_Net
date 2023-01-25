
global using Qkart_WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Qkart_WebAPI.Data;
using Qkart_WebAPI.Models.dto;
using System.Net;

namespace Qkart_WebAPI.Controllers
{
    [Route("v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly QkartDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _DbProduct;
        public ApiResponse _response { get; set; }

        public ProductsController(QkartDbContext dbContext, IMapper mapper, IRepository<Product> db)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._DbProduct = db;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ApiResponse>> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> productsList = await _DbProduct.GetAllAsync();

                if (productsList != null)
                {
                    _response.Result = productsList;
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else
                {
                    _response.isSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
            }
            catch (Exception ex)
            {
                return this.ExceptionReturnHelper(ex);

            }

        }

        [HttpGet("{id:Guid}", Name = "GetProductById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ApiResponse>> GetProductsById(Guid id)
        {
            try
            {
                Product product = await _DbProduct.GetByIdAsync(i => i.Id == id);

                if (product == null)
                {
                    throw new Exception($"There was not product with the id - {id}");
                    _response.isSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ProductDTO>(product);
                return Ok(_response);
            }
            catch (Exception ex)
            {

                return this.ExceptionReturnHelper(ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ApiResponse>> AddNewProduct([FromBody] ProductCreateDTO data)
        {
            try
            {
                if (data == null) return BadRequest();
                if (await _DbProduct.GetByIdAsync(i => i.Name.ToLower() == data.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("", "The Name was Duplicate");
                    return BadRequest(ModelState);
                }
                Product model = _mapper.Map<Product>(data);
                model.Id = Guid.NewGuid();
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                await _DbProduct.CreateAsync(_mapper.Map<Product>(model));
                return CreatedAtRoute("GetProductById", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {

                return this.ExceptionReturnHelper(ex);
            }

        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            try
            {
                Product product = await _dbContext.Products.FirstOrDefaultAsync(i => i.Id == id);
                if (product == null)
                {
                    _response.isSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return StatusCode(statusCode: StatusCodes.Status404NotFound, _response);

                };

                await _DbProduct.RemoveAsync(product);
                _response.StatusCode = HttpStatusCode.NoContent;
                return StatusCode(statusCode: StatusCodes.Status204NoContent, _response);
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }

        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutProductsById(Guid id, [FromBody] ProductUpdateDTO dataFromBody)
        {
            try
            {
                if (dataFromBody == null || id != dataFromBody.Id) return BadRequest();
                if (await _dbContext.Products.AsNoTracking().FirstAsync(i => i.Id == id) == null) return NotFound();

                Product model = _mapper.Map<Product>(dataFromBody);
                _dbContext.Products.Update(model);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }

        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PatchProductsById(Guid id, [FromBody] JsonPatchDocument<ProductUpdateDTO> data)
        {
            if (data == null) return BadRequest();
            Product product = await _dbContext.Products.AsNoTracking().FirstAsync(i => i.Id == id);
            if (product == null) return NotFound();

            ProductUpdateDTO productUpdateDTO = _mapper.Map<ProductUpdateDTO>(product);
            data.ApplyTo(productUpdateDTO, ModelState);
            if (!ModelState.IsValid) return BadRequest();

            Product model = _mapper.Map<Product>(productUpdateDTO);
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


        private ActionResult<ApiResponse> ExceptionReturnHelper(Exception ex)
        {
            _response.isSuccess = false;
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.ErrorMessages.Add(ex.Message);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, _response);
        }
    }
}
