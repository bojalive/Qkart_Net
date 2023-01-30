
global using Qkart_WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using Qkart_WebAPI.Data;
using Qkart_WebAPI.Models.dto;
using System.Net;
using System.Text.Json;

namespace Qkart_WebAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Product> _dbProduct;
        private readonly IRepository<Seller> _dbSeller;
        private readonly IRepository<LinkProductSeller> _dbProductSeller;


        public ApiResponse _response { get; set; }

        public ProductsController(IMapper mapper, IRepository<Product> db, IRepository<Seller> dbSeller, IRepository<LinkProductSeller> dbProductSeller)
        {

            _mapper = mapper;
            _dbProduct = db;
            _dbSeller = dbSeller;
            _dbProductSeller = dbProductSeller;
            _response = new();

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        //   [Authorize]
        public async Task<ActionResult<ApiResponse>> GetAllProducts([FromQuery] int? cost, int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IEnumerable<Product> productsList;
                if (cost == null)
                {
                    productsList = await _dbProduct.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);
                }
                else
                {
                    productsList = await _dbProduct.GetAllAsync(p => p.Cost == cost, pageSize: pageSize, pageNumber: pageNumber);
                }

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
                    Pagination pagination = new Pagination()
                    {
                        PageSize = pageSize,
                        PageNumber = pageNumber
                    };
                    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
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
                return ExceptionReturnHelper(ex);

            }

        }

        [HttpGet("search")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        //   [Authorize]
        public async Task<ActionResult<ApiResponse>> GetAllBySearch([FromQuery] string? search)
        {
            try
            {
                IEnumerable<Product> productsList;
                if (search == null)
                {
                    productsList = await _dbProduct.GetAllAsync();
                }
                else
                {
                    productsList = await _dbProduct.GetAllAsync(p => p.Name.ToLower().Contains(search.ToLower()));
                }

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
                return ExceptionReturnHelper(ex);

            }

        }

        [HttpGet("{id:Guid}", Name = "GetProductById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "admin")]
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

                return ExceptionReturnHelper(ex);
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
