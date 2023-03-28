using Azure;
using CameronTubeAPI.DTO;
using CameronTubeAPI.Helper;
using CameronTubeAPI.Models;
using CameronTubeAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Data;
using System.Net;

namespace CameronTubeAPI.Controllers
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VideoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Video> _dbVideo;
        private readonly IRepository<Statistics> _dbStatistics;
        private readonly IRepository<LinkTable> _dbLink;
        private readonly BlobHelper _blobHelper;

        public ApiResponse _response { get; set; }
        public VideoController(IMapper mapper, IRepository<Video> dbVideo, IRepository<Statistics> dbStatistics, IRepository<LinkTable> dbLink, BlobHelper blobHelper)
        {
            this._mapper = mapper;
            this._dbVideo = dbVideo;
            this._dbStatistics = dbStatistics;
            this._dbLink = dbLink;
            this._blobHelper = blobHelper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> GetAllVideos()
        {
            IEnumerable<Video> videoList = await _dbVideo.GetAllAsync();
            List<VideoDTO> videoDTOs = _mapper.Map<List<VideoDTO>>(videoList);

            //blob shit needs to be here I think
            // need to itreate through the list and for each on need to get an SAS token and append to the List as Url

            foreach (var v in videoDTOs)
            {
                var url = _blobHelper.GetSASTokenForBlobs(v.Name);
                v.Url = url.Result;
            }


            IEnumerable<Statistics> statistics = await _dbStatistics.GetAllAsync();

            if (videoList != null)
            {
                foreach (VideoDTO video in videoDTOs)
                {
                    var linkData = await _dbLink.GetAllAsync(i => i.VideoId == video.Id);
                    foreach (var item in linkData)
                    {
                        video.Statistics.AddRange(await _dbStatistics.GetAllAsync(i => i.Id == item.StatisticsID));
                    }
                }
            }
            _response.Result = videoDTOs;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }


        [HttpGet("{id:Guid}", Name = "GetProductById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> GetProductsById(Guid id)
        {
            try
            {
                Video video = await _dbVideo.GetByIdAsync(i => i.Id == id);
                if (video == null) throw new Exception($"There was not product with the id - {id}");

                VideoDTO dto = _mapper.Map<VideoDTO>(video);

                var linkData = await _dbLink.GetAllAsync(i => i.VideoId == dto.Id);
                foreach (var item in linkData)
                {
                    dto.Statistics.AddRange(await _dbStatistics.GetAllAsync(i => i.Id == item.StatisticsID));
                }

                _response.Result = dto;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                return ExceptionReturnHelper(ex);
            }

        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Manager")]
        [Authorize(Policy = "AManager")]
        public async Task<ActionResult<ApiResponse>> AddNewProduct([FromBody] VideoCreateDTO data)
        {
            try
            {
                if (data == null) return BadRequest();
                if (await _dbVideo.GetByIdAsync(i => i.Title == data.Title) != null)
                {
                    ModelState.AddModelError("", "The Name was Duplicate");
                    return BadRequest(ModelState);
                }
                Video model = _mapper.Map<Video>(data);

                model.Id = Guid.NewGuid();
                //  model.CreatedDate = DateTime.Now;
                //  model.UpdatedDate = DateTime.Now;
                await _dbVideo.CreateAsync(_mapper.Map<Video>(model));
                List<Statistics> sellerModels = data.Statistics;
                if (sellerModels.Count > 0)
                {
                    foreach (var item in sellerModels)
                    {
                        await _dbStatistics.CreateAsync(item);
                        LinkTable link = new();
                        link.StatisticsID = item.Id;
                        link.VideoId = model.Id;
                        await _dbLink.CreateAsync(link);

                    }
                }
                return Ok(model); // CreatedAtRoute("GetProductById", new { id = model.Id }, data);
            }
            catch (Exception ex)
            {

                return ExceptionReturnHelper(ex);
            }

        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Manager")]
        [Authorize]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            try
            {
                Video product = await _dbVideo.GetByIdAsync(i => i.Id == id);
                if (product == null)
                {
                    _response.isSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return StatusCode(statusCode: StatusCodes.Status404NotFound, _response);

                };

                await _dbVideo.RemoveAsync(product);
                _response.StatusCode = HttpStatusCode.NoContent;
                return StatusCode(statusCode: StatusCodes.Status204NoContent, _response);
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, ExceptionReturnHelper(ex));
            }

        }
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PutProductsById(Guid id, [FromBody] VideoDTO dataFromBody)
        {
            try
            {
                if (dataFromBody == null || id != dataFromBody.Id) return BadRequest();
                if (await _dbVideo.GetByIdAsync(i => i.Id == id, false) == null) return NotFound();

                Video model = _mapper.Map<Video>(dataFromBody);
                await _dbVideo.UpdateAsync(model);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, ExceptionReturnHelper(ex));
            }

        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> PatchProductsById(Guid id, [FromBody] JsonPatchDocument<VideoCreateDTO> data)
        {
            try
            {
                if (data == null) return BadRequest();
                Video product = await _dbVideo.GetByIdAsync(i => i.Id == id, false);
                if (product == null) return NotFound();

                VideoCreateDTO productUpdateDTO = _mapper.Map<VideoCreateDTO>(product);
                data.ApplyTo(productUpdateDTO, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
                if (!ModelState.IsValid) return BadRequest(ModelState);

                Video model = _mapper.Map<Video>(productUpdateDTO);
                await _dbVideo.UpdateAsync(model);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, ExceptionReturnHelper(ex));
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
