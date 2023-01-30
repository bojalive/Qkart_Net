namespace Qkart_WebAPI.Models.UserDTO
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
