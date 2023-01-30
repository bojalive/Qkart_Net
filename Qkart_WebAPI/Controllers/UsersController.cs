using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Qkart_WebAPI.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRespository<LocalUser> _userResp;
        private ApiResponse _response;
        public UsersController(IUserRespository<LocalUser> userRespository)
        {
            this._userResp = userRespository;
            _response = new();
        }

        [HttpPost("login")]

        public async Task<ActionResult<ApiResponse>> login(LoginRequestDTO requestDTO)
        {
            LoginResponseDTO result = await _userResp.UserLogin(requestDTO);

            if (result == null)
            {
                _response.isSuccess = false;
                _response.ErrorMessages.Add("The Username/Password is wrong");
                _response.Result = null;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = result;
            return _response;
        }
        [HttpPost("register")]

        public async Task<ActionResult<ApiResponse>> Register(RegistrationRequestDTO requestDTO)
        {
            if (requestDTO == null) return NotFound(_response);
            if (!_userResp.isUserUnique(requestDTO.UserName)) return BadRequest("UserName already exists");
            LocalUser user = await _userResp.UserRegistration(requestDTO);
            if (user == null) return BadRequest("There was a problem in user Creation");
            _response.Result = user;
            return _response;
        }
    }
}
