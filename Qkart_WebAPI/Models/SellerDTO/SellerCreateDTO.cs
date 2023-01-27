﻿namespace Qkart_WebAPI.Models.SellerDTO
{
    public class SellerCreateDTO
    {

        [MaxLength(100)]
        public string? SellerName { get; set; }
        public string? City { get; set; }
        [MaxLength(200)]
        public string? FullAddress { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
