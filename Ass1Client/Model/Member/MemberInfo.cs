﻿using System.Text.Json.Serialization;

namespace Ass1Client.Model.Member
{
    public class MemberInfo
    {
        [JsonPropertyName("MemberId")]
        public int MemberId { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }
        [JsonPropertyName("City")]
        public string City { get; set; }
        [JsonPropertyName("Country")]
        public string Country { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
