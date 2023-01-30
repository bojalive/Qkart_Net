using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Qkart_WebAPI.Data;
using Qkart_WebAPI.Models.SellerDTO;
using System.Linq;
using System.Net;

namespace Qkart_WebAPI.Controllers
{
    [Route("api/v1/sellers")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly IRepository<Seller> _db;
        private readonly IMapper _mapper;
        private readonly ApiResponse _response;
        private readonly LinkProductSeller _productSeller;
        public SellersController(IRepository<Seller> db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
            _response = new();
            _productSeller = new();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApiResponse>> GetAllSellers()
        {
            try
            {
                List<Seller> sellers = await _db.GetAllAsync();
                if (sellers == null) return NoContent();
                _response.Result = sellers;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }


        }
        [HttpGet("{id:int}", Name = "GetSellerById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetSellerById(int id)
        {
            try
            {
                Seller seller = await _db.GetByIdAsync(i => i.Id == id);
                if (seller == null) return NoContent();
                _response.Result = seller;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }

        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> CreateSeller([FromBody] SellerCreateDTO data)
        {
            try
            {
                if (data == null) return BadRequest();
                Seller model = _mapper.Map<Seller>(data);
                var countCheck = await _db.GetAllAsync(i => i.SellerName == data.SellerName);
                if (countCheck.Count > 0) return BadRequest();
                await _db.CreateAsync(model);
                _response.Result = model;
                _response.StatusCode = HttpStatusCode.Created;
                return StatusCode(statusCode: StatusCodes.Status201Created, _response);
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }
        }
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateSeller([FromBody] SellerDTO data)
        {
            try
            {
                if (data == null) return BadRequest();
                Seller model = _mapper.Map<Seller>(data);

                await _db.UpdateAsync(model);
                _response.Result = data;
                _response.StatusCode = HttpStatusCode.Created;
                return StatusCode(statusCode: StatusCodes.Status201Created, _response);
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }
        }
        [HttpPatch]
        public async Task<IActionResult> PartialUpdateSeller(int id, [FromBody] JsonPatchDocument<SellerDTO> data)
        {
            try
            {
                if (data == null) return BadRequest();
                Seller seller = await _db.GetByIdAsync(i => i.Id == id, false);
                if (seller == null) return NotFound();

                SellerDTO dto = _mapper.Map<SellerDTO>(seller);
                data.ApplyTo(dto, ModelState);
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Seller model = _mapper.Map<Seller>(dto);
                await _db.UpdateAsync(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, this.ExceptionReturnHelper(ex));
            }


        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            try
            {
                Seller model = await _db.GetByIdAsync(i => i.Id == id, false);
                if (model == null) return NotFound("The Id passed is not found in server");

                await _db.RemoveAsync(model);
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
