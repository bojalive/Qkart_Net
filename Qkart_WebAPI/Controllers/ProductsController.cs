
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

        private readonly IMapper _mapper;
        private readonly IRepository<Product> _dbProduct;
        private readonly IRepository<Seller> _dbSeller;
        private readonly IRepository<LinkProductSeller> _dbProductSeller;


        public ApiResponse _response { get; set; }

        public ProductsController(IMapper mapper, IRepository<Product> db, IRepository<Seller> dbSeller, IRepository<LinkProductSeller> dbProductSeller)
        {

            this._mapper = mapper;
            this._dbProduct = db;
            this._dbSeller = dbSeller;
            this._dbProductSeller = dbProductSeller;
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
                IEnumerable<Product> productsList = await _dbProduct.GetAllAsync();
                List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(productsList);
                IEnumerable<Seller> sellerList = await _dbSeller.GetAllAsync();
                if (productsList != null)
                {

                    foreach (ProductDTO product in productDTO)
                    {

                        var linkData = await _dbProductSeller.GetAllAsync(i => i.ProductId == product.Id);
                        foreach (var item in linkData)
                        {
                            product.Sellers.AddRange(await _dbSeller.GetAllAsync(i => i.Id == item.SellerId));
                        }

                    }

                    _response.Result = productDTO;
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
                Product product = await _dbProduct.GetByIdAsync(i => i.Id == id);
                if (product == null) throw new Exception($"There was not product with the id - {id}");

                ProductDTO dto = _mapper.Map<ProductDTO>(product);

                var linkData = await _dbProductSeller.GetAllAsync(i => i.ProductId == dto.Id);
                foreach (var item in linkData)
                {
                    dto.Sellers.AddRange(await _dbSeller.GetAllAsync(i => i.Id == item.SellerId));
                }

                _response.Result = dto;
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
                if (await _dbProduct.GetByIdAsync(i => i.Name.ToLower() == data.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("", "The Name was Duplicate");
                    return BadRequest(ModelState);
                }
                Product model = _mapper.Map<Product>(data);

                model.Id = Guid.NewGuid();
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                await _dbProduct.CreateAsync(_mapper.Map<Product>(model));
                List<Seller> sellerModels = data.Sellers;
                if (sellerModels.Count > 0)
                {
                    foreach (var item in sellerModels)
                    {
                        await _dbSeller.CreateAsync(item);
                        LinkProductSeller link = new();
                        link.SellerId = item.Id;
                        link.ProductId = model.Id;
                        await _dbProductSeller.CreateAsync(link);

                    }
                }
                return CreatedAtRoute("GetProductById", new { id = model.Id }, data);
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
                Product product = await _dbProduct.GetByIdAsync(i => i.Id == id);
                if (product == null)
                {
                    _response.isSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return StatusCode(statusCode: StatusCodes.Status404NotFound, _response);

                };

                await _dbProduct.RemoveAsync(product);
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
        public async Task<IActionResult> PutProductsById(Guid id, [FromBody] ProductOnlyDTO dataFromBody)
        {
            try
            {
                if (dataFromBody == null || id != dataFromBody.Id) return BadRequest();
                if (await _dbProduct.GetByIdAsync(i => i.Id == id, false) == null) return NotFound();

                Product model = _mapper.Map<Product>(dataFromBody);
                await _dbProduct.UpdateAsync(model);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }

        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PatchProductsById(Guid id, [FromBody] JsonPatchDocument<ProductOnlyDTO> data)
        {
            try
            {
                if (data == null) return BadRequest();
                Product product = await _dbProduct.GetByIdAsync(i => i.Id == id, false);
                if (product == null) return NotFound();

                ProductOnlyDTO productUpdateDTO = _mapper.Map<ProductOnlyDTO>(product);
                data.ApplyTo(productUpdateDTO, ModelState);
                if (!ModelState.IsValid) return BadRequest(ModelState);

                Product model = _mapper.Map<Product>(productUpdateDTO);
                await _dbProduct.UpdateAsync(model);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }

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
