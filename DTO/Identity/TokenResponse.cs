using System;

namespace SmartSence.DTO.Identity
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }

    }
}