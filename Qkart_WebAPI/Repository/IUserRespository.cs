global using Qkart_WebAPI.Models.UserDTO;

namespace Qkart_WebAPI.Repository
{
    public interface IUserRespository<T> where T : class
    {
        bool isUserUnique(string userName);
        Task<UserDTO> UserRegistration(RegistrationRequestDTO userRequest);
        Task<LoginResponseDTO> UserLogin(LoginRequestDTO userRequest);
    }
}
