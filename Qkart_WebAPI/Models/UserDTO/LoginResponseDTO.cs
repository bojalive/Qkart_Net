﻿namespace Qkart_WebAPI.Models.UserDTO
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }

        public string Role { get; set; }
    }
}
